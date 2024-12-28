<template>
    <div>
        <h1>Realtime Database Example</h1>
        <input v-model="newMessage" placeholder="Enter a message" />
        <button @click="addMessage">Add Message</button>

        <p v-if="message">Message: {{ message }}</p>
        <ul>
            <li v-for="(message, key) in messages" :key="key">
                {{ message }}
            </li>
        </ul>
    </div>
</template>

<script>
    import { ref, push, onValue } from "firebase/database";
    import { database } from "@/firebase";

    export default {
        name: "MyDatabase",
        data() {
            return {
                newMessage: "",
                message: "", // Για την εμφάνιση του "Message"
                messages: {}, // Για τη λίστα των μηνυμάτων
            };
        },
        methods: {
            addMessage() {
                const messagesRef = ref(database, "Messages");
                push(messagesRef, this.newMessage)
                    .then(() => {
                        alert("Message added successfully!");
                        this.newMessage = "";
                    })
                    .catch((error) => {
                        console.error("Error adding message:", error);
                    });
            },
        },
        mounted() {
            // Για το message
            const messageRef = ref(database, "message");

            onValue(messageRef, (snapshot) => {
                this.message = snapshot.val() || ""; // Ενημερώνει τη μεταβλητή "message"
            });

            // Για τη λίστα των μηνυμάτων
            const messagesRef = ref(database, "Messages");
            onValue(messagesRef, (snapshot) => {
                this.messages = snapshot.val() || {}; // Ενημερώνει τη μεταβλητή "messages"
            });
        },
    };
</script>

<style scoped>
    /* Add styles here if necessary */
</style>
