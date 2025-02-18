<template>
    <div class="home">
        <div class="category-header">
            <h3>Κάψουλες Καφέ</h3>
        </div>
        <ProductsDisplay :products="capsules" />
    </div>
</template>

<script>
export default {
    name: "CapsulesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const capsules = inject('capsules');
</script>