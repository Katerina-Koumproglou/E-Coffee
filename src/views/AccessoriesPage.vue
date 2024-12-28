<template>
    <div class="home">
        <div class="category-header">
            <h3>Αξεσουάρ</h3>
        </div>
        <ProductsDisplay :variety="accessories" />
    </div>
</template>

<script>
export default {
    name: "AccessoriesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const accessories = inject('accessories');
</script>