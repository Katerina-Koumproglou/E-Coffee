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
          <td><img :src="require(`@/assets/images/illy-classico-250.png`)" :alt="'Illy Coffee'" /></td>
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

export default {
  name: "MyCart",
  data() {
    return {
      cartItems: [
        { id: 1, name: "Product A", quantity: 2, price: 25.5, image: {src:"@/assets/images/illy-classico-250.png", alt:"Illy Coffee"}},
        { id: 2, name: "Product B", quantity: 1, price: 15.0, image: "https://x2e5r7b9.rocketcdn.me/wp-content/uploads/2018/11/logo-pada.png" },
        { id: 3, name: "Product C", quantity: 3, price: 10.0, image: "https://x2e5r7b9.rocketcdn.me/wp-content/uploads/2018/11/logo-pada.png" }
      ]
    };
  },
  computed: {
    totalPrice() {
      return this.cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
    }
  },

  methods: {
    GoToPayment() {
      alert("Proceeding to Payment...");
    }
  }
};

</script>

<style>
.my-cart {
  margin: 20px;
  font-family: Arial, sans-serif;
}

.product-image {
  width: 30px;
  height: 30px;
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
}

th,
td {
  padding: 10px;
  text-align: left;
  border: 1px solid #ddd;
  background-color: #5D2D05;
}

td img{
  max-width: 100px;
  height: auto;
  display: block;
  margin-left: auto;
  margin-right: auto;
}

thead {
  background-color: #f4f4f4;
}

tfoot {
  font-weight: bold;
}
</style>
