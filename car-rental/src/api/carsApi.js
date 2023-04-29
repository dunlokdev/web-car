import axiosClient from "./axiosClient";

const carsApi = {
  getAll(params) {
    const url = "/cars";
    return axiosClient.get(url, { params });
  },

  getById(id) {
    const url = `/cars/${id}`;
    return axiosClient.get(url);
  },

  getBySlug(slug) {
    const url = `/cars/slug/${slug}`;
    return axiosClient.get(url);
  },

  // https://localhost:7044/api/cars/galeries/1
  getGaleriesByCarId(id) {
    const url = `cars/galeries/${id}`;
    return axiosClient.get(url);
  },

  addOrUpdate(data) {
    console.log("data: ", data);
    const url = `/cars`;
    return axiosClient.post(url, data, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  add(data) {},

  update(data) {},

  remove(id) {},
};

export default carsApi;
