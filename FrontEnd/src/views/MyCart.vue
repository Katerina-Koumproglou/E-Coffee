<template>
    <div class="my-cart">
        <h2>Το καλάθι σου!</h2>
        <table>
            <thead>
                <tr>
                    <th>Φωτογραφία</th>
                    <th>Προϊόν</th>
                    <th>Ποσότητα</th>
                    <th>Τιμή</th>
                    <th>Σύνολο</th>
                    <!--<th> Διαγραφή Προϊόντος</th>-->
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in cartItems" :key="item.id">
                    <td><img :src="item.image" :alt="item.name" class="product-image" /></td>
                    <td>{{ item.name }}</td>
                    <td>
                        <input type="number" v-model="item.quantity" min="1" @change="updateCartItem(item)" />
                    </td>
                    <td>{{ item.price }} €</td>
                    <td>{{ (item.price * item.quantity).toFixed(2) }} €</td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="4">Συνολικό Κόστος</td>
                    <td>{{ totalPrice.toFixed(2) }} €</td>
                </tr>
            </tfoot>
        </table>
        <br><br>
        <button class="continue-button" @click="GoToPayment">Προχωρήστε στην Πληρωμή</button>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: "MyCart",
        data() {
            return {
                cartItems: [],
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
                    if (!userId) {
                        console.error("No userId found in localStorage");
                        return;
                    }

                    const response = await axios.get(`http://localhost:5214/api/cart/${userId}`);
                    this.cartItems = response.data;
                } catch (error) {
                    console.error("Σφάλμα κατά την αναζήτηση των προϊόντων του καλαθιού:", error);
                }
            },

            async updateCartItem(item) {
                try {
                    const userId = localStorage.getItem("userId");
                    await axios.put(`http://localhost:5214/api/cart/${userId}`, {
                        pid: item.id,
                        quantity: item.quantity,
                    });
                } catch (error) {
                    console.error("Σφάλμα κατά την ενημέρωση του προϊόντος στο καλάθι:", error);
                }
            },

          
          
                GoToPayment() {
                    alert("Πληρωμή: " + this.totalPrice.toFixed(2) + " €");
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
        color: white;
    }

    th,
    td {
        padding: 10px;
        text-align: left;
        border: 1px solid #5D2D05;
        color: white;
    }

    thead {
        background-color: #5D2D05;
        color: white;
    }

    tfoot {
        font-weight: bold;
    }
</style>