import axiosClient from "./axiosClient";

const postApi = {
  getAll(params) {
    const url = "/posts";
    return axiosClient.get(url, { params });
  },

  getBySlug(slug) {
    const url = `/posts/byslug/${slug}`;
    return axiosClient.get(url);
  },
};

export default postApi;
