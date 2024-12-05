<template>
    <div>
      <h1>Realtime Database Example</h1>
      <input v-model="newMessage" placeholder="Enter a message" />
      <button @click="addMessage">Add Message</button>
  
      <p v-if="message">Message: {{ Message }}</p>
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
        messages: {},
      };
    },
    methods: {
      addMessage() {
        const messagesRef = ref(database, "Messages"); // Reference to "messages" node
        push(messagesRef, this.newmessage)
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
      const messageRef = ref(database, "Message");
      onValue(messageRef, (snapshot) => {
        this.Messages = snapshot.val() || {};
      });
    },
  };
  </script>
  
  <style scoped>
  /* Add styles here if necessary */
  </style>
  