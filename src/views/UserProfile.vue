<template>
    <div class="user-profile">
        <h1>User Profile</h1>
        <div v-if="userData && !errorMessage" class="profile-details">
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
    import { auth, db } from "@/firebase";
    import { doc, getDoc } from "firebase/firestore";

    export default {
        data() {
            return {
                userData: null,
                userId: null,
                loading: true,
                errorMessage: "",
            };
        },
        async mounted() {
            const user = auth.currentUser;
            if (user) {
                this.userId = user.uid;
                await this.loadUserData();
            } else {
                this.errorMessage = "User is not logged in. Redirecting to login page.";
                setTimeout(() => this.$router.push("/login"), 3000);
            }
        },
        methods: {
            async loadUserData() {
                try {
                    const userRef = doc(db, "users", this.userId);
                    const userDoc = await getDoc(userRef);
                    if (userDoc.exists()) {
                        this.userData = userDoc.data();
                    } else {
                        this.errorMessage = `No user data found for UID: ${this.userId}`;
                    }
                } catch (error) {
                    this.errorMessage = "Failed to fetch user data.";
                    console.error("Error fetching user data:", error);
                } finally {
                    this.loading = false;
                }
            },
            logout() {
                auth.signOut()
                    .then(() => this.$router.push("/"))
                    .catch((error) => {
                        console.error("Error during logout:", error);
                        this.errorMessage = "Failed to log out. Please try again.";
                    });
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
