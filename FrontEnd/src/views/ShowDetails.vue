<template>
    <div class="details" v-if="product">
        <div class="product">
            <div class="img-container">
                <img :src="product.image" :alt="product.name">
            </div>
            <div class="details-container">
                <div class="product-details">
                    <h1 class="name">{{ product.name }}</h1>
                    <!-- <span class="price">€{{ product.price }}</span> -->
                    <p><strong>Τιμή: </strong> {{ product.price }} €</p>
                    <p><strong>Μάρκα: </strong> {{ product.brand }}</p>
                    <button class="add-to-cart" @click="addToCart">Προσθήκη στο Καλάθι</button>
                </div>
            </div>
        </div>
    </div>
    <div v-else-if="loading" class="loading">
        <p>Loading product details...</p>
    </div>
    <div v-else class="error">
        <p>Product not found!</p>
    </div>
</template>

<script>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { getAccessoryBySlug } from '@/database';

export default {
    name: 'ShowDetails',
    setup() {
        const route = useRoute();
        const product = ref(null);
        const loading = ref(true);

        const fetchProductBySlug = async () => {
            try {
                const productSlug = route.params.slug;
                console.log("Fetching product with slug: ", productSlug);
                product.value = await getAccessoryBySlug(productSlug);
                loading.value = false;

            } catch (error) {
                console.error("Error fetching product: ", error);
                loading.value = false;
            }
        };

        onMounted(() => {
            fetchProductBySlug();
        });

        return { product, loading };
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
}

.product-details {
    color: #5D2D05;
}

.product-details p {
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
}

.add-to-cart:hover {
    background-color: #5D2D05;
    color: #FAEBD7;
    transition: background-color 0.3s ease, color 0.3s ease;
    border-color: #FAEBD7;
}
</style>