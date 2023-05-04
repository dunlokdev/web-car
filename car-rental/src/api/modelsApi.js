import axiosClient from "./axiosClient";

const modelsApi = {
  getAll() {
    const url = "/model";
    return axiosClient.get(url);
  },

  getById(id) {
    const url = `/model/${id}`;

    return axiosClient.get(url);
  },

  // https://localhost:7044/api/model/718/cars?PageSize=10&PageNumber=1
  getCarByModelSlug(slug, params) {
    const url = `model/${slug}/cars`;
    return axiosClient.get(url, { params });
  },

  addOrUpdate(data) {
    const url = `/model`;
    return axiosClient.post(url, data, {
      headers: { "Content-Type": "multipart/form-data" },
    });
  },

  remove(id) {
    const url = `/model/${id}`;

    return axiosClient.delete(url);
  },
};

export default modelsApi;
