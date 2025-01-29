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
    import { auth, db } from "@/firebase";
    import { doc, getDoc, updateDoc } from "firebase/firestore";  // ���������� �� getDoc

    export default {
        data() {
            return {
                name: "",
                surname: "",
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
                    const userDoc = await getDoc(userRef);  // ��������������� �� getDoc ��� �� ���������� �� ��������
                    if (userDoc.exists()) {
                        const data = userDoc.data();
                        this.name = data.name || "";
                        this.surname = data.surname || "";
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
                        surname: this.surname,
                        phone: this.phone,
                        address: this.address,
                    });
                    alert("Your information has been updated!");
                    this.$router.push({ name: "UserProfile" });  // ��������� ��� ������ ������
                } catch (error) {
                    console.error("Error updating user data: ", error);
                }
            },

            // Method to go back to the previous page
            goBack() {
                this.$router.go(-1);  // �������� ���� ����������� ������
            }
        },
    };
</script>

<style scoped>
    .edit-profile {
        max-width: 400px;
        margin: auto;
        padding: 20px;
        border-radius: 8px;
        background-color: #5D2D05;
        color: #FAEBD7;
        text-align: center;
    }

    h1 {
        color: #FAEBD7;
    }

    form {
        display: grid;
        grid-template-columns: 1fr;
        gap: 15px;
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

    .return-btn {
        background-color: #D5B28B;
        color: #5D2D05;
        margin-top: 20px;
        width: 100%;
    }

        .return-btn:hover {
            background-color: #FAEBD7;
            color: #5D2D05;
        }
</style>