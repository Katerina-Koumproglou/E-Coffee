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
import AppHeader from "@/components/AppHeader.vue";
import AppFooter from "@/components/AppFooter.vue";
import DataBase from "@/components/DataBase.vue";

export default {
  name: "App",
  components: {
    DataBase,
    AppHeader,
    AppFooter,
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