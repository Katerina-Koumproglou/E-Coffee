<script>
    import { ref, computed, inject, onMounted, onUnmounted } from "vue";

    export default {
        setup() {
            const searchQuery = ref("");
            const allProducts = inject("allProducts", ref([]));
            const isSearching = ref(false);

            const filteredProducts = computed(() => {
                if (!searchQuery.value.trim()) return [];
                return allProducts.value.filter((product) =>
                    product.name.toLowerCase().includes(searchQuery.value.toLowerCase())
                );
            });

            const hideSearchResults = (event) => {
                if (!event.target.closest(".search-bar-container")) {
                    isSearching.value = false;
                }
            };

            onMounted(() => document.addEventListener("click", hideSearchResults));
            onUnmounted(() => document.removeEventListener("click", hideSearchResults));

            return { searchQuery, isSearching, filteredProducts };
        },
    };
</script>