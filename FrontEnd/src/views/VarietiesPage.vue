<template>
    <div class="home">
        <div class="category-header">
            <h3>Ποικιλίες Καφέ</h3>
        </div>
        <ProductsDisplay :products="variety" />
    </div>
</template>

<script>
export default {
    name: "VarietiesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';

const variety = ref([]);
//const variety = inject('variety');

onMounted(async () => {
   try{
    variety.value = await getProductsByCategory('variety');
    console.log("Varieties:", variety.value);
   } catch (error) {
       console.error("Error fetching varieties:", error);
   }
    
});
</script>