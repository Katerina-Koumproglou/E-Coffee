<template>
  <div class="login-container">
    <h1>Login</h1>
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
      <button type="submit">Login</button>
    </form>
    <!-- Login Link -->
    <p class="login-link">
      Don't have an account? <router-link to="/signup">Signup</router-link>
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
        const response = await axios.post("http://localhost:5214/auth/login", {
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
  padding: 20px;
  border-radius: 8px;
  background-color: #5d2d05;
  color: #faebd7;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  display: flex;
  flex-direction: column;
  align-items: center;
}

h1 {
  text-align: center;
  color: #faebd7;
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
  border: 1px solid #d5b28b;
  border-radius: 5px;
  background-color: #faebd7;
  color: #5d2d05;
  font-size: 1rem;
}

input:focus {
  border-color: #d5b28b;
  outline: none;
}

button {
  background-color: #faebd7;
  color: #5d2d05;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
  font-size: 16px;
  margin-top: 20px;
}

button:hover {
  background-color: #d5b28b;
}

.error-message {
  color: red;
  margin-top: 10px;
  font-size: 0.9rem;
}
</style>
