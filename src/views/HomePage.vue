<template>
  <div class="home">
    <ImageSlider />
    <ProductsDisplay />
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
</script>

<style>
.btn {
  margin-top: 25px;
  padding: 15px 30px;
  font-size: 16px;
  background: #FAEBD7;
  border: none;
  border-radius: 25px;
  transition: .3s;
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 30px;
}
</style>