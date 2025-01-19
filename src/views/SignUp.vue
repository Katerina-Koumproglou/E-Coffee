<template>
    <div class="user-profile">
        <h1>Sign Up</h1>
        <form @submit.prevent="saveProfile" class="form-grid">
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
                <input :type="showPassword ? 'text' : 'password'"
                       id="password"
                       v-model="user.password" />
                <button type="button" @click="togglePasswordVisibility">
                    {{ showPassword ? 'Hide' : 'Show' }} Password
                </button>
                <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
            </div>
            <div class="form-item">
                <label for="c_password">Confirm Password:</label>
                <input :type="showPassword ? 'text' : 'password'"
                       id="c_password"
                       v-model="user.c_password" />
                <button type="button" @click="togglePasswordVisibility">
                    {{ showPassword ? 'Hide' : 'Show' }} Password
                </button>
                <span v-if="errors.c_password" class="error-message">{{ errors.c_password }}</span>
            </div>
            <div class="form-item">
                <label for="address">Address:</label>
                <input type="text" id="address" v-model="user.address" />
                <span v-if="errors.address" class="error-message">{{ errors.address }}</span>
            </div>
            <div class="form-item phone-center">
                <label for="phone">Phone:</label>
                <input type="text" id="phone" v-model="user.phone" placeholder="(+30) 69X-XXX-XXXX" />
                <span v-if="errors.phone" class="error-message">{{ errors.phone }}</span>
            </div>
            <button type="submit">Submit</button>
        </form>
        <p class="login-link">
            Already have an account?
            <router-link to="/Login">Login</router-link>
        </p>
    </div>
</template>

<script>
    import { addDoc, collection } from "firebase/firestore";
    import { db } from "../firebase";

    export default {
        data() {
            return {
                user: {
                    name: '',
                    surname: '',
                    email: '',
                    password: '',
                    c_password: '',
                    address: '',
                    phone: ''
                },
                errors: {
                    name: '',
                    surname: '',
                    email: '',
                    password: '',
                    c_password: '',
                    address: '',
                    phone: ''
                },
                showPassword: false,  // Ελέγχουμε αν θα εμφανίζεται ο κωδικός
            };
        },
        methods: {
            togglePasswordVisibility() {
                this.showPassword = !this.showPassword;
            },
            async saveProfile() {
                // Reset error messages
                this.errors = {
                    name: '',
                    surname: '',
                    email: '',
                    password: '',
                    c_password: '',
                    address: '',
                    phone: ''
                };

                // Validation checks
                let hasError = false;
                if (!this.user.name) {
                    this.errors.name = 'Name is required';
                    hasError = true;
                }
                if (!this.user.surname) {
                    this.errors.surname = 'Surname is required';
                    hasError = true;
                }
                if (!this.user.email) {
                    this.errors.email = 'Email is required';
                    hasError = true;
                }
                if (!this.user.password) {
                    this.errors.password = 'Password is required';
                    hasError = true;
                } else if (this.user.password !== this.user.c_password) {
                    this.errors.c_password = 'Passwords do not match';
                    hasError = true;
                }
                if (!this.user.address) {
                    this.errors.address = 'Address is required';
                    hasError = true;
                }
                if (!this.user.phone) {
                    this.errors.phone = 'Phone is required';
                    hasError = true;
                }

                // If validation fails, stop execution
                if (hasError) return;

                try {
                    // Add user data to Firestore
                    const docRef = await addDoc(collection(db, "user"), this.user);
                    console.log("Document written with ID: ", docRef.id);

                    // Clear the form fields
                    this.user = {
                        name: '',
                        surname: '',
                        email: '',
                        password: '',
                        c_password: '',
                        address: '',
                        phone: ''
                    };

                    alert("Profile successfully saved!");
                } catch (e) {
                    console.error("Error adding document: ", e);
                    alert("Failed to save profile. Please try again.");
                }
            }
        }
    };
</script>

<style scoped>
    /* Same styling as before */
    .user-profile {
        max-width: 600px;
        margin: auto;
        font-family: 'EB Garamond', serif;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 8px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        background-color: #5d2d05;
        color: #faebd7;
    }

    .form-grid {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: 20px;
    }

    .form-item {
        display: flex;
        flex-direction: column;
    }

    label {
        color: #faebd7;
        margin-bottom: 5px;
    }

    input {
        padding: 8px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 4px;
        text-align: center;
        color: #5d2d05;
    }

    button {
        grid-column: span 2;
        background-color: #faebd7;
        color: #5d2d05;
        border: none;
        padding: 10px;
        border-radius: 5px;
        cursor: pointer;
        margin-top: 10px;
    }

    .error-message {
        color: red;
        font-size: 0.9em;
    }

    /* Κέντρο του πεδίου τηλεφώνου */
    .phone-center {
        grid-column: span 2;
        display: flex;
        justify-content: center;
        align-items: center;
    }

        .phone-center input {
            width: 100%;
            max-width: 300px; /* Για να μην είναι υπερβολικά μεγάλο */
        }
</style>
