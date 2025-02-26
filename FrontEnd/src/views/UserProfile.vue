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
            <button @click="goToEditProfile" :disabled="!userData">Edit Profile</button>
        </div>
    </div>
</template>

<script>
import axios from "axios";

export default {
    props: ['userId'],

    data() {
        return {
            userData: null,
            loading: true,
            errorMessage: "",
        };
    },
    async mounted() {
        // const token = localStorage.getItem("token");
        // if (!token) {
        //     this.errorMessage = "User is not yet logged in.";
        //     setTimeout(() => this.$router.push("/login"), 3000);
        // }

        const userId = this.userId || this.$route.params.userId;
        if (!userId) {
            this.errorMessage = "No user ID found.";
            return;
        }

        console.log('Recieved data for userId: ', userId);
        try {
            const response = await axios.get(`https://localhost:5214/users/${this.userId}`);

            this.userData = response.data;
        } catch (error) {
            this.errorMessage = "Failed to retrieve user data.";
        } finally {
            this.loading = false;
        }
    },
    methods: {
        // logout() {
        //     this.$router.push("/auth/login");
        //     // auth.signOut()
        //     //     .then(() => this.$router.push("/"))
        //     //     .catch((error) => {
        //     //         console.error("Error during logout:", error);
        //     //         this.errorMessage = "Failed to log out. Please try again.";
        //     //     });
        // },
        // goToEditProfile() {
        //     this.$router.push({ name: "EditProfile" });
        // },
    },
};
</script>

<style scoped>
.user-profile {
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
    background-color: #FAEBD7;
    color: #5D2D05;
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
    background-color: #D5B28B;
}
</style>
