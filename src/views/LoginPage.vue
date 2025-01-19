<template>
    <div class="login-container">
        <h1>Login</h1>
        <form @submit.prevent="login" class="form-grid">
            <div class="form-item">
                <label for="email">Email</label>
                <input type="email" v-model="email" id="email" required />
            </div>
            <div class="form-item">
                <label for="password">Password</label>
                <input type="password" v-model="password" id="password" required />
            </div>
            <div v-if="error" class="error-message">{{ error }}</div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
    import { signInWithEmailAndPassword } from "firebase/auth";
    import { auth } from "@/firebase";

    export default {
        data() {
            return {
                email: "",
                password: "",
                error: null
            };
        },
        methods: {
            async login() {
                try {
                    const userCredential = await signInWithEmailAndPassword(auth, this.email, this.password);
                    const user = userCredential.user;

                    // Ανακατεύθυνση στο UserProfile με το userId
                    this.$router.push(`/user-profile/${user.uid}`);
                } catch (error) {
                    this.error = "Login failed: " + error.message;
                }
            }
        }
    };
</script>

<style scoped>
    .login-container {
        max-width: 400px;
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
        grid-template-columns: 1fr;
        gap: 15px;
        width: 100%;
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
        padding: 10px;
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
        padding: 10px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        width: 100%;
        font-size: 16px;
        margin-top: 20px;
    }

        button:hover {
            background-color: #D5B28B;
        }

    .error-message {
        color: red;
        margin-top: 10px;
        font-size: 0.9rem;
    }
</style>
