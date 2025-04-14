<template>
    <div class="home">
        <div class="category-header">
            <h3>Beverages</h3>
        </div>
        <ProductsDisplay :products="beverages" />
    </div>
</template>

<script>
export default {
    name: "BeveragesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';

const beverages = ref([]);

onMounted(async () => {
   try{
    beverages.value = await getProductsByCategory('beverages');
    console.log("beverages:", beverages.value);
   } catch (error) {
       console.error("Error fetching varieties:", error);
   }
    
});
</script>
