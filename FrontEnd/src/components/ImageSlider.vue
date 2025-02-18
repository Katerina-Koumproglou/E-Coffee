<template>
    <div class="container">
        <div class="wrapper">
            <div class="wrapper-holder">
                <div id="slider-img-1"></div>
                <div id="slider-img-2"></div>
                <div id="slider-img-3"></div>
                <div id="slider-img-4"></div>
            </div>
        </div>

        <div class="button-holder">
            <a href="#slider-img-1" class="button"></a>
            <a href="#slider-img-2" class="button"></a>
            <a href="#slider-img-3" class="button"></a>
            <a href="#slider-img-4" class="button"></a>
        </div>
    </div>
</template>

<style>
.container {
    position: relative;
}

.container .wrapper {
    width: 750px;
    height: 400px;
    box-shadow: 10px 10px 10px rgba(0, 0, 0, 0.5);
    margin: 5rem auto;
    overflow: hidden;
}

.container .wrapper-holder {
    display: grid;
    grid-template-columns: repeat(4, 100%);
    height: 100%;
    width: 100%;
    animation: slider 30s ease-in-out infinite;
}

.container #slider-img-1,
.container #slider-img-2,
.container #slider-img-3,
.container #slider-img-4 {
    background-position: center;
    background-size: cover;
}

.container #slider-img-1 {
    background-image: url(@/assets/images/vertuo-pop-blue.png);
}

.container #slider-img-2 {
    background-image: url(@/assets/images/aeroccino-xl.png);
}

.container #slider-img-3 {
    background-image: url(@/assets/images/mug.png);
}

.container #slider-img-4 {
    background-image: url(@/assets/images/chocolanelle.png);
}

.container .button-holder {
    position: absolute;
    left: 50%;
    bottom: 20px;
    transform: translateX(-50%);
    display: flex;
    justify-content: center;
}

.container .button-holder .button {
    background-color: #FFF;
    width: 15px;
    height: 15px;
    border-radius: 15px;
    display: inline-block;
    margin: .3rem;
    cursor: pointer
}

.button:hover {
    box-shadow: 0px 0px 7px 4px rgba(93, 45, 5, 0.5);
}

@keyframes slider {
    0% {
        transform: translateX(0%);
    }

    10% {
        transform: translateX(-100%);
    }

    20% {
        transform: translateX(-100%);
    }

    30% {
        transform: translateX(-200%);
    }

    40% {
        transform: translateX(-200%);
    }

    50% {
        transform: translateX(-200%);
    }

    60% {
        transform: translateX(-300%);
    }

    70% {
        transform: translateX(-300%);
    }

    80% {
        transform: translateX(-300%);
    }

    90% {
        transform: translateX(0%);
    }

    100% {
        transform: translateX(0%);
    }
}
</style>
<script setup>

</script>

<style lang="scss" scoped></style>