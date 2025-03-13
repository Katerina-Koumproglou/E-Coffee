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

            <!-- Password Field -->
            <div class="form-item">
                <label for="password">Password:</label>
                <div class="input-container">
                    <input v-model="user.password"
                           :type="showPassword ? 'text' : 'password'"
                           id="password"
                           />
                    <i class="eye-icon" @click="togglePassword">👁️</i>
                </div>
                <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
            </div>

            <!-- Confirm Password Field -->
            <div class="form-item">
                <label for="confirmPassword">Confirm Password:</label>
                <div class="input-container">
                    <input v-model="user.confirmPassword"
                           :type="showConfirmPassword ? 'text' : 'password'"
                           id="confirmPassword"
                           />
                    <i class="eye-icon" @click="toggleConfirmPassword">👁️</i>
                </div>
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
                <label for="phone">Phone</label>
                <input type="text" v-model="user.phone" id="phone" maxlength="10" pattern="^[0-9]{10}$" required />
            </div>

            <!-- Submit Button -->
            <button type="submit">Sign Up</button>

            <!-- Error Message -->
            <div v-if="error" class="error-message">{{ error }}</div>
        </form>

        <!-- Login Link -->
        <p class="login-link">
            Already have an account? <router-link to="/auth/login" class="login-link-text">Login</router-link>
        </p>
    </div>
</template>

<script>
    import axios from "axios"; // Correctly import axios

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
                showPassword: false,
                showConfirmPassword: false,
            };
        },
        methods: {
            togglePassword() {
                this.showPassword = !this.showPassword;
            },
            toggleConfirmPassword() {
                this.showConfirmPassword = !this.showConfirmPassword;
            },

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
                    const response = await axios.post("http://localhost:5214/auth/signup", {
                        name: this.user.name,
                        surname: this.user.surname,
                        email: this.user.email,
                        password: this.user.password,
                        address: this.user.address,
                        phone: this.user.phone,
                    });

                    console.log("Signup successful: ", response.data);

                    this.$router.push("/auth/login");
                } catch (error) {
                    console.error("Signup failed: ", error.message);
                    if (error.response && error.response.status === 400) {
                        this.error = "Email is already in use. Please try a different one.";
                    } else {
                        this.error = "An unexpected error occured. Please try again.";
                    }
                }
            },
        },
    };
</script>

<style scoped>
    .signup {
        max-width: 600px;
        margin: auto;
        padding: 30px;
        border-radius: 12px;
        background: #5d2d05;
        color: #faebd7;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    h1 {
        text-align: center;
        color: #faebd7;
        margin-bottom: 20px;
        font-size: 28px; /* Increased font size */
        font-weight: bold;
    }

    .form-grid {
        display: grid;
        grid-template-columns: repeat(2, 1fr);
        gap: 20px; /* Increased gap */
        width: 100%;
    }

    .form-item {
        display: flex;
        flex-direction: column;
        position: relative;
    }

    label {
        font-size: 1.2rem; /* Increased font size */
        margin-bottom: 5px;
        font-weight: bold;
    }

    input {
        padding: 12px; /* Increased padding */
        border: 1px solid #d5b28b;
        border-radius: 6px;
        background-color: #faebd7;
        color: #5d2d05;
        font-size: 1.1rem; /* Increased font size */
        width: 100%;
    }

        input:focus {
            border-color: #e6a676;
            outline: none;
        }

    .input-container {
        position: relative;
        width: 100%;
    }

    .eye-icon {
        position: absolute;
        right: 10px;
        top: 50%;
        transform: translateY(-50%);
        cursor: pointer;
        font-size: 20px; /* Increased font size */
        color: #5d2d05;
    }

    button {
        background-color: #ffcc99;
        color: #5d2d05;
        padding: 12px; /* Increased padding */
        border: none;
        border-radius: 6px;
        cursor: pointer;
        font-size: 18px; /* Increased font size */
        font-weight: bold;
        width: 100%;
        margin-top: 15px;
        grid-column: span 2;
    }

        button:hover {
            background-color: #e6a676;
        }

    .error-message {
        color: #ff4d4d;
        margin-top: 4px;
        font-size: 1rem; /* Increased font size */
    }

    .login-link {
        text-align: center;
        margin-top: 20px; /* Increased margin */
        font-size: 1.1rem; /* Increased font size */
        grid-column: span 2;
    }

    .login-link-text {
        font-weight: bold;
        color: #ffcc99;
        text-decoration: none;
    }

        .login-link-text:hover {
            text-decoration: underline;
            color: #e6a676;
        }

    @media (max-width: 768px) {
        .form-grid {
            grid-template-columns: 1fr;
        }

        button {
            grid-column: span 1;
        }

        .login-link {
            grid-column: span 1;
        }
    }
</style>
