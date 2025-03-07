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

            // Υπολογισμός των φιλτραρισμένων προϊόντων
            const filteredProducts = computed(() => {
                if (!searchQuery.value.trim()) return [];
                const query = searchQuery.value.toLowerCase();
                return allProducts.value.filter((product) =>
                    product.name.toLowerCase().includes(query)
                );
            });

            // Επιλογή προϊόντος και μετάβαση στη σελίδα του
            const selectProduct = (product) => {
                router.push(`/products/${product.category}/${product.slug}`);
                searchQuery.value = "";
                isSearching.value = false;
            };

            let searchTimeout = null;

            watch(() => route.params.id, (newId) => {
                clearTimeout(searchTimeout);

                searchTimeout = setTimeout(() => {
                    if (filteredProducts.value.length > 0) {
                        const firstProduct = filteredProducts.value[0];

                        if (newId !== firstProduct.id.toString()) {
                            router.replace(`/product/${firstProduct.id}`);
                        }
                    }
                }, 100);
            });

            // Απόκρυψη αποτελεσμάτων όταν γίνεται κλικ εκτός
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