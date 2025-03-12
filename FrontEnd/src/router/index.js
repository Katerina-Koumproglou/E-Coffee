import { createRouter, createWebHistory } from "vue-router";

import HomePage from "@/views/HomePage.vue";
import MyCart from "@/views/MyCart.vue";
import SignUp from "@/views/SignUp.vue";
import Login from "@/views/LoginPage.vue";
import Varieties from "@/views/VarietiesPage.vue";
import Capsules from "@/views/CapsulesPage.vue";
import Accessories from "@/views/AccessoriesPage.vue";
import Machines from "@/views/MachinesPage.vue";
import Beverages from "@/views/BeveragesPage.vue";
import EditProfile from "@/views/EditProfile.vue";
import ShowDetails from "@/views/ShowDetails.vue";
import UserProfile from "@/views/UserProfile.vue";
import ShowUsersForAdmin from "@/views/ShowUsersForAdmin.vue";

const routes = [
  { path: "/", name: "Home", component: HomePage },
  { path: "/mycart", name: "MyCart", component: MyCart },
  { path: "/signup", name: "SignUp", component: SignUp },
  { path: "/auth/login", name: "Login", component: Login },
  { path: "/varieties", name: "Varieties", component: Varieties },
  { path: "/capsules", name: "Capsules", component: Capsules },
  { path: "/accessories", name: "Accessories", component: Accessories },
  { path: "/machines", name: "Machines", component: Machines },
  { path: "/beverages", name: "Beverages", component: Beverages },
  {
    path: "/editprofile/:userId",
    name: "EditProfile",
    component: EditProfile,
    props: true,
  },
  {
    path: "/products/:category/:slug",
    name: "ShowDetails",
    component: ShowDetails,
    props: true,
  },
  {
    path: "/userprofile/:userId",
    name: "UserProfile",
    component: UserProfile,
    meta: { requiredAuth: true },
  },
  {
    path: "/showusers",
    name: "ShowUsersForAdmin",
    component: ShowUsersForAdmin,
    },

];

const router = createRouter({
  history: createWebHistory(),
  routes,
  scrollBehavior(to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition;
    }
    return { top: 0 };
  },
});

router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem("token") !== null;
  if (to.meta.requiredAuth && !isAuthenticated) {
    next("/auth/login");
  } else {
    next();
  }
});

export default router;
