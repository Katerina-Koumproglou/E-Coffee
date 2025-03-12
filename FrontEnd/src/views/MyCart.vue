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
                    <th>Διαγραφή</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="item in cartItems" :key="item.id">
                    <td><img :src="item.image" :alt="item.name" class="product-image" /></td>
                    <td>
                        <router-link :to="`/products/${item.category}/${item.slug}`" class="product-link">
                            {{ item.name }}
                        </router-link>
                    </td>
                    <td>
                        <div class="quantity-container">
                            <button class="quantity-btn" @click="decreaseQuantity(item)">&#8722;</button>
                            <input v-model="item.quantity" class="quantity-input" readonly />
                            <button class="quantity-btn" @click="increaseQuantity(item)">&#43;</button>
                        </div>
                    </td>
                    <td>{{ item.price }} €</td>
                    <td>{{ (item.price * item.quantity).toFixed(2) }} €</td>
                    <td>
                        <button class="remove-btn" @click="confirmRemoveFromCart(item)">
                            &#128465;
                        </button>
                    </td>
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

        <!-- Popup Modal -->
        <div v-if="showConfirmModal" class="modal-overlay">
            <div class="modal-content">
                <p>Είστε σίγουροι ότι θέλετε να διαγράψετε το προϊόν;</p>
                <button @click="removeFromCart(selectedItem)">Ναι</button>
                <button @click="cancelRemove">Όχι</button>
            </div>
        </div>
    </div>
</template>


