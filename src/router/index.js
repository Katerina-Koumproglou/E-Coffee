import { createRouter, createWebHistory } from "vue-router";

import HomePage from "@/views/HomePage.vue";

import MyCard from "@/views/MyCard.vue";

import SignUp from "@/views/SignUp.vue";
import Login from "@/views/LoginPage.vue";
import Varieties from "@/views/VarietiesPage.vue";
import Capsules from "@/views/CapsulesPage.vue";
import Accessories from "@/views/AccessoriesPage.vue";
import Machines from "@/views/MachinesPage.vue";
import Beverages from "@/views/BeveragesPage.vue";
import UserProfile from "@/views/UserProfile.vue";  // Μεγάλες κεφαλαία για το UserProfile


const routes = [
  { path: "/", name: "Home", component: HomePage },
  { path: "/mycard", name: "MyCard", component: MyCard },
  { path: "/signup", name: "SignUp", component: SignUp },
  { path: "/login", name: "Login", component: Login },
  { path: "/varieties", name: "Varieties", component: Varieties },
  { path: "/capsules", name: "Capsules", component: Capsules },
  { path: "/accessories", name: "Accessories", component: Accessories },
  { path: "/machines", name: "Machines", component: Machines },
  { path: "/beverages", name: "Beverages", component: Beverages },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
