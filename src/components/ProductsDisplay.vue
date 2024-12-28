<template>
    <div>
        <div class="container">
            <div class="products">
                <div v-for="product in variety" :key="product.id" class="single-product">
                    <div class="img-container">
                        <img :src="product.image" :alt="product.name">
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
    name: 'ProductsDisplay'
})
</script>

<script setup>
import { onMounted } from 'vue';
onMounted(() => {
    console.log('MMOUNTED>>>>>>')
})

import { defineProps } from 'vue';
defineProps({
    variety: {
        type: Array,
        required: true,
    },
});
</script>

<style>
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