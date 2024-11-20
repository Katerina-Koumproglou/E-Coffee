<template>
  <div>
    <AppHeader />
    <ImageSlider />
    <ProductsDisplay />
    <AppFooter />
  </div>
</template>

<script setup>
import AppFooter from './components/AppFooter.vue';
import AppHeader from './components/AppHeader.vue';
import ImageSlider from './components/ImageSlider.vue';
import ProductsDisplay from './components/ProductsDisplay.vue';


//import { RouterLink, RouterView} from vue-router
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

<style scoped></style>