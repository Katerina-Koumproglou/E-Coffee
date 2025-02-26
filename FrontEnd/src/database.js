import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5214",
  timeout: 5000,
});

export const getProductsByCategory = async (category) => {
  try {
    const response = await api.get(`/products/${category}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching ${category}: `, error);
    throw error;
  }
};

export const getProductBySlug = async (category, slug) => {
  try {
    const response = await api.get(`/products/${category}/${slug}`);
    return response.data;
  } catch (error) {
    console.error("Error fetching capsule by slug: ", error);
    throw error;
  }
};

export default api;
