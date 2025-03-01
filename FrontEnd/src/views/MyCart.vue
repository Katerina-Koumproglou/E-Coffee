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
import { getProductById } from '@/database';

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
    async fetchProductById(id) {
      try {
        console.log("Fetching product by ID: ", id);
        const product = await getProductById(id);
        if(!product) {
          console.error("Product didn't return from API");
          return;
        }
        console.log('Product fetched: ', product);
        this.cartItems.push({
          id: product.id,
          name: product.name,
          quantity: 1, 
          price: product.price,
          image: product.image 
        });
      } catch (error) {
        console.error("Error fetching product by ID: ", error);
      }
    },
    GoToPayment() {
      alert("Proceeding to Payment...");
    }
  },
  mounted() {
    console.log("MyCart component mounted");
    this.fetchProductById(17); // Fetch product with ID 17
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