<template>
    <div class="home">
        <div class="category-header">
            <h3>Ροφήματα</h3>
        </div>
        <ProductsDisplay :products="beverages" />
    </div>
</template>

<script>
export default {
    name: "BeveragesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const beverages = inject('beverages');
</script>