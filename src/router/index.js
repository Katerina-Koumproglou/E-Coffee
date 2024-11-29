import { createRouter, createWebHistory } from 'vue-router'

import HomePage from '@/views/HomePage.vue';

import MyCard from '@/views/MyCard.vue'

import SignUp from '@/views/SignUp.vue'

import Login from '@/views/LoginPage.vue'


const routes = [
    {path: '/', name: 'Home', component: HomePage},
    {path: '/mycard', name: 'MyCard', component: MyCard},
    { path: '/signup', name: 'SignUp', component: SignUp },
    {path: '/login', name: 'Login', component: Login}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router