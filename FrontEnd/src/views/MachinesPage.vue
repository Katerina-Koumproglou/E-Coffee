<template>
    <div class="home">
        <div class="category-header">
            <h3>Machines</h3>
        </div>
        <ProductsDisplay :products="machines" />
    </div>
</template>

<!-- <script>
export default {
    name: "MachinesPage"
};
</script>

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { inject } from 'vue';

const machines = inject('machines');
</script> -->

<script setup>
import ProductsDisplay from '@/components/ProductsDisplay.vue';
import { ref, onMounted } from 'vue';
import { getProductsByCategory } from '@/database';

const machines = ref([]);
//const variety = inject('variety');

onMounted(async () => {
   try{
    machines.value = await getProductsByCategory('machines');
    console.log("machines:", machines.value);
   } catch (error) {
       console.error("Error fetching machines:", error);
   }
    
});
</script>
