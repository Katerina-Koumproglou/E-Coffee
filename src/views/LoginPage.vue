<template>
    <div class="user-profile">
        <h1>Login</h1>
        <form @submit.prevent="saveProfile" class="form-grid">
            <div class="form-item">
                <label for="email">Email:</label>
                <input type="email" id="email" v-model="user.email" />
                <span v-if="errors.email" class="error-message">{{ errors.email }}</span>
            </div>
            <div class="form-item">
                <label for="password">Password:</label>
                <input type="password" id="password" v-model="user.password" />
                <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
            </div>
            <button type="submit">Login</button>
        </form>
    </div>
</template>

<script>
export default {
  data() {
    return {
      user: {
        email: '',
        password:''
      },
      errors: {
        email: '',
        password:'',
      }
    };
  },
  methods: {
    saveProfile() {
      // Καθαρισμός μηνυμάτων λάθους πριν τον νέο έλεγχο
      this.errors.email = '';

      // Έλεγχος αν τα πεδία είναι κενά
      if (!this.user.email) {
        this.errors.email = 'Required';
      }

      // Εάν δεν υπάρχουν λάθη, εμφάνιση μηνύματος επιτυχίας
      if (!this.errors.email) {
        alert('Welcome!');
      }
    }
  }
};
</script>

<style scoped>
    .user-profile {
        max-width: 700px;
        margin: auto;
        font-family: 'EB Garamond', serif;
        padding: 45px;
        border: 1px solid #ccc;
        border-radius: 8px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        background-color: #5d2d05;
        color: #faebd7;
    }

    .form-grid {
        display: grid;
        grid-template-columns: 1fr 1fr; /* Δύο στήλες */
        gap: 30px; /* Απόσταση μεταξύ των πεδίων */
    }

    .form-item {
        display: flex;
        flex-direction: column;
    }

    label {
        color: #faebd7;
        margin-bottom: 5px;
    }

    input {
        padding: 8px;
        font-size: 1rem;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        text-align: center;
        color: #5d2d05;
    }

    button {
        grid-column: span 2; /* Κάλυψη και των δύο στηλών */
        background-color: #faebd7;
        color: #5d2d05;
        border: none;
        padding: 10px;
        border-radius: 5px;
        cursor: pointer;
        margin-top: 10px;
    }

    .error-message {
        color: red;
        font-size: 0.9em;
    }
</style>
