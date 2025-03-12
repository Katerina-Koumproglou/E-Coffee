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
                    <!--<th>Διαγραφή Προϊόντος</th>-->
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in cartItems" :key="item.id">
                    <td><img :src="item.image" :alt="item.name" class="product-image" /></td>
                    <td>{{ item.name }}</td>
                    <td>
                        <div class="quantity-container">
                            <!-- Μείωση της ποσότητας -->
                            <button class="quantity-btn" @click="decreaseQuantity(item)">&#8722;</button>
                            <!-- Εμφάνιση της ποσότητας -->
                            <input v-model="item.quantity" class="quantity-input" readonly />
                            <!-- Αύξηση της ποσότητας -->
                            <button class="quantity-btn" @click="increaseQuantity(item)">&#43;</button>
                        </div>
                    </td>



                    <td>{{ item.price }} €</td>
                    <td>{{ (item.price * item.quantity).toFixed(2) }} €</td>


                    <!--<td>
        <button @click="removeCartItem(item)">🗑️</button>
    </td>-->

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
        <button class="continue-button" @click="GoToPayment">Πληρωμή</button>
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
                if (!Array.isArray(this.cartItems)) {
                    return 0;
                }
                return this.cartItems.reduce((total, item) => {
                    const itemPrice = parseFloat(item.price) || 0;
                    const itemQuantity = parseInt(item.quantity) || 1;
                    return total + (itemPrice * itemQuantity);
                }, 0);
            }
        },
        methods: {
           methods: {
    increaseQuantity(item) {
        item.quantity++;  // Αύξηση της ποσότητας
        this.updateCartItem(item); // Ενημέρωση του καλαθιού με την νέα ποσότητα
    },
    decreaseQuantity(item) {
        if (item.quantity > 1) {
            item.quantity--;  // Μείωση της ποσότητας
            this.updateCartItem(item); // Ενημέρωση του καλαθιού με την νέα ποσότητα
        }
    }
}
,
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
                    console.error("Error fetching cart items:", error);
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
                    console.error("Error updating cart item:", error);
                }
            },

            // Μέθοδος για τη διαγραφή προϊόντος από το καλάθι
            async removeCartItem(item) {
                try {
                    const userId = localStorage.getItem("userId");
                    if (!userId) {
                        console.error("No userId found in localStorage");
                        return;
                    }

                    // Αποστολή αίτηματος διαγραφής στο backend
                    const response = await axios.delete(`http://localhost:5214/api/cart/${userId}/${item.id}`);
                    console.log("Response from delete API:", response);

                    if (response.status === 200) {
                        // Αν η διαγραφή είναι επιτυχής, αφαιρούμε το προϊόν από το cartItems
                        this.cartItems = this.cartItems.filter(cartItem => cartItem.id !== item.id);
                        console.log("Item removed successfully");
                    } else {
                        console.error("Error deleting cart item", response);
                    }
                } catch (error) {
                    console.error("Error removing cart item:", error);
                }
            },

            GoToPayment() {
                alert("Συνολικό Ποσό παραγγελίας: " + this.totalPrice.toFixed(2) + " €");
            }
        },
        mounted() {
            this.fetchCartItems();
        },

        async fetchCartItems() {
            try {
                const userId = localStorage.getItem("userId");
                if (!userId) {
                    console.error("No userId found in localStorage");
                    return;
                }

                const response = await axios.get(`http://localhost:5214/api/cart/${userId}`);
                this.cartItems = response.data;

                // Αν η ποσότητα είναι 0 ή δεν υπάρχει, ορίζουμε την ποσότητα σε 1
                this.cartItems.forEach(item => {
                    if (item.quantity || item.quantity < 1) {
                        item.quantity = 1;
                    }
                });
            } catch (error) {
                console.error("Σφάλμα κατά την αναζήτηση των προϊόντων του καλαθιού:", error);
            }
        }

    };
</script>



<style>
    .my-cart {
        margin: 10px;
        font-family: "EB Garamond", serif;
        font-size: 20px;
        text-align: center;
        color: #faebd7;
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
        font-family: "EB Garamond", serif;
        border: none;
        border-radius: 5px;
        font-size: 20px;
        cursor: pointer;
        text-align: center;
        color: #faebd7;
    }

    .delete-button {
        background-color: transparent;
        border: none;
        color: red;
        font-size: 30px;
        cursor: pointer;
    }

    table {
        width: 100%;
        border-collapse: collapse;
        background-color: #faebd7;
    }

    th,
    td {
        padding: 10px;
        text-align: center;
        border: 1px solid #6d3f3f;
        color: #d68000;
    }

    thead {
        background-color: #5D2D05;
        color: white;
    }

    tfoot {
        font-weight: bold;
    }
    .quantity-container {
        display: flex;
        align-items: center;
        justify-content: center;
        border: 2px solid #ccc;
        border-radius: 5px;
        background-color: #f5f5f5;
        width: 120px;
        padding: 5px;
    }

    .quantity-btn {
        background-color: #4CAF50;
        color: white;
        border: none;
        padding: 5px 10px;
        font-size: 18px;
        cursor: pointer;
        border-radius: 3px;
        transition: background-color 0.3s;
    }

        .quantity-btn:hover {
            background-color: #45a049;
        }

        .quantity-btn:active {
            background-color: #388e3c;
        }

    .quantity-input {
        width: 40px;
        text-align: center;
        font-size: 16px;
        border: none;
        background-color: transparent;
        color: #333;
        padding: 5px;
        outline: none;
        pointer-events: none; /* Αποκλείουμε την αλλαγή της τιμής μέσω του πληκτρολογίου */
    }


</style>