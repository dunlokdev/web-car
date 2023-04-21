import axiosClient from "./axiosClient";

const postApi = {
  getAll(params) {},

  getById(id) {
    const url = `/cars/${id}`;
    return axiosClient.get(url);
  },

  add(data) {},

  update(data) {},

  remove(id) {},
};

export default postApi;
