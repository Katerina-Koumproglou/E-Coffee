<template>
    <div class="home">
        <div class="category-header">
            <h3>Ποικιλίες Καφέ</h3>
        </div>
        <ProductsDisplay :variety="variety" />
    </div>
</template>

<script>
export default {
    name: "VarietiesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const variety = inject('variety');
</script>