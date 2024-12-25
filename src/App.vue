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
// import DataBase from '@/components/DataBase.vue';
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
    const variety = ref({

    });

    onMounted(() => {
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
    });
    provide('variety', variety);

    return {
      variety,
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