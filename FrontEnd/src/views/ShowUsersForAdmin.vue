<template>
    <div class="registered-users">
        <h1>Registered Users</h1>
        <div v-if="getOnlyUsers.length > 0">
            <div v-for="user in getOnlyUsers" :key="user.id" class="user-profile">
                <h2>User Profile with ID: {{ user.id }}</h2>
                <p><strong>Name:</strong> {{ user.name }}</p>
                <p><strong>Surname:</strong> {{ user.surname }}</p>
                <p><strong>Email:</strong> {{ user.email }}</p>
                <p><strong>Phone:</strong> {{ user.phone }}</p>
                <p><strong>Address:</strong> {{ user.address }}</p>
            </div>
        </div>
        <div v-else-if="loading">
            <p>Loading users...</p>
        </div>
        <div v-else-if="errorMessage">
            <p class="error">{{ errorMessage }}</p>
        </div>
        <div>
            <!-- Return Button -->
            <button @click="goBack" class="return-btn">Return</button>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                users: [],
                errorMessage: "",
                loading: true,
            };
        },
        async mounted() {
            try {
                const response = await axios.get("http://localhost:5214/users", {
                    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
                });

                console.log("API response: ", response.data);
                this.users = response.data;
            } catch (error) {
                this.errorMessage = "Failed to retrieve users.";
            } finally {
                this.loading = false;
            }
        },
        computed: {
            getOnlyUsers() {
                return this.users.filter(user => user.role === "User");
            },
        },
        methods: {
            goBack() {
                this.$router.back();
            },
        },
    };
</script>

<style scoped>
    .loading,
    .error {
        color: #ff6b6b;
        font-weight: bold;
        text-align: center;
    }

    .registered-users {
        max-width: 1000px;
        margin: auto;
        padding: 20px;
        border-radius: 10px;
        background-color: #faebd7;
        color: #5d2d05;
        margin-bottom: 20px;
    }

    h1 {
        text-align: center;
        font-weight: bold;
        margin-bottom: 20px;
    }

    .user-profile {
        background-color: white;
        margin-bottom: 30px;
        border: 1px solid #5d2d05;
        border-radius: 10px;
        padding: 20px;
        font-size: 17px;
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
    .return-btn {
        background-color: #5d2d05;
        color: #d5b28b;
        margin-top: 20px;
        width: 100%;
    }
</style>
