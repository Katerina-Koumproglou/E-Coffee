<template>
    <div class="login-container">
        <h1>Log in</h1>
        <form @submit.prevent="handleLogin" class="form-grid">
            <div class="form-item">
                <label for="email">Email</label>
                <input type="email" v-model="email" id="email" required />
            </div>
            <div class="form-item">
                <label for="password">Password</label>
                <input type="password" v-model="password" id="password" required />
            </div>
            <div v-if="error" class="error-message">{{ error }}</div>
            <button type="submit">Log in</button>
        </form>
        <!-- Signup Link -->
        <p class="signup-link">
            Don't have an account? Sign up <router-link to="/signup" class="signup-link-text">here</router-link>
        </p>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        data() {
            return {
                email: "",
                password: "",
                error: null,
            };
        },
        created() {
            const token = localStorage.getItem("token");
            const userId = localStorage.getItem("userId");

            if (token && userId) {
                this.$router.push({ name: "UserProfile", params: { userId } });
            }
        },
        methods: {
            async handleLogin() {
                try {
                    const response = await axios.post("http://83.212.99.172:5214/auth/login", {
                        email: this.email,
                        password: this.password,
                    });

                    const { token, user } = response.data;
                    localStorage.setItem("token", token);
                    localStorage.setItem("userId", user.userId);

                    console.log("Login successful: ", response.data);

                    this.$router.push({
                        name: "UserProfile",
                        params: { userId: user.userId },
                    });

                } catch (error) {
                    console.error("Login failed: ", error);
                    this.error = "Login failed, please check your login info.";
                }
            },
        },
    };
</script>

<style scoped>
    .login-container {
        max-width: 400px;
        margin: auto;
        padding: 30px;
        border-radius: 12px;
        background-color: #5d2d05;
        color: #faebd7;
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.15);
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    h1 {
        text-align: center;
        color: #faebd7;
        margin-bottom: 30px;
        font-size: 28px; /* Increased font size */
        font-weight: bold;
    }

    .form-grid {
        display: grid;
        grid-template-columns: 1fr;
        gap: 20px;
        width: 100%;
    }

    .form-item {
        display: flex;
        flex-direction: column;
    }

    label {
        font-size: 1.2rem; /* Increased font size */
        margin-bottom: 8px;
        font-weight: bold;
    }

    input {
        padding: 14px; /* Increased padding */
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

    button {
        background-color: #ffcc99;
        color: #5d2d05;
        padding: 14px; /* Increased padding */
        border: none;
        font-family: "EB Garamond", serif;
        border-radius: 6px;
        cursor: pointer;
        width: 100%;
        font-size: 18px;
	font-weight: bold;
        margin-top: 20px;
    }

        button:hover {
            background-color: #e6a676;
        }

    .error-message {
        color: #ff4d4d;
        margin-top: 10px;
        font-size: 1rem; /* Increased font size */
    }

    .signup-link {
        text-align: center;
        margin-top: 20px;
        font-size: 1.1rem; /* Increased font size */
    }

    .signup-link-text {
        font-weight: bold;
        color: #ffcc99;
        text-decoration: none;
    }

        .signup-link-text:hover {
            text-decoration: underline;
            color: #e6a676;
        }

    @media (max-width: 768px) {
        .form-grid {
            grid-template-columns: 1fr;
        }
    }
</style>
