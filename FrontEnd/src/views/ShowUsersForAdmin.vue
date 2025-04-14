<template>
    <div class="registered-users">
        <h1>Signed Up Users</h1>
        <div v-if="getOnlyUsers.length > 0">
            <div v-for="user in getOnlyUsers" :key="user.id" class="user-profile">
                <h2>User (ID: {{ user.id }})</h2>
                <div class="user-details">
                    <p><strong>Name:</strong> {{ user.name }}</p>
                    <p><strong>Surname:</strong> {{ user.surname }}</p>
                    <p><strong>Email:</strong> <a :href="'mailto:' + user.email">{{ user.email }}</a></p>
                    <p><strong>Phone number:</strong> {{ user.phone }}</p>
                    <p><strong>Home address:</strong> {{ user.address }}</p>
                </div>
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
            <button @click="goBack" class="return-btn">Back</button>
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
                const response = await axios.get("http://83.212.99.172:5214/users", {
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
        font-size: 1.2rem;
    }

    .registered-users {
        max-width: 1000px;
        margin: auto;
        padding: 20px;
        border-radius: 10px;
        background-color: #5d2d05;
        color: #faebd7;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    h1 {
        text-align: center;
        font-size: 32px;
        font-weight: bold;
        margin-bottom: 30px;
        color: #faebd7;
    }

    .user-profile {
        background-color: #fff;
        margin-bottom: 20px;
        border: 1px solid #faebd7;
        border-radius: 8px;
        padding: 20px;
        font-size: 16px;
        color: #333;
        transition: transform 0.2s ease, box-shadow 0.2s ease;
    }

        .user-profile:hover {
            transform: scale(1.02);
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

    .user-details p {
        margin: 12px 0;
        font-size: 1rem;
        line-height: 1.6;
        color: #555;
    }

    .user-details strong {
        color: #5d2d05;
        font-weight: 600;
    }

    .user-details a {
        color: #5d2d05;
        text-decoration: none;
    }

        .user-details a:hover {
            text-decoration: underline;
        }

    button {
        background-color: #faebd7;
        color: #5d2d05;
        padding: 12px 18px;
        border: none;
        border-radius: 5px;
        cursor: pointer;
        font-size: 1.1rem;
        width: 100%;
        transition: background-color 0.2s ease, transform 0.2s ease;
    }

        button:hover {
            background-color: #d5b28b;
            transform: scale(1.05);
        }

    .return-btn {
        background-color: #5d2d05;
        color: #faebd7;
        margin-top: 20px;
        width: auto;
        padding: 10px 20px;
        font-size: 1.1rem;
        display: inline-block;
    }

        .return-btn:hover {
            background-color: #d5b28b;
        }
</style>
