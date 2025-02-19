import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5214",
  timeout: 5000,
});

export const getAccessories = async () => {
  try {
    const response = await api.get("/accessories");
    return response.data;
  } catch (error) {
    console.error("Error fetching capsules: ", error);
    throw error;
  }
};

export const getAccessoryBySlug = async (slug) => {
  try {
    const response = await api.get(`/accessories/${slug}`);
    return response.data;
  } catch (error) {
    console.error("Error fetching capsule by slug: ", error);
    throw error;
  }
};

export default api;
