import axiosClient from "./axiosClient";

const commentApi = {
  add(data) {
    // https://localhost:7044/api/comments
    const url = `/comments`;
    return axiosClient.post(url, data);
  },
};

export default commentApi;
