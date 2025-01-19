<template>
    <div class="login">
        <h1>Login</h1>
        <form @submit.prevent="login" class="form-grid">
            <div class="form-item">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="email" required />
            </div>
            <div class="form-item">
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="password" required />
            </div>
            <button type="submit">Login</button>
            <div v-if="error" class="error-message">{{ error }}</div>
        </form>
    </div>
</template>

<script>
    import { auth } from "@/firebase";
    import { signInWithEmailAndPassword } from "firebase/auth";

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
                    this.$router.push(`/profile/${userCredential.user.uid}`);
                } catch (error) {
                    this.error = error.message;
                }
            }
        }
    };
</script>

<style scoped>
    .login {
        max-width: 400px;
        margin: auto;
        padding: 20px;
        border-radius: 8px;
        background-color: #5D2D05;
        color: #FAEBD7;
    }

    h1 {
        text-align: center;
        color: #FAEBD7;
    }

    .form-grid {
        display: grid;
        grid-template-columns: 1fr;
        gap: 15px;
    }

    .form-item {
        display: flex;
        flex-direction: column;
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
