<template>
    <div class="signup">
        <h1>Sign Up</h1>
        <form @submit.prevent="signUp" class="form-grid">
            <div class="form-item">
                <label for="name">Name:</label>
                <input type="text" id="name" v-model="user.name" />
                <span v-if="errors.name" class="error-message">{{ errors.name }}</span>
            </div>
            <div class="form-item">
                <label for="surname">Surname:</label>
                <input type="text" id="surname" v-model="user.surname" />
                <span v-if="errors.surname" class="error-message">{{ errors.surname }}</span>
            </div>
            <div class="form-item">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="user.email" />
                <span v-if="errors.email" class="error-message">{{ errors.email }}</span>
            </div>
            <div class="form-item">
                <label for="password">Password:</label>
                <input :type="showPassword ? 'text' : 'password'" id="password" v-model="user.password" />
                <button type="button" @click="togglePasswordVisibility">
                    {{ showPassword ? 'Hide' : 'Show' }} Password
                </button>
                <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
            </div>
            <div class="form-item">
                <label for="confirmPassword">Confirm Password:</label>
                <input :type="showPassword ? 'text' : 'password'" id="confirmPassword" v-model="user.c_password" />
                <span v-if="errors.c_password" class="error-message">{{ errors.c_password }}</span>
            </div>
            <div class="form-item">
                <label for="address">Address:</label>
                <input type="text" id="address" v-model="user.address" />
                <span v-if="errors.address" class="error-message">{{ errors.address }}</span>
            </div>
            <div class="form-item">
                <label for="phone">Phone:</label>
                <input type="text" id="phone" v-model="user.phone" placeholder="(+30) 69X-XXX-XXXX" />
                <span v-if="errors.phone" class="error-message">{{ errors.phone }}</span>
            </div>
            <button type="submit">Sign Up</button>
            <div v-if="error" class="error-message">{{ error }}</div>
        </form>
        <p class="login-link">
            Already have an account?
            <router-link to="/Login">Login</router-link>
        </p>
    </div>
</template>

<script>
    import { addDoc, collection } from "firebase/firestore";
    import { createUserWithEmailAndPassword } from "firebase/auth";
    import { auth, db } from "@/firebase";

    export default {
        data() {
            return {
                user: {
                    name: "",
                    surname: "",
                    email: "",
                    password: "",
                    c_password: "",
                    address: "",
                    phone: "",
                },
                errors: {
                    name: "",
                    surname: "",
                    email: "",
                    password: "",
                    c_password: "",
                    address: "",
                    phone: "",
                },
                showPassword: false,
                error: null,
            };
        },
        methods: {
            togglePasswordVisibility() {
                this.showPassword = !this.showPassword;
            },
            async signUp() {
                this.errors = {
                    name: "",
                    surname: "",
                    email: "",
                    password: "",
                    c_password: "",
                    address: "",
                    phone: "",
                };
                let hasError = false;

                // Validation
                if (!this.user.name) {
                    this.errors.name = "Name is required";
                    hasError = true;
                }
                if (!this.user.surname) {
                    this.errors.surname = "Surname is required";
                    hasError = true;
                }
                if (!this.user.email) {
                    this.errors.email = "Email is required";
                    hasError = true;
                }
                if (!this.user.password) {
                    this.errors.password = "Password is required";
                    hasError = true;
                } else if (this.user.password !== this.user.c_password) {
                    this.errors.c_password = "Passwords do not match";
                    hasError = true;
                }
                if (!this.user.address) {
                    this.errors.address = "Address is required";
                    hasError = true;
                }
                if (!this.user.phone) {
                    this.errors.phone = "Phone is required";
                    hasError = true;
                }

                if (hasError) return;

                try {
                    // Create Firebase user
                    await createUserWithEmailAndPassword(auth, this.user.email, this.user.password);

                    // Add user details to Firestore
                    await addDoc(collection(db, "users"), {
                        name: this.user.name,
                        surname: this.user.surname,
                        email: this.user.email,
                        address: this.user.address,
                        phone: this.user.phone,
                    });

                    // Redirect to login
                    this.$router.push("/login");
                } catch (error) {
                    this.error = error.message;
                }
            },
        },
    };
</script>

<style scoped>
    .signup {
        max-width: 400px;
        margin: auto;
        padding: 20px;
        border-radius: 8px;
        background-color: #5d2d05;
        color: #faebd7;
    }

    h1 {
        text-align: center;
    }

    .form-grid {
        display: grid;
        gap: 15px;
    }

    .form-item {
        display: flex;
        flex-direction: column;
    }

    button {
        background-color: #faebd7;
        color: #5d2d05;
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

        button:hover {
            background-color: #d5b28b;
        }

    .error-message {
        color: red;
        font-size: 0.9rem;
    }

    .login-link {
        text-align: center;
        margin-top: 15px;
    }
</style>
