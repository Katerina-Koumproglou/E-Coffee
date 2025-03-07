<template>
  <div class="my-cart">
    <h2>Το καλάθι σου!</h2>
    <table>
      <thead>
        <tr>
          <th>Photo</th>
          <th>Product</th>
          <th>Quantity</th>
          <th>Price</th>
          <th>Total</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in cartItems" :key="item.id">
          <td><img :src="item.image" :alt="item.name" class="product-image" /></td>
          <td>{{ item.name }}</td>
          <td>{{ item.quantity }}</td>
          <td>\${{ item.price.toFixed(2) }}</td>
          <td>\${{ (item.price * item.quantity).toFixed(2) }}</td>
        </tr>
      </tbody>
      <tfoot>
        <tr>
          <td colspan="4">Total Price</td>
          <td>\${{ totalPrice.toFixed(2) }}</td>
        </tr>
      </tfoot>
    </table>
    <br><br>
    <button class="continue-button" @click="GoToPayment">Proceed to Payment</button>
  </div>
</template>

<script>
import { getCartItems } from '@/database';

export default {
  name: "MyCart",
  data() {
    return {
      cartItems: []
    };
  },
  computed: {
    totalPrice() {
      return this.cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
    }
  },
  methods: {
    async fetchCartItems() {
      try {
        const userId = localStorage.getItem("userId");
        const cartItems = await getCartItems(userId);
        this.cartItems = cartItems.map(item => ({
          id: item.id,
          name: item.name,
          quantity: 1, // Assuming quantity is 1 for simplicity
          price: item.price,
          image: item.image
        }));
      } catch (error) {
        console.error("Error fetching cart items:", error);
      }
    },
    GoToPayment() {
      alert("Proceeding to Payment...");
    }
  },
  mounted() {
    this.fetchCartItems();
  }
};
</script>

<style>
.my-cart {
  margin: 20px;
  font-family: Arial, sans-serif;
  color: white;
}

.product-image {
  width: 100px;
  height: auto;
  object-fit: cover;
}

.continue-button {
  display: block;
  margin-top: 20px;
  margin-left: auto;
  padding: 10px 20px;
  background-color: #6d3f3f;
  color: white;
  border: none;
  border-radius: 5px;
  font-size: 16px;
  cursor: pointer;
  text-align: right;
}

table {
  width: 100%;
  border-collapse: collapse;
  color:white;
}

th,
td {
  padding: 10px;
  text-align: left;
  border: 1px solid #5D2D05;
  color:white;
}

thead {
  background-color: #5D2D05;
  color: white;
}

tfoot {
  font-weight: bold;
}
</style>