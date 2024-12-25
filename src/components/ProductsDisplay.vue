<template>
    <div>
        <div class="container">
            <div class="category-header">
                <h3>Ποικιλίες Καφέ</h3>
            </div>

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
            <button class="btn">View More</button>
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
.category-header h3 {
    text-align: center;
    font-size: 2rem;
    color: #FAEBD7;
    margin-bottom: 50px;
}

.img-container img {
    width: 300px;
    height: auto;
    max-width: 100%;
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

.btn {
    margin-top: 25px;
    padding: 15px 30px;
    font-size: 16px;
    background: #FAEBD7;
    color: #5D2D05;
    border: 1px solid #5D2D05;
    border-radius: 25px;
    transition: .3s;
    cursor: pointer;
    display: flex;
    justify-content: center;
    align-items: center;
    margin-left: auto;
    margin-right: auto;
    margin-bottom: 30px;
    box-sizing: border-box;
}

.btn:hover {
    background-color: transparent;
    color: #FAEBD7;
    transition: background-color 0.3s ease, color 0.3s ease;
    border-color: #FAEBD7;
}
</style>