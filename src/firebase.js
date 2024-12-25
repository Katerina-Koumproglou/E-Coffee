// src/firebase.js
import { initializeApp } from "firebase/app";
// import { getDatabase } from "firebase/database";
import { getFirestore } from "firebase/firestore";

// Your Firebase configuration object
const firebaseConfig = {
  apiKey: "AIzaSyDDa4uwCloPx0gUu_lN7ftny3PmTrDTIFg",
  authDomain: "e-coffee-1ef6c.firebaseapp.com",
  databaseURL:
    "https://e-coffee-1ef6c-default-rtdb.europe-west1.firebasedatabase.app/",
  projectId: "e-coffee-1ef6c",
  storageBucket: "e-coffee-1ef6c.firebasestorage.app",
  messagingSenderId: "23178920731",
  appId: "1:23178920731:web:9cc295a68323ca710b09be",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

// // Get a reference to the database
// const database = getDatabase(app);

// Initialize Cloud Firestore and get a reference to the service
const db = getFirestore(app);

// export { database };
export { db };
