<template>
  <div id="app">
    <AppHeader />
    <main class="main-container">
      <router-view />
    </main>
    <AppFooter />
  </div>
</template>

<script>
import AppHeader from '@/components/AppHeader.vue';
import AppFooter from '@/components/AppFooter.vue';
import { ref, onMounted, provide } from 'vue';
import { getProductsByCategory } from '@/database';

export default {
  name: "App",
  components: { AppHeader, AppFooter },

  setup() {
    const variety = ref([]);
    const capsules = ref([]);
    const accessories = ref([]);
    const machines = ref([]);
    const beverages = ref([]);

    const fetchData = async (category, targetRef) => {
      try {
        const products = await getProductsByCategory(category);
        targetRef.values = products;
        console.log(`Loaded ${category}: `, products);
      } catch (error) {
        console.error(`Error loading ${category}: `, error);
      }
    };

    onMounted(() => {
      fetchData("variety", variety);
      fetchData("capsules", capsules);
      fetchData("accessories", accessories);
      fetchData("machines", machines);
      fetchData("beverages", beverages);
    });

    provide('variety', variety);
    provide('capsules', capsules);
    provide('accessories', accessories);
    provide('machines', machines);
    provide('beverages', beverages);

    return { variety, capsules, accessories, machines, beverages };
  },
};
</script>

<style>
#app {
  display: flex;
  flex-direction: column;
  min-height: 100vh;
}

.main-container {
  flex: 1;
  max-width: calc(1400px - 120px);
  width: 100%;
  margin: auto;
  padding-top: 100px;
}
</style>
