<template>
    <div v-if="product" class="details">
        <div class="product">
            <div class="img-container">
                <img :src="product.image" :alt="product.name">
            </div>
            <div class="details-container">
                <h1 class="name">{{ product.name }}</h1>
                <p><strong>Price:</strong> {{ product.price }} €</p>
                <p><strong>Brand:</strong> {{ product.brand }}</p>
                <button class="add-to-cart" @click="addToCart">Add to Cart</button>
            </div>
        </div>
    </div>
    <div v-else-if="loading" class="loading">
        <p>Loading product details...</p>
    </div>
    <div v-else class="error">
        <p>The product was not found!</p>
    </div>
</template>

<script>
    import { ref, onMounted } from 'vue';
    import { useRoute } from 'vue-router';
    import axios from 'axios';

    export default {
        name: 'ShowDetails',
        setup() {
            const route = useRoute();
            const product = ref(null);
            const loading = ref(true);

            const fetchProductBySlug = async () => {
                try {
                    const { category, slug } = route.params;
                    const response = await axios.get(`http://83.212.99.172:5214/products/${category}/${slug}`);
                    product.value = response.data;
                } catch (error) {
                    console.error("Σφάλμα κατά τη φόρτωση του προϊόντος:", error);
                } finally {
                    loading.value = false;
                }
            };

            const addToCart = async () => {
                try {
                    const userId = localStorage.getItem("userId");
                    if (!userId) {
                        alert("You have to log in first!");
                        return;
                    }

                    const response = await axios.post("http://83.212.99.172:5214/api/cart/add", {
                        userId: parseInt(userId),
                        productId: product.value.id
                    });

                    alert("The product was added to the cart",response.data.message);
                } catch (error) {
                    alert(error.response?.data?.message || "An error occured.");
                }
            };

            onMounted(fetchProductBySlug);

            return {
                product, loading, addToCart
            };
        }
    };
</script>



<style scoped>
    .loading,
    .error {
        text-align: center;
        font-size: 24px;
        background-color: #fff;
    }

    .details {
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 20px;
        min-height: 80vh;
        background-size: cover;
    }

    .product {
        display: flex;
        align-items: center;
        max-width: 1200px;
        width: 100%;
        padding: 20px;
        border-radius: 8px;
        background-color: #fff;
    }

    .img-container img {
        max-width: 100%;
        width: 400px;
        height: auto;
        object-fit: cover;
    }

    .details-container {
        margin-left: 22px;
        color: #5D2D05;
    }

        .details-container p {
            font-size: 20px;
            margin: 8px 0;
        }

    .add-to-cart {
        padding: 14px 28px;
        border-radius: 5px;
        background-color: #FAEBD7;
        color: #5D2D05;
        border: 1px solid transparent;
        transition: .3s;
        font-size: 16px;
        cursor: pointer;
        margin-top: 20px;
        border-color: #5D2D05;
        transition: background-color 0.3s ease;
        font-family: "EB Garamond", serif;
    }

        .add-to-cart:hover {
            background-color: #5D2D05;
            color: #FAEBD7;
            font-family: "EB Garamond", serif;
            transition: background-color 0.3s ease, color 0.3s ease;
            border-color: #FAEBD7;
        }
</style>
