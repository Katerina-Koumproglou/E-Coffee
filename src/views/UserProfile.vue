<template>
    <div class="user-profile">
        <h1>User Profile</h1>
        <form @submit.prevent="updateUserInfo" class="form-grid">
            <div class="form-item">
                <label for="name">Name:</label>
                <input type="text" id="name" v-model="name" />
            </div>
            <div class="form-item">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="email" disabled />
            </div>
            <div class="form-item">
                <label for="phone">Phone:</label>
                <input type="text" id="phone" v-model="phone" />
            </div>
            <div class="form-item">
                <label for="address">Address:</label>
                <input type="text" id="address" v-model="address" />
            </div>
            <button type="submit">Update Information</button>
        </form>
    </div>
</template>

<script>
    import { auth, db } from "@/firebase";
    import { doc, getDoc, updateDoc } from "firebase/firestore";

    export default {
        data() {
            return {
                name: "",
                email: "",
                phone: "",
                address: "",
                userId: null,
            };
        },
        async created() {
            try {
                const user = auth.currentUser;
                if (user) {
                    this.userId = user.uid;
                    await this.loadUserData();
                } else {
                    console.error("No user is logged in.");
                }
            } catch (error) {
                console.error("Error fetching user ID: ", error);
            }
        },
        methods: {
            async loadUserData() {
                try {
                    const userRef = doc(db, "users", this.userId);
                    const userDoc = await getDoc(userRef);
                    if (userDoc.exists()) {
                        const data = userDoc.data();
                        this.name = data.name || "";
                        this.email = data.email || "";
                        this.phone = data.phone || "";
                        this.address = data.address || "";
                    } else {
                        console.error("No such document!");
                    }
                } catch (error) {
                    console.error("Error fetching user data: ", error);
                }
            },
            async updateUserInfo() {
                try {
                    const userRef = doc(db, "users", this.userId);
                    await updateDoc(userRef, {
                        name: this.name,
                        phone: this.phone,
                        address: this.address,
                    });
                    alert("Your information has been updated!");
                } catch (error) {
                    console.error("Error updating user data: ", error);
                }
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
</style>
