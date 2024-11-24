<template>
  <div class="user-profile">
    <h1>Sign Up</h1>
    <form @submit.prevent="saveProfile" class="form-grid">
      <div class="form-item">
        <label for="name">Name:</label>
        <input type="text" id="name" v-model="user.name" />
        <span v-if="errors.name" class="error-message">{{ errors.name }}</span>
      </div>
      <div class="form-item">
        <label for="surname">Surname:</label>
        <input type="text" id="surname" v-model="user.surname" />
        <span v-if="errors.surname" class="error-message">{{ errors.surname }}</span>
      </div>
      <div class="form-item">
        <label for="email">Email:</label>
        <input type="email" id="email" v-model="user.email" />
        <span v-if="errors.email" class="error-message">{{ errors.email }}</span>
      </div>
        <div class="form-item">
          <label for="address">Confirm Email:</label>
          <input type="email" id="c_email" v-model="user.e_email" />
          <span v-if="errors.c_email" class="error-message">{{ errors.c_email }}</span>
       </div>
        <div class="form-item">
          <label for="address">Password:</label>
          <input type="password" id="password" v-model="user.password" />
          <span v-if="errors.password" class="error-message">{{ errors.password }}</span>
        </div>
                <div class="form-item">
          <label for="address">Confirm Password:</label>
          <input type="password" id="c_password" v-model="user.c_password" />
          <span v-if="errors.c_password" class="error-message">{{ errors.c_password }}</span>
        </div>
      <div class="form-item">
        <label for="address">Address:</label>
        <input type="text" id="address" v-model="user.address" />
        <span v-if="errors.address" class="error-message">{{ errors.address }}</span>
      </div>
        <div class="form-item">
  <label for="phone">Phone:</label>
 <input type="text" id="phone"  v-model="user.phone" placeholder="(+30) 69X-XXX-XXXX"/>
  <span v-if="errors.phone" class="error-message">{{ errors.phone }}</span>
</div>
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      user: {
        name: '',
        surname: '',
        email: '',
        c_email:'',
        password:'',
           c_password:'',
        address: ''
      },
      errors: {
        name: '',
        surname: '',
        email: '',
         c_email:'',
        password:'',
         c_password:'',
        address: ''
      }
    };
  },
  methods: {
    saveProfile() {
      // Καθαρισμός μηνυμάτων λάθους πριν τον νέο έλεγχο
      this.errors.name = '';
      this.errors.surname = '';
      this.errors.email = '';
      this.errors.address = '';

      // Έλεγχος αν τα πεδία είναι κενά
      if (!this.user.name) {
        this.errors.name = 'Required';
      }
      if (!this.user.surname) {
        this.errors.surname = 'Required';
      }
      if (!this.user.email) {
        this.errors.email = 'Required';
      }
      if (!this.user.address) {
        this.errors.address = 'Required';
      }

      // Εάν δεν υπάρχουν λάθη, εμφάνιση μηνύματος επιτυχίας
      if (!this.errors.name && !this.errors.surname && !this.errors.email && !this.errors.address) {
        alert('Success data entry!');
      }
    }
  }
};
</script>

<style scoped>
.user-profile {
    max-width: 600px;
    margin: auto;
    font-family: 'EB Garamond', serif;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    background-color: #5d2d05;
    color: #faebd7;
}

.form-grid {
    display: grid;
    grid-template-columns: 1fr 1fr; /* Δύο στήλες */
    gap: 20px; /* Απόσταση μεταξύ των πεδίων */
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
