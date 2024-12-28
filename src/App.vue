<template>
  <div id="app">
    <AppHeader />
    <main class="main-container">
      <DataBase />
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
  components: {
    AppHeader,
    AppFooter,
  },

  setup() {
    const variety = ref([]);
    const capsules = ref([]);
    const accessories = ref([]);
    const machines = ref([]);
    const beverages = ref([]);

    onMounted(() => {
      //Fetch variety products from database
      onSnapshot(collection(db, "variety"), (querySnapshot) => {
        const fbVariety = [];
        querySnapshot.forEach((doc) => {
          const item = {
            id: doc.id,
            name: doc.data().name,
            brand: doc.data().brand,
            category: doc.data().category,
            price: doc.data().price,
            image: doc.data().image
          }
          fbVariety.push(item);
        });
        variety.value = fbVariety;
      });

      //Fetch capsule products from database
      onSnapshot(collection(db, "capsules"), (querySnapshot) => {
        const fbCapsules = [];
        querySnapshot.forEach((doc) => {
          const item = {
            id: doc.id,
            name: doc.data().name,
            brand: doc.data().brand,
            category: doc.data().category,
            price: doc.data().price,
            image: doc.data().image
          }
          fbCapsules.push(item);
        });
        capsules.value = fbCapsules;
      });

      //Fetch accessories products from database
      onSnapshot(collection(db, "accessories"), (querySnapshot) => {
        const fbAccessories = [];
        querySnapshot.forEach((doc) => {
          const item = {
            id: doc.id,
            name: doc.data().name,
            brand: doc.data().brand,
            category: doc.data().category,
            price: doc.data().price,
            image: doc.data().image
          }
          fbAccessories.push(item);
        });
        accessories.value = fbAccessories;
      });

      //Fetch machine products from database
      onSnapshot(collection(db, "machines"), (querySnapshot) => {
        const fbMachines = [];
        querySnapshot.forEach((doc) => {
          const item = {
            id: doc.id,
            name: doc.data().name,
            brand: doc.data().brand,
            category: doc.data().category,
            price: doc.data().price,
            image: doc.data().image
          }
          fbMachines.push(item);
        });
        machines.value = fbMachines;
      });

      //Fetch beverage products from database
      onSnapshot(collection(db, "beverages"), (querySnapshot) => {
        const fbBeverages = [];
        querySnapshot.forEach((doc) => {
          const item = {
            id: doc.id,
            name: doc.data().name,
            brand: doc.data().brand,
            category: doc.data().category,
            price: doc.data().price,
            image: doc.data().image
          }
          fbBeverages.push(item);
        });
        beverages.value = fbBeverages;
      });
    });
    provide('variety', variety);
    provide('capsules', capsules);
    provide('accessories', accessories);
    provide('machines', machines);
    provide('beverages', beverages);

    return {
      variety,
      capsules,
      accessories,
      machines,
      beverages
    };
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