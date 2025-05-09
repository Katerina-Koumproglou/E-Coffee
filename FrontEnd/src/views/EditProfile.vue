﻿<template>
    <div class="edit-profile">
        <h1>Edit Profile</h1>
        <form @submit.prevent="updateUserInfo">
            <div class="form-row">
                <div class="form-item">
                    <label for="name">Name:</label>
                    <input type="text" id="name" v-model="name" required />
                </div>
                <div class="form-item">
                    <label for="surname">Surname:</label>
                    <input type="text" id="surname" v-model="surname" required />
                </div>
            </div>
            <div class="form-row">
                <div class="form-item">
                    <label for="email">Email:</label>
                    <input type="email" id="email" v-model="email" required />
                </div>
                <div class="form-item">
                    <label for="phone">Phone number:</label>
                    <input type="tel" id="phone" v-model="phone" required />
                </div>
            </div>
            <div class="form-row">
                <div class="form-item">
                    <label for="address">Home address:</label>
                    <input type="text" id="address" v-model="address" required />
                </div>
                <div class="form-item">
                    <label for="password">Password:</label>
                    <input type="password" id="password" v-model="password" />
                </div>
            </div>
            <p v-if="successMessage" class="success-message">{{ successMessage }}</p>
            <div class="form-buttons">
                <button type="submit" class="save-btn">Sumbit</button>
                <button @click="goBack" class="return-btn">Back</button>
            </div>
        </form>
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
            password: "",
            token: localStorage.getItem("token"),
            userId: localStorage.getItem("userId"),
            successMessage: "",
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
                    `http://83.212.99.172:5214/users/${this.userId}`,
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
                    `http://83.212.99.172:5214/users/${this.userId}`,
                    {
                        name: this.name,
                        surname: this.surname,
                        email: this.email,
                        phone: this.phone,
                        address: this.address,
                        password: this.password ? this.password : undefined,
                    },
                    {
                        headers: {
                            Authorization: `Bearer ${this.token}`,
                        },
                    }
                );

                this.successMessage = "Your profile information has been updated successfully!";
            } catch (error) {
                console.error("Error updating user data: ", error);
                alert("There has been an error while updating your information. Please try again!");
            }
        },
        goBack() {
            this.successMessage = "";
            this.$router.go(-1);
        },
    },
};
</script>

<style scoped>
.success-message {
    color: #28a745;
    font-size: 1rem;
    margin-top: 10px;
}

    .edit-profile {
        max-width: 800px;
        margin: auto;
        padding: 20px;
        border-radius: 8px;
        background-color: #5d2d05;
        color: #faebd7;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        text-align: center;
    }

    h1 {
        font-size: 28px;
        margin-bottom: 20px;
        font-weight: 600;
        color: #faebd7;
    }

    form {
        display: grid;
        grid-template-columns: 1fr;
        gap: 20px;
    }

    .form-row {
        display: flex;
        justify-content: space-between;
        gap: 15px;
    }

    .form-item {
        flex: 1;
        display: flex;
        flex-direction: column;
        gap: 5px;
        text-align: left;
    }

        .form-item label {
            font-size: 1rem;
            color: #faebd7;
        }

        .form-item input {
            padding: 8px;
            border: 1px solid #faebd7;
            border-radius: 5px;
            font-size: 1rem;
            color: #333;
            background-color: #fafafa;
            width: 100%;
            transition: all 0.2s ease;
        }

            .form-item input:focus {
                outline: none;
                border-color: #faebd7;
                background-color: #fff;
            }

   

    .form-buttons {
        display: flex;
        justify-content: space-evenly;
        gap: 10px;
        margin-top: 20px;
    }

    button {
        background-color: #faebd7;
        color: #5d2d05;
        padding: 12px 20px; /* Μικρότερο padding */
        border: none;
        border-radius: 5px; /* Ελαφρώς στρογγυλεμένες γωνίες για πιο "ευχάριστο" στυλ */
        cursor: pointer;
        font-size: 16px; /* Μικρότερο μέγεθος γραμματοσειράς */
        width: 30%; /* Ίδια πλάτη για τα δύο κουμπιά */
        transition: background-color 0.2s ease, transform 0.2s ease;
        font-family: "EB Garamond", serif;
        gap: 10px;
	font-weight: bold;
    }

        button:hover {
            background-color: #d5b28b;
            transform: scale(1.05); 
        }

    .return-btn {
        background-color: #d5b28b;
        color: #5d2d05;
    }

        .return-btn:hover {
            background-color: #faebd7;
            color: #5d2d05;
        }

    /* Mobile Responsiveness */
    @media (max-width: 768px) {
        .edit-profile {
            padding: 15px;
        }

        .form-row {
            flex-direction: column;
        }

        .form-item input {
            font-size: 0.9rem;
        }

        button {
            font-size: 1rem;
        }
    }
</style>
