import axios from "axios";

// const api = axios.create({
//   baseURL: "http://localhost:5214",
//   timeout: 5000,
// });

const api = "http://localhost:5214";

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
    const response = await axios.get(`${api}/products/${category}/${slug}`);
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
    const response = await axios.post(`${api}/auth/signup`, {
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
    const response = await axios.post(`${api}/auth/login`, {
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

export default api;
