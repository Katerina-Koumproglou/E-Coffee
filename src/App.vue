<template>
  <div id="nav">
    <h1>APP</h1>
    <router-link to="/">HomePage</router-link>
    <router-link to="/mycard">MyCard</router-link>
    <router-link to="/signup">SignUp</router-link>
  </div>
  <div class="container">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "App"
};
</script>

<script setup>

//import CoffeeVariety from './components/CoffeeVariety.vue';
//import HomePage from './views/HomePage.vue';
//import MyCard from './views/MyCard.vue';

</script>
<style>
.container {
  max-width: calc(1400px - 120px);
  width: 100%;
  margin: auto;
}
</style>
<style scoped></style>