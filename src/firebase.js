// src/firebase.js
import { initializeApp } from "firebase/app";
import { getDatabase } from "firebase/database";

// Your Firebase configuration object
const firebaseConfig = {
    apiKey: "AIzaSyDncxx5UBjunUoJfpmeabiCGjML0MBK2j0",
    authDomain: "e-coffee-b640c.firebaseapp.com",
    databaseURL: "https://e-coffee-b640c-default-rtdb.europe-west1.firebasedatabase.app/",
    projectId: "e-coffee-b640c",
    storageBucket: "e-coffee-b640c.firebasestorage.app",
    messagingSenderId: "30734819850",
    appId: "1:30734819850:web:a9df1070a5d0a7324375f3"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

// Get a reference to the database
const database = getDatabase(app);

export { database };
