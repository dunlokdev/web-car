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

  add(data) {},

  update(data) {},

  remove(id) {},
};

export default carsApi;
