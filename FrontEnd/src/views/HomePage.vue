<template>
  <div class="home">
    <ImageSlider />

    <!-- Coffee Variety Section -->
    <div class="category-header">
      <h3>Ποικιλίες Καφέ</h3>
    </div>
    <ProductsDisplay :products="variety.slice(0, 3)" />
    <router-link to="/varieties">
      <button class="btn">View More</button>
    </router-link>


    <!-- Capsule Section -->
    <div class="category-header">
      <h3>Κάψουλες Καφέ</h3>
    </div>
    <ProductsDisplay :products="capsules.slice(0, 3)" />
    <router-link to="/capsules">
      <button class="btn">View More</button>
    </router-link>

    <!-- Accessory Section -->
    <div class="category-header">
      <h3>Αξεσουάρ</h3>
    </div>
    <ProductsDisplay :products="accessories.slice(0, 3)" />
    <router-link to="/accessories">
      <button class="btn">View More</button>
    </router-link>

    <!-- Coffee Machine Section -->
    <div class="category-header">
      <h3>Μηχανές Καφέ</h3>
    </div>
    <ProductsDisplay :products="machines.slice(0, 3)" />
    <router-link to="/machines">
      <button class="btn">View More</button>
    </router-link>

    <!-- Beverage Section -->
    <div class="category-header">
      <h3>Ροφήματα</h3>
    </div>
    <ProductsDisplay :products="beverages.slice(0, 3)" />
    <router-link to="/beverages">
      <button class="btn">View More</button>
    </router-link>
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
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';
/*
const variety = inject('variety');
const capsules = inject('capsules');
const accessories = inject('accessories');
const machines = inject('machines');
const beverages = inject('beverages');
*/
const variety = ref([]);
const capsules = ref([]);
const accessories = ref([]);
const machines = ref([]);
const beverages = ref([]);

onMounted(async () => {
  try{
    variety.value = await getProductsByCategory('variety');
    capsules.value = await getProductsByCategory('capsules');
    accessories.value = await getProductsByCategory('accessories');
    machines.value = await getProductsByCategory('machines');
    beverages.value = await getProductsByCategory('beverages');
    console.log("Accessories data: ", accessories.value);
  } catch (error) {
    console.error("Error fetching products by category: ", error);
  }
});
</script>

<style>
.category-header h3 {
  margin-top: 50px;
  text-align: center;
  font-size: 2rem;
  color: #FAEBD7;
  margin-bottom: 50px;
}

.btn {
  margin-top: 25px;
  padding: 15px 30px;
  font-size: 16px;
  background: #FAEBD7;
  color: #5D2D05;
  border: 1px solid transparent;
  border-radius: 25px;
  transition: .3s;
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-left: auto;
  margin-right: auto;
  margin-bottom: 80px;
  box-sizing: border-box;
}

.btn:hover {
  background-color: transparent;
  color: #FAEBD7;
  transition: background-color 0.3s ease, color 0.3s ease;
  border-color: #FAEBD7;
}
</style>