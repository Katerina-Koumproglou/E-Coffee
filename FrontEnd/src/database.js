import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5214",
  timeout: 5000,
});

export const getProductById = async (id) => {
  try {
    console.log(`(database.js) Fetching product with ID: ${id}`);
    const response = await api.get(`/products/product/${id}`);
    console.log("(database.js) Product by ID: ", response.data);
    return response.data;
  } catch (error) {
    console.error("Error fetching product by ID: ", error);
    throw error;
  }
};

export const getProductsByCategory = async (category) => {
  try {
    console.log(`Fetching products for category: ${category}`);
    const response = await api.get(`/products/${category}`);
    console.log("Products fetched for category: ", response.data);
    return response.data;
  } catch (error) {
    console.error(`Error fetching ${category}: `, error);
    throw error;
  }
};

export const getAllProducts = async () => {
  try {
    const response = await api.get(`/products`);
    return response.data;
  } catch (error) {
    console.error("Error fetching: ", error);
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

export const signUp = async (
  name,
  surname,
  address,
  phone,
  email,
  password
) => {
  try {
    const response = await axios.post(`/auth/signup`, {
      name,
      surname,
      address,
      phone,
      email,
      password,
    });
    console.log("Signup successful: ", response.data);
    return response.data;
  } catch (error) {
    console.error("Signup failed: ", error);
    throw error;
  }
};

export const login = async (email, password) => {
  try {
    const response = await axios.post(`/auth/login`, {
      email,
      password,
    });
    console.log("Login successful: ", response.data);
    return response.data;
  } catch (error) {
    console.error("Login failed: ", error);
    throw error;
  }
};

export const addToCartApi = async (userId, productId) => {
  try {
    const response = await api.post("api/cart", { userId, productId });
    console.log("Product added to cart:", response.data);
    return response.data;
  } catch (error) {
    console.error("Error adding product to cart:", error);
    throw error;
  }
};

export const getCartItems = async (userId) => {
  try {
    const response = await api.get(`api/cart/${userId}`);
    console.log("Cart items fetched:", response.data);
    return response.data;
  } catch (error) {
    console.error("Error fetching cart items:", error);
    throw error;
  }
};

export default api;
