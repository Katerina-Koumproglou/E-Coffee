import { createRouter, createWebHistory } from 'vue-router'

import HomePage from '@/views/HomePage.vue';

import MyCard from '@/views/MyCard.vue'

import SignUp from '@/components/SignUp.vue'


const routes = [
    {path: '/', name: 'Home', component: HomePage},
    {path: '/mycard', name: 'MyCard', component: MyCard},
    {path: '/signup', name: 'SignUp', component: SignUp}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router