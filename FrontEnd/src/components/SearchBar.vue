<script>
    import { ref, computed, inject, onMounted, onUnmounted } from "vue";
    import { useRouter } from "vue-router";

    export default {
        setup() {
            const searchQuery = ref("");
            const allProducts = inject("allProducts", ref([]));
            const isSearching = ref(false);
            const router = useRouter();
            const route = useRoute();

            const filteredProducts = computed(() => {
                if (!searchQuery.value.trim()) return [];
                const query = searchQuery.value.toLowerCase();
                return allProducts.value.filter((product) =>
                    product.name.toLowerCase().includes(query)
                );
            });

            const selectProduct = (product) => {
                router.push(`/products/${product.category}/${product.slug}`);
                searchQuery.value = "";
                isSearching.value = false;
            };

            watch(() => route.params.id, (newId) => {
                if (!newId) return;

                clearTimeout(searchTimeout);

                searchTimeout = setTimeout(() => {
                    if (filteredProducts.value.length > 0) {
                        const firstProduct = filteredProducts.value[0];

                        if (newId !== firstProduct.id.toString()) {
                            router.replace(`/products/${firstProduct.category}/${firstProduct.slug}`);
                        }
                    }
                }, 100);

            });

            const hideSearchResults = (event) => {
                if (!event.target.closest(".search-bar-container")) {
                    isSearching.value = false;
                }
            };

            onMounted(() => document.addEventListener("click", hideSearchResults));
            onUnmounted(() => document.removeEventListener("click", hideSearchResults));

            return {
                searchQuery,
                isSearching,
                filteredProducts,
                selectProduct,

            }
        };
    };
</script>
