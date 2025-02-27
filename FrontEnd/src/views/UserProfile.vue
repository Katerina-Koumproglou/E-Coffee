<template>
  <div class="user-profile">
    <div v-if="userData && !errorMessage" class="profile-details">
      <h1>User Profile</h1>
      <p><strong>Name:</strong> {{ userData.name }}</p>
      <p><strong>Surname:</strong> {{ userData.surname }}</p>
      <p><strong>Email:</strong> {{ userData.email }}</p>
      <p><strong>Phone:</strong> {{ userData.phone }}</p>
      <p><strong>Address:</strong> {{ userData.address }}</p>
    </div>
    <div v-else-if="loading">
      <p>Loading user data...</p>
    </div>
    <div v-else-if="errorMessage">
      <p class="error">{{ errorMessage }}</p>
    </div>
    <div class="buttons" v-if="!loading">
      <button @click="logout">Logout</button>
      <button @click="goToEditProfile" :disabled="!userData">
        Edit Profile
      </button>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["userId"],

  data() {
    return {
      userData: null,
      loading: true,
      errorMessage: "",
    };
  },
  async mounted() {
    const userId = this.userId || this.$route.params.userId;
    if (!userId) {
      this.errorMessage = "No user ID found.";
      this.loading = false;
      return;
    }

    console.log("Recieved data for userId: ", userId);
    try {
      const response = await axios.get(`http://localhost:5214/users/${userId}`);

      this.userData = response.data;
    } catch (error) {
      this.errorMessage = "Failed to retrieve user data.";
    } finally {
      this.loading = false;
    }
  },
  methods: {
    logout() {
        localStorage.removeItem("token");
        this.userData = null;

        this.$router.push("/auth/login");
    },

    goToEditProfile() {
        this.$router.push({ name: "EditProfile" });
    },
  },
};
</script>

<style scoped>
.user-profile {
  max-width: 400px;
  margin: auto;
  padding: 20px;
  border-radius: 8px;
  background-color: #5d2d05;
  color: #faebd7;
}

h1 {
  text-align: center;
  color: #faebd7;
}

.profile-details p {
  font-size: 18px;
  margin: 10px 0;
}

.error {
  color: #ff6b6b;
  font-weight: bold;
  text-align: center;
}

.buttons {
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
}

button {
  background-color: #faebd7;
  color: #5d2d05;
  padding: 10px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  width: 45%;
  font-size: 16px;
}

button:disabled {
  background-color: #b2a59d;
  cursor: not-allowed;
}

button:hover {
  background-color: #d5b28b;
}
</style>
