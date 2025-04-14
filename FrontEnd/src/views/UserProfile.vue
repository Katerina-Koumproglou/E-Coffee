<template>
    <div class="user-profile">
        <div v-if="userData && !errorMessage" class="profile-details">
            <h1>Your User Profile</h1>
            <div class="profile-item">
                <strong>Name:</strong>
                <p class="profile-text">{{ userData.name }}</p>
            </div>
            <div class="profile-item">
                <strong>Surname:</strong>
                <p class="profile-text">{{ userData.surname }}</p>
            </div>
            <div class="profile-item">
                <strong>Email:</strong>
                <p class="profile-text">{{ userData.email }}</p>
            </div>
            <div class="profile-item">
                <strong>Phone number:</strong>
                <p class="profile-text">{{ userData.phone }}</p>
            </div>
            <div class="profile-item">
                <strong>Home address:</strong>
                <p class="profile-text">{{ userData.address }}</p>
            </div>
        </div>

        <div v-else-if="loading" class="loading-message">
            <p>Please wait...</p>
        </div>

        <div v-else-if="errorMessage" class="error-message">
            <p>{{ errorMessage }}</p>
        </div>

        <div class="buttons" v-if="!loading">
            <button @click="logout" class="logout-btn">Log out</button>
            <button @click="goToEditProfile" :disabled="!userData" class="edit-btn">
                Edit Profile
            </button>
            <button v-if="userData && userData.role === 'Admin'" @click="goToShowUsers" class="admin-btn">
                Show Users
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
            const userId = localStorage.getItem("userId");
            if (!userId) {
                this.errorMessage = "No user ID found.";
                this.$router.push("/auth/login");
                return;
            }

            console.log("Recieved data for userId: ", userId);
            try {
                const response = await axios.get(
                    `http://83.212.99.172:5214/users/${userId}`,
                    {
                        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
                    }
                );

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
                localStorage.removeItem("userId");

                this.$router.push("/auth/login");
            },

            goToEditProfile() {
                this.$router.push({ name: "EditProfile" });
            },

            goToShowUsers() {
                this.$router.push({ name: "ShowUsersForAdmin" });
            }
        },
    };
</script>

<style scoped>
    .user-profile {
        max-width: 650px;
        margin: auto;
        padding: 30px;
        border-radius: 12px;
        background-color: #5d2d05;
        color: #faebd7;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    }

    h1 {
        text-align: center;
        color: #faebd7;
        font-size: 36px;
        margin-bottom: 20px;
        font-weight: bold;
    }

    .profile-details {
        margin-bottom: 40px;
    }

    .profile-item {
        display: flex;
        justify-content: space-between;
        margin: 15px 0;
    }

        .profile-item strong {
            font-size: 1.2rem;
            color: #faebd7;
            width: 40%;
        }

    .profile-text {
        font-size: 1.2rem;
        color: #d5b28b;
        width: 55%;
        line-height: 1.6;
    }

    .error-message {
        color: #ff6b6b;
        font-weight: bold;
        text-align: center;
        font-size: 1.2rem;
    }

    .loading-message {
        text-align: center;
        font-size: 1.2rem;
        color: #d5b28b;
    }

    .buttons {
        display: flex;
        justify-content: space-between;
        margin-top: 20px;
    }

    button {
        background-color: #faebd7;
        color: #5d2d05;
        font-family: "EB Garamond", serif;
        padding: 12px 20px;
        border: none;
        border-radius: 8px;
        cursor: pointer;
        font-size: 1.1rem;
	font-weight: bold;
        width: 30%;
    }

        button:disabled {
            background-color: #b2a59d;
            cursor: not-allowed;
        }

        button:hover {
            background-color: #d5b28b;
        }

    .logout-btn {
        background-color: #ff6b6b;
    }

        .logout-btn:hover {
            background-color: #ff4d4d;
        }

    .edit-btn {
        background-color: #ffcc99;
    }

        .edit-btn:hover {
            background-color: #e6a676;
        }

    .admin-btn {
        background-color: #76d7c4;
    }

        .admin-btn:hover {
            background-color: #48c9b0;
        }

    @media (max-width: 768px) {
        .buttons {
            flex-direction: column;
            gap: 10px;
        }

        .profile-item {
            flex-direction: column;
            align-items: flex-start;
        }

            .profile-item strong {
                width: auto;
                margin-bottom: 5px;
            }

        .profile-text {
            width: auto;
        }
    }
</style>
