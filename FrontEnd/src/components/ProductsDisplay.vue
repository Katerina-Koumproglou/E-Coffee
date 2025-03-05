<template>
    <div>
        <div class="container">
            <div v-if="products && products.length > 0" class="products">
                <div v-for="product in products" :key="product.id" class="single-product">
                    <div class="img-container">
                        <router-link :to="`/products/${product.category}/${product.slug}`">
                            <img :src="product.image" :alt="product.name">
                        </router-link>
                    </div>
                    <div class="product-container">
                        <h6 class="name">{{ product.name }}</h6>
                        <span class="price">€{{ product.price }}</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { defineComponent } from 'vue';

    export default defineComponent({
        name: 'ProductsDisplay',
    });
</script>

<script setup>
    import { defineProps, watchEffect } from 'vue';

    const props = defineProps({
        products: {
            type: Array,
            required: true,
        },
    });

    watchEffect(() => {
        console.log("Displaying products:", props.products);
    });
</script>

<style scoped>
    .img-container img {
        width: 300px;
        height: auto;
        max-width: 100%;
        background-color: #FFF;
    }

    .product-container {
        width: 300px;
        font-size: 30px;
        color: #FFF;
        margin-top: 10px;
    }

    .products {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-around;
        margin-block: 30px;
        gap: 50px;
    }
</style>