<script>
    import axios from 'axios';
    export default {
        name: "MyCart",
        data() {
            return {
                cartItems: [],
                showConfirmModal: false,
                selectedItem: null, // Το προϊόν που θα διαγραφεί
            };
        },
        computed: {
            totalPrice() {
                return this.cartItems.reduce((total, item) => {
                    return total + (parseFloat(item.price) || 0) * (parseInt(item.quantity) || 1);
                }, 0);
            },
        },
        methods: {
            increaseQuantity(item) {
                item.quantity++;
                this.updateCartItem(item);
            },
            decreaseQuantity(item) {
                if (item.quantity > 1) {
                    item.quantity--;
                    this.updateCartItem(item);
                }
            },
            async fetchCartItems() {
                try {
                    const userId = localStorage.getItem("userId");
                    if (!userId) {
                        console.error("No userId found in localStorage");
                        return;
                    }
                    const response = await axios.get(`http://localhost:5214/api/cart/${userId}`);
                    this.cartItems = response.data.map(item => ({ ...item, quantity: item.quantity || 1 }));
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
            // Εμφανίζει το modal επιβεβαίωσης
            confirmRemoveFromCart(item) {
                this.selectedItem = item;
                this.showConfirmModal = true;
            },
            // Ακυρώνει τη διαγραφή και κλείνει το modal
            cancelRemove() {
                this.showConfirmModal = false;
                this.selectedItem = null;
            },
            // Διαγράφει το προϊόν από το καλάθι
            async removeFromCart(item) {
                try {
                    const userId = localStorage.getItem("userId");
                    await axios.delete(`http://localhost:5214/api/cart/remove`, {
                        data: { userId: parseInt(userId), productId: item.id }
                    });
                    this.cartItems = this.cartItems.filter(cartItem => cartItem.id !== item.id);
                    alert("Το προϊόν αφαιρέθηκε από το καλάθι.");
                    this.cancelRemove(); // Κλείνει το modal μετά τη διαγραφή
                } catch (error) {
                    console.error("Error removing item from cart:", error);
                }
            },
            GoToPayment() {
                alert("Συνολικό Ποσό παραγγελίας: " + this.totalPrice.toFixed(2) + " €");
            },
        },
        mounted() {
            this.fetchCartItems();
        },
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

    .product-link {
        text-decoration: none;
        color: #d68000;
        font-weight: bold;
    }

        .product-link:hover {
            text-decoration: underline;
            color: #b35900;
        }

    .continue-button {
        display: block;
        margin-top: 10px; /* Κοντά στον πίνακα */
        margin-left: auto; /* Κάνει το κουμπί να πηγαίνει στα δεξιά */
        margin-right: 0; /* Αφαιρεί οποιοδήποτε περιθώριο από τη δεξιά πλευρά */
        padding: 15px 30px; /* Μεγαλύτερη εσωτερική απόσταση για μεγαλύτερο κουμπί */
        background-color: #6d3f3f;
        color: #faebd7;
        font-size: 24px; /* Μεγαλύτερα γράμματα */
        font-family: "EB Garamond", serif;
        border: none;
        border-radius: 30px; /* Στρογγυλό κουμπί */
        cursor: pointer;
        text-align: center;
        transition: all 0.3s ease;
    }

        .continue-button:hover {
            background-color: #faebd7;
            color: #6d3f3f;
            transform: translateY(-4px);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        .continue-button:active {
            background-color: #4a2b02;
            color: #faebd7;
            transform: translateY(2px);
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }


    .remove-btn {
        background-color: transparent;
        border: none;
        cursor: pointer;
        color: #d68000;
        font-size: 35px; /* Μεγαλύτερο μέγεθος */
        transition: transform 0.3s, color 0.3s, box-shadow 0.3s;
        display: inline-block;
        padding: 10px;
        border-radius: 50%;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2); /* Ελαφριά σκιά για βάθος */
    }

        .remove-btn:hover {
            color: #b35900;
            transform: scale(1.1); /* Ελαφρύ zoom */
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.3); /* Ενίσχυση της σκιάς */
        }

        .remove-btn:active {
            transform: scale(1); /* Επιστροφή στο κανονικό μέγεθος όταν πατάμε */
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2); /* Ελαφριά σκιά κατά την ενεργοποίηση */
        }

        .remove-btn i {
            font-size: 35px; /* Αύξηση μεγέθους εικονιδίου */
            transition: color 0.3s;
        }

        .remove-btn:hover i {
            color: #ff6347; /* Αλλαγή χρώματος στο hover */
        }

    .modal-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 1000;
    }

    .modal-content {
        background-color: #faebd7;
        color:black;
        padding: 20px;
        border-radius: 10px;
        text-align: center;
        width: 300px;
    }

        .modal-content button {
            padding: 10px 20px;
            margin: 10px;
            background-color: #6d3f3f;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

    .continue-button {
        background-color: #6d3f3f;
        color: white;
        border: none;
        padding: 10px 20px;
        border-radius: 5px;
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
        border: 2px solid #6d3f3f; /* Σταθερό χρώμα του περιγράμματος */
        border-radius: 10px; /* Γωνίες πιο στρογγυλές */
        background-color: #fff;
        width: 160px; /* Μικρή αύξηση του πλάτους */
        padding: 10px;
        margin: 0 auto;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1); /* Προσθήκη σκιάς για βάθος */
        transition: box-shadow 0.3s, transform 0.3s; /* Εφέ κατά το hover */
    }

        .quantity-container:hover {
            box-shadow: 0 8px 20px rgba(0, 0, 0, 0.2); /* Ενίσχυση σκιάς στο hover */
            transform: scale(1.03); /* Ελαφρύ zoom όταν ο χρήστης το hover */
        }

    .quantity-btn {
        background-color: #6d3f3f;
        color: #faebd7;
        border: none;
        padding: 10px 15px;
        font-size: 20px;
        cursor: pointer;
        border-radius: 5px;
        transition: background-color 0.3s, transform 0.3s; /* Προσθήκη animation στο hover */
        margin: 0 5px;
    }

        .quantity-btn:hover {
            background-color: #5d2d05; /* Αλλαγή χρώματος στο hover */
            transform: scale(1.1); /* Ελαφρύ zoom στο hover */
        }

        .quantity-btn:active {
            background-color: #4a2b02; /* Σκοτεινότερο χρώμα όταν είναι πατημένο */
            transform: scale(1); /* Επιστροφή στο κανονικό μέγεθος όταν πατάμε */
        }

    .quantity-input {
        width: 50px;
        text-align: center;
        font-size: 18px;
        border: 1px solid #ccc;
        background-color: #f8f8f8;
        color: #333;
        padding: 8px;
        border-radius: 5px;
        outline: none;
        transition: background-color 0.3s, border-color 0.3s;
    }

        .quantity-input:focus {
            background-color: #fff;
            border-color: #6d3f3f; /* Έντονη αλλαγή χρώματος στα borders */
        }

        .quantity-input[readonly] {
            background-color: #f8f8f8;
            color: #333;
            pointer-events: none;
        }
</style>