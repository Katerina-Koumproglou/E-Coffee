<template>
    <div class="home">
        <div class="category-header">
            <h3>Αξεσουάρ</h3>
        </div>
        <ProductsDisplay :products="accessories" />
    </div>
</template>

<script>
export default {
    name: "AccessoriesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';

const accessories = ref([]);

onMounted(async () => {
   try{
    accessories.value = await getProductsByCategory('accessories');
    console.log("Varieties:", accessories.value);
   } catch (error) {
       console.error("Error fetching accessories:", error);
   }
    
});
</script>