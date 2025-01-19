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

const routes = [
    { path: "/", name: "Home", component: HomePage },
    { path: "/mycart", name: "MyCart", component: MyCart },
    { path: "/signup", name: "SignUp", component: SignUp },
    { path: "/login", name: "Login", component: Login },
    { path: "/varieties", name: "Varieties", component: Varieties },
    { path: "/capsules", name: "Capsules", component: Capsules },
    { path: "/accessories", name: "Accessories", component: Accessories },
    { path: "/machines", name: "Machines", component: Machines },
    { path: "/beverages", name: "Beverages", component: Beverages },
    { path: "/edit-profile", name: "EditProfile", component: EditProfile },

    // Προσθήκη δυναμικής διαδρομής για το UserProfile
    {
        path: "/user-profile/:userId",
        name: "UserProfile",
        component: () => import("@/views/UserProfile.vue"), // Δυναμική φόρτωση
        props: true // Να περάσουμε το userId ως prop
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
