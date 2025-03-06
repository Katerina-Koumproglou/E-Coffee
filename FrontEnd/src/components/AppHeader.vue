<template>
    <nav>
        <div class="nav-inner">
            <!-- Logo -->
            <div class="logo-container">
                <router-link to="/">
                    <img src="@/assets/images/coffee-shop-logo-transparent.png" alt="" />
                </router-link>
                <router-link to="/" class="site-name"> E-Coffee </router-link>
            </div>

            <!-- Links -->
            <div class="links">
                <router-link to="/varieties"> Ποικιλίες </router-link>
                <router-link to="/capsules"> Κάψουλες </router-link>
                <router-link to="/accessories"> Αξεσουάρ </router-link>
                <router-link to="/machines"> Μηχανές </router-link>
                <router-link to="/beverages"> Ροφήματα </router-link>
            </div>

            <!-- Search bar -->
            <div class="search-bar-container">
                <div class="search-bar">
                    <input v-model="searchQuery"
                           type="text"
                           placeholder="Αναζήτηση..."
                           @focus="isSearching = true"
                           @blur="hideSearchResults" />
                    <button type="submit">
                        <svg xmlns="http://www.w3.org/2000/svg" height="20" width="20" viewBox="0 0 512 512">
                            <path fill="#5d2d05" d="M416 208c0 45.9-14.9 88.3-40 122.7L502.6 457.4c12.5 12.5 12.5 32.8 0 45.3" />
                        </svg>
                    </button>
                </div>
                <!-- Search results -->
                <ul v-if="isSearching && filteredProducts.length" class="search-results">
                    <li v-for="product in filteredProducts" :key="product.id">
                        <router-link :to="`/products/${product.category}/${product.slug}`">
                            <img :src="product.image" :alt="product.name" class="product-img" />
                            <div class="product-info">
                                <h3>{{ product.name }}</h3>
                            </div>
                        </router-link>
                    </li>
                </ul>
            </div>

            <!--Icons-->
            <div class="icons">
                <span class="user">
                    <router-link to="/auth/login">
                        <svg xmlns="http://www.w3.org/2000/svg" height="24" width="21" viewBox="0 0 448 512">
                            <path fill="#5d2d05"
                                  d="M304 128a80 80 0 1 0 -160 0 80 80 0 1 0 160 0zM96 128a128 128 0 1 1 256 0A128 128 0 1 1 96 128zM49.3 464l349.5 0c-8.9-63.3-63.3-112-129-112l-91.4 0c-65.7 0-120.1 48.7-129 112zM0 482.3C0 383.8 79.8 304 178.3 304l91.4 0C368.2 304 448 383.8 448 482.3c0 16.4-13.3 29.7-29.7 29.7L29.7 512C13.3 512 0 498.7 0 482.3z" />
                        </svg>
                    </router-link>
                </span>
                <span class="cart">
                    <router-link to="/mycart">
                        <svg xmlns="http://www.w3.org/2000/svg" height="24" width="27" viewBox="0 0 576 512">
                            <path fill="#5d2d05"
                                  d="M0 24C0 10.7 10.7 0 24 0L69.5 0c22 0 41.5 12.8 50.6 32l411 0c26.3 0 45.5 25 38.6 50.4l-41 152.3c-8.5 31.4-37 53.3-69.5 53.3l-288.5 0 5.4 28.5c2.2 11.3 12.1 19.5 23.6 19.5L488 336c13.3 0 24 10.7 24 24s-10.7 24-24 24l-288.3 0c-34.6 0-64.3-24.6-70.7-58.5L77.4 54.5c-.7-3.8-4-6.5-7.9-6.5L24 48C10.7 48 0 37.3 0 24zM128 464a48 48 0 1 1 96 0 48 48 0 1 1 -96 0zm336-48a48 48 0 1 1 0 96 48 48 0 1 1 0-96z" />
                        </svg>
                    </router-link>
                </span>
                
            </div>
        </div>
    </nav>
</template>

<script>
    import { ref, computed, inject } from "vue";

    export default {
        name: "AppHeader",
        setup() {
            const searchQuery = ref("");
            const isSearching = ref(false);
            const allProducts = inject("allProducts", ref([]));

            const filteredProducts = computed(() => {
                if (!searchQuery.value.trim() || !allProducts.value) return [];
                return allProducts.value.filter((product) =>
                    product.name.toLowerCase().includes(searchQuery.value.toLowerCase())
                );
            });

            const hideSearchResults = () => {
                setTimeout(() => {
                    isSearching.value = false;
                }, 200);
            };

            return { searchQuery, isSearching, filteredProducts, hideSearchResults };
        },
    };
