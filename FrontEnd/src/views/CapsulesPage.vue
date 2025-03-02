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
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';

const capsules = ref([]);

onMounted(async () => {
   try{
    capsules.value = await getProductsByCategory('capsules');
    console.log("capsules:", capsules.value);
   } catch (error) {
       console.error("Error fetching capsules:", error);
   }
    
});
</script>