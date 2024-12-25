<template>
  <div class="home">
    <ImageSlider />
    <ProductsDisplay :variety="variety" />
  </div>
</template>

<script>
export default {
  name: "HomePage"
};
</script>

<script setup>
import ImageSlider from '@/components/ImageSlider.vue';
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const variety = inject('variety');
</script>