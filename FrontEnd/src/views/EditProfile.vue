<template>
  <div class="edit-profile">
    <h1>Edit Profile</h1>
    <form @submit.prevent="updateUserInfo">
      <div>
        <label for="name">Name:</label>
        <input type="text" id="name" v-model="name" required />
      </div>
      <div>
        <label for="surname">Surname:</label>
        <input type="text" id="surname" v-model="surname" required />
      </div>
      <div>
        <label for="phone">Phone:</label>
        <input type="text" id="phone" v-model="phone" required />
      </div>
      <div>
        <label for="address">Address:</label>
        <input type="text" id="address" v-model="address" required />
      </div>
      <button type="submit">Save Changes</button>
    </form>

    <!-- Return Button -->
    <button @click="goBack" class="return-btn">Return</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      name: "",
      surname: "",
      email: "",
      phone: "",
      address: "",
      token: localStorage.getItem("token"),
      userId: localStorage.getItem("userId"),
    };
  },
  async mounted() {
    if (!this.token || !this.userId) {
      console.error("User is not authenticated.");
      this.$router.push("/auth/login");
      return;
    }
    await this.loadUserData();
  },
  methods: {
    async loadUserData() {
      try {
        const storedUserId = localStorage.getItem("userId");
        if (!storedUserId) {
          console.error("No user ID is found.");
          this.$router.push("/auth/login");
          return;
        }

        this.userId = storedUserId;
        const response = await axios.get(
          `http://localhost:5214/users/${this.userId}`,
          {
            headers: {
              Authorization: `Bearer ${this.token}`,
            },
          }
        );
        const data = response.data;

        this.name = data.name || "";
        this.surname = data.surname || "";
        this.email = data.email || "";
        this.phone = data.phone || "";
        this.address = data.address || "";
      } catch (error) {
        console.error("Error fetching user data: ", error);
      }
    },
    async updateUserInfo() {
      try {
        await axios.patch(
          `http://localhost:5214/users/${this.userId}`,
          {
            name: this.name,
            surname: this.surname,
            phone: this.phone,
            address: this.address,
          },
          {
            headers: {
              Authorization: `Bearer ${this.token}`,
            },
          }
        );

        alert("Your information has been updated!");
        this.$router.push({
          name: "UserProfile",
          params: { userId: this.userId },
        });
      } catch (error) {
        console.error("Error updating user data: ", error);
      }
    },

    goBack() {
      this.$router.go(-1);
    },
  },
};
</script>

<style scoped>
.edit-profile {
  max-width: 400px;
  margin: auto;
  padding: 20px;
  border-radius: 8px;
  background-color: #5d2d05;
  color: #faebd7;
  text-align: center;
}

h1 {
  color: #faebd7;
}

form {
  display: grid;
  grid-template-columns: 1fr;
  gap: 15px;
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
}

button:hover {
  background-color: #d5b28b;
}

.return-btn {
  background-color: #d5b28b;
  color: #5d2d05;
  margin-top: 20px;
  width: 100%;
}

.return-btn:hover {
  background-color: #faebd7;
  color: #5d2d05;
}
</style>
