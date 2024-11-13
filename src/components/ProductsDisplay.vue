<template>
    <div>
        <div class="container">
            <div class="category-header">
                <h3>Ποικιλίες Καφέ</h3>
            </div>

            <div class="products">
                <div v-for="n in 6" :key="n" class="single-product">
                    <div class="img-container">
                        <img src="@/assets/images/illy-classico-250.png" alt="">
                    </div>
                    <div class="product-container">
                        <h6 class="name">Καφές Espresso σε Κόκκους illy Classico 250gr</h6>
                        <span class="price">€9.50</span>
                    </div>
                </div>
            </div>
            <button class="btn">View More</button>
        </div>
    </div>
</template>

<script>
    import { defineComponent } from 'vue';
    export default defineComponent({
        name: 'ProductsDisplay'
    })
</script>

<script setup>
    import { onMounted } from 'vue';
    onMounted( () => {
        console.log('MMOUNTED>>>>>>')
    })
</script>

<style>
.category-header h3 {
    text-align: center;
    font-size: 2rem;
    color: #FAEBD7;
    margin-bottom: 50px;
}

.img-container img{
    width: 300px;
    height: auto;
    max-width: 100%;
}

.product-container {
    width: 300px;
    font-size: 30px;
    color: #FFF;
}


</style>