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
import { collection, onSnapshot } from 'firebase/firestore';
import { db } from '@/firebase';

export default {
  name: "App",
  components: { AppHeader, AppFooter },

  setup() {
    const variety = ref([]);
    const capsules = ref([]);
    const accessories = ref([]);
    const machines = ref([]);
    const beverages = ref([]);

    const fetchData = (collectionName, targetRef) => {
      onSnapshot(collection(db, collectionName), (querySnapshot) => {
        const items = [];
        querySnapshot.forEach((doc) => {
          items.push({ id: doc.id, ...doc.data() });
        });
        targetRef.value = items;
        console.log(`Loaded ${collectionName}:`, items);
      });
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
.container {
  flex: 1;
  max-width: calc(1400px - 120px);
  width: 100%;
  margin: auto;
}
</style>
