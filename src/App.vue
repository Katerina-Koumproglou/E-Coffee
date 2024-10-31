<template>
    <div id="app">
        <SignUp />
    </div>
</template>

<script>
    import SignUp from './components/SignUp.vue';

    export default {
        components: {
            SignUp
        }
    };
</script>

<style>
    /* Background color για όλη την οθόνη */
    body, #app {
        font-family: 'EB Garamond', serif;
        text-align: center;
        background-color: rgba(255,255,255,0.3);
        backdrop-filter: blur(10px);
        color: #faebd7; /* Χρώμα για τα κείμενα */
        margin: 0;
        height: 100vh;
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>
