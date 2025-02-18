<template>
    <div class="home">
        <div class="category-header">
            <h3>Μηχανές Καφέ</h3>
        </div>
        <ProductsDisplay :products="machines" />
    </div>
</template>

<script>
export default {
    name: "MachinesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const machines = inject('machines');
</script>