<template>
    <div class="signup">
        <h1>Sign Up</h1>
        <form @submit.prevent="signUp" class="form-grid">
            <!-- Name Field -->
            <div class="form-item">
                <label for="name">Name:</label>
                <input type="text" id="name" v-model="user.name" />
                <span v-if="errors.name" class="error-message">{{ errors.name }}</span>
            </div>

            <!-- Surname Field -->
            <div class="form-item">
                <label for="surname">Surname:</label>
                <input type="text" id="surname" v-model="user.surname" />
                <span v-if="errors.surname" class="error-message">{{ errors.surname }}</span>
            </div>

            <!-- Email Field -->
            <div class="form-item">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="user.email" />
                <span v-if="errors.email" class="error-message">{{ errors.email }}</span>
            </div>

            <!-- Password Field with Show/Hide functionality -->
            <div class="form-item">
                <label for="password">Password:</label>
                <input :type="showPassword ? 'text' : 'password'" id="password" v-model="user.password" />
                <button type="button" class="show-hide-button" @click="togglePasswordVisibility">
                    {{ showPassword ? "Hide" : "Show" }}
                </button>
                <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
            </div>

            <!-- Confirm Password Field -->
            <div class="form-item">
                <label for="confirmPassword">Confirm Password:</label>
                <input :type="showConfirmPassword ? 'text' : 'password'" id="confirmPassword" v-model="user.confirmPassword" />
                <button type="button" class="show-hide-button" @click="toggleConfirmPasswordVisibility">
                    {{ showConfirmPassword ? "Hide" : "Show" }}
                </button>
                <span v-if="errors.confirmPassword" class="error-message">{{ errors.confirmPassword }}</span>
            </div>

            <!-- Address Field -->
            <div class="form-item">
                <label for="address">Address:</label>
                <input type="text" id="address" v-model="user.address" />
                <span v-if="errors.address" class="error-message">{{ errors.address }}</span>
            </div>

            <!-- Phone Field -->
            <div class="form-item">
                <label for="phone">Phone:</label>
                <input type="text" id="phone" v-model="user.phone" />
                <span v-if="errors.phone" class="error-message">{{ errors.phone }}</span>
            </div>

            <!-- Submit Button -->
            <button type="submit">Sign Up</button>

            <!-- Error Message -->
            <div v-if="error" class="error-message">{{ error }}</div>
        </form>

        <!-- Login Link -->
        <p class="login-link">
            Already have an account? <router-link to="/login">Login</router-link>
        </p>
    </div>
</template>

<script>
import { doc, setDoc } from "firebase/firestore";
    import { auth, db } from "@/firebase"; // Προσαρμόστε τη διαδρομή ανάλογα με το πρότζεκτ σας
    import { createUserWithEmailAndPassword } from "firebase/auth";

    export default {
        data() {
            return {
                user: {
                    name: "",
                    surname: "",
                    email: "",
                    password: "",
                    confirmPassword: "",
                    address: "",
                    phone: "",
                },
                errors: {},
                error: "",
            };
        },
        methods: {
            async signUp() {
                this.errors = {};

                // Validation logic
                if (!this.user.name) this.errors.name = "Name is required";
                if (!this.user.surname) this.errors.surname = "Surname is required";
                if (!this.user.email) this.errors.email = "Email is required";
                if (!this.user.password) this.errors.password = "Password is required";
                if (this.user.password !== this.user.confirmPassword) {
                    this.errors.confirmPassword = "Passwords do not match";
                }
                if (!this.user.address) this.errors.address = "Address is required";
                if (!this.user.phone) this.errors.phone = "Phone is required";

                if (Object.keys(this.errors).length) return;

                try {
                    // Δημιουργία χρήστη στο Firebase Authentication
                    const userCredential = await createUserWithEmailAndPassword(
                        auth,
                        this.user.email,
                        this.user.password
                    );
                    const userId = userCredential.user.uid;

                    // Αποθήκευση δεδομένων χρήστη στο Firestore με το UID ως ID εγγράφου
                    await setDoc(doc(db, "users", userId), {
                        name: this.user.name,
                        surname: this.user.surname,
                        email: this.user.email,
                        address: this.user.address,
                        phone: this.user.phone,
                    });

                    // Ανακατεύθυνση μετά την επιτυχημένη εγγραφή
                    this.$router.push("/");

                } catch (error) {
                    this.error = error.message;
                }
            },
        },
    };
</script>

<style scoped>
    .signup {
        max-width: 600px;
        margin: auto;
        padding: 20px;
        border-radius: 8px;
        background-color: #5D2D05;
        color: #FAEBD7;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    h1 {
        text-align: center;
        color: #FAEBD7;
        margin-bottom: 20px;
    }

    .form-grid {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 15px;
        width: 100%;
        margin-bottom: 20px;
    }

    .form-item {
        display: flex;
        flex-direction: column;
    }

    label {
        font-size: 1rem;
        margin-bottom: 5px;
    }

    input {
        padding: 8px;
        border: 1px solid #D5B28B;
        border-radius: 5px;
        background-color: #FAEBD7;
        color: #5D2D05;
        font-size: 1rem;
    }

        input:focus {
            border-color: #D5B28B;
            outline: none;
        }

    button {
        background-color: #FAEBD7;
        color: #5D2D05;
        padding: 6px 12px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 14px;
        width: auto;
        margin-top: 10px;
    }

        button:hover {
            background-color: #D5B28B;
        }

    .show-hide-button {
        background: none;
        border: none;
        color: #5D2D05;
        font-size: 14px;
        padding: 0;
        cursor: pointer;
        text-decoration: underline;
    }

    .error-message {
        color: red;
        margin-top: 5px;
        font-size: 0.9rem;
    }

    .login-link {
        text-align: center;
        margin-top: 15px;
    }

    @media (max-width: 768px) {
        .form-grid {
            grid-template-columns: 1fr;
        }

        button {
            width: 100%;
        }
    }
</style>