import axiosClient from "./axiosClient";

const modelsApi = {
  getAll() {
    const url = "/model";
    return axiosClient.get(url);
  },

  // https://localhost:7044/api/model/718/cars?PageSize=10&PageNumber=1
  getCarByModelSlug(slug, params) {
    const url = `model/${slug}/cars`;
    return axiosClient.get(url, { params });
  },

  add(data) {},

  update(data) {},

  remove(id) {},
};

export default modelsApi;
