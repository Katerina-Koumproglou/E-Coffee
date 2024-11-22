<template>
    <div>
        <AppHeader />
        <ProductsDisplay />
        <AppFooter />
    </div>
</template>

<script setup>
import AppFooter from './components/AppFooter.vue';
import AppHeader from './components/AppHeader.vue';
import ProductsDisplay from './ProductsDisplay.vue';
</script>

<script>
export default {
    name: "CoffeeVariety"
};
</script>