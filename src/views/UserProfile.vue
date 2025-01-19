<template>
    <div class="user-profile">
        <h1>User Profile</h1>
        <div v-if="userData" class="profile-details">
            <p><strong>Name:</strong> {{ userData.name }}</p>
            <p><strong>Surname:</strong> {{ userData.surname }}</p>
            <p><strong>Email:</strong> {{ userData.email }}</p>
            <p><strong>Phone:</strong> {{ userData.phone }}</p>
            <p><strong>Address:</strong> {{ userData.address }}</p>
        </div>
        <div v-else>
            <p>Loading user data...</p>
        </div>

        <div class="buttons">
            <button @click="logout">Logout</button>
            <button @click="goToEditProfile">Edit Profile</button>
        </div>
    </div>
</template>

<script>
    import { auth, db } from "@/firebase";
    import { doc, getDoc } from "firebase/firestore";

    export default {
        data() {
            return {
                userData: null, // Τα δεδομένα του χρήστη αποθηκεύονται εδώ
                userId: null,
            };
        },
        async mounted() {
            const user = auth.currentUser;
            if (user) {
                this.userId = user.uid;
                await this.loadUserData();
            } else {
                this.$router.push('/login'); // Αν δεν είναι συνδεδεμένος ο χρήστης, ανακατευθύνουμε στη σελίδα σύνδεσης
            }
        },
        methods: {
            async loadUserData() {
                try {
                    const userRef = doc(db, "users", this.userId);
                    const userDoc = await getDoc(userRef);
                    if (userDoc.exists()) {
                        this.userData = userDoc.data(); // Αποθήκευση των δεδομένων του χρήστη
                    } else {
                        console.error("No such document!");
                    }
                } catch (error) {
                    console.error("Error fetching user data: ", error);
                }
            },
            logout() {
                auth.signOut().then(() => {
                    this.$router.push('/'); // Ανακατεύθυνση στην αρχική σελίδα μετά το logout
                }).catch((error) => {
                    console.error("Error during logout: ", error);
                });
            },
            goToEditProfile() {
                this.$router.push({ name: 'EditProfile' }); // Ανακατεύθυνση στη σελίδα επεξεργασίας
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

        button:hover {
            background-color: #D5B28B;
        }
</style>