</script>

<style scoped>
    nav {
        border-bottom: 2px solid #faebd7;
        height: 100px;
    }

    .nav-inner {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
        align-items: center;
        background-color: #faebd7;
        width: 100%;
        padding: 10px 20px;
    }

    .logo-container {
        display: flex;
        flex-direction: row;
        align-items: center;
        margin-left: 50px;
    }

        .logo-container img {
            height: 110px;
        }
    .site-name {
        font-size: 25px;
        font-weight: 700;
        font-family: "EB Garamond", serif;
        color: #5d2d05;
        text-decoration: none;
        margin-left: 20px;
    }

    .links {
        display: flex;
        gap: 15px;
        flex-wrap: wrap;
    }

        .links a {
            font-family: "EB Garamond", serif !important;
            font-weight: 700;
            font-style: normal;
            color: #5d2d05;
            margin: 0px 30px;
            font-size: 20px;
            line-height: 1.5;
            border-bottom: 2px solid transparent;
            transition: 0.3s;
        }
            .links a:hover {
                border-color: #5d2d05;
            }

    .search-bar-container {
        position: relative; /* Βάση για τα απόλυτα τοποθετημένα στοιχεία */
        width: 300px;
        display: flex;
        justify-content: center;
    }

    .search-bar {
        display: flex;
        align-items: center;
        cursor: pointer;
        width: 100%;
        padding: 8px 10px;
        background: #fff;
        border: 1px solid #5d2d05;
        border-radius: 30px;
        overflow: hidden;
        margin: 0 20px;
        transition: width 1s;
    }

        .search-bar input {
            width: 0;
            border: none;
            outline: none;
            padding: 8px 10px;
            font-weight: 500;
            font-size: 16px;
            font-family: "EB Garamond", serif;
            transition: width 1s;
            background: transparent;
        }
        .search-bar:hover input {
            width: 100%;
        }
    .search-results {
        position: absolute; /* Για να εμφανίζονται κάτω από τη μπάρα */
        top: 100%; /* Ακριβώς κάτω από τη μπάρα */
        left: 0;
        width: 100%; /* Να ταιριάζει με το πλάτος της μπάρας */
        background: white;
        border: 1px solid #5d2d05;
        border-top: none; /* Για να φαίνεται κολλημένο στη μπάρα */
        box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        z-index: 1000; /* Να είναι πάνω από άλλα στοιχεία */
        max-height: 300px; /* Περιορισμός ύψους για να μην καλύπτει όλη τη σελίδα */
        overflow-y: auto; /* Scroll αν υπάρχουν πολλά αποτελέσματα */
    }
        .search-bar button {
            color: #5d2d05;
            font-size: 18px;
            background: none;
            border: none;
            padding: 0px 8px;
            cursor: pointer;
            display: flex;
            align-items: center;
        }

    .search-bar {
        display: flex;
        align-items: center;
        cursor: pointer;
        width: 100%;
        padding: 8px 10px;
        background: #fff;
        border: 1px solid #5d2d05;
        border-radius: 30px;
        overflow: hidden;
        margin: 0 20px;
        transition: width 1s;
    }
        .search-bar input {
            width: 0;
            border: none;
            outline: none;
            padding: 8px 10px;
            font-weight: 500;
            font-size: 16px;
            font-family: "EB Garamond", serif;
            transition: width 1s;
            background: transparent;
        }
        .search-bar:hover input {
            width: 100%;
        }
        .search-bar button {
            color: #5d2d05;
            font-size: 18px;
            background: none;
            border: none;
            padding: 0px 8px;
            cursor: pointer;
            display: flex;
            align-items: center;
        }

    .search-results li {
        list-style: none;
        padding: 10px;
        display: flex;
        align-items: center;
        cursor: pointer;
        transition: background 0.3s;
    }

            .search-results li:hover {
                background: #f5f5f5;
            }

        .search-results img {
            width: 40px;
            height: 40px;
            margin-right: 10px;
            border-radius: 5px;
        }

        .search-results .product-info h3 {
            margin: 0;
            font-size: 16px;
            color: #5d2d05;


        }

    .icons {
        display: flex;
        align-items: center;
        margin-right: 50px;
    }

        .icons span {
            margin: 0px 20px;
            border-bottom: 2px solid transparent;
            transition: 0.3s;
            display: flex;
            justify-content: center;
            align-items: center;
        }

            .icons span:hover {
                border-color: #5d2d05;
            }
</style>
