import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import modelsApi from "../../api/modelsApi";

const EditModel = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  console.log("🚀 ~ EditModel ~ id:", id);

  const [model, setModel] = useState({
    id: 0,
    name: "",
    thumbnail: "",
    carCount: 0,
  });

  useEffect(() => {
    window.scrollTo(0, 0);

    (async () => {
      try {
        if (id > 0) {
          const data = await modelsApi.getById(id);
          setModel(data.result);
        }
      } catch (error) {
        console.log("An error occurred, ", error);
      }
    })();
  }, [id]);

  const handleOnSubmit = (e) => {
    e.preventDefault();

    let formData = new FormData(e.target);

    (async () => {
      const response = await modelsApi.addOrUpdate(formData);
      console.log("🚀 ~ response:", response);

      if (response.isSuccess) {
        alert("Đã lưu thành công!");
        navigate("/admin/models");
      } else alert("Đã xảy ra lỗi!");
    })();
  };

  return (
    <>
      <div className="px-4 pt-4">
        <form
          method="post"
          encType="multipart/form-data"
          onSubmit={handleOnSubmit}
          style={{
            backgroundColor: "#fff",
            borderRadius: "8px",
            padding: "20px",
          }}
        >
          <h2 className="text-center mb-3">Thông tin chi tiết</h2>

          <div className="row">
            <div className="col-5">
              <img
                src={model?.thumbnail || "https://via.placeholder.com/1368x400"}
                alt=""
                className="edit-thumbnail"
                style={{ height: "320px", width: "360px", objectFit: "cover" }}
              />
            </div>

            <div className="col-3 d-flex gap-3 flex-column">
              <input type="hidden" readOnly name="id" value={model?.id} />
              <div className="form-group">
                <label>Tên dòng xe</label>
                <input
                  type="text"
                  className="form-control"
                  value={model?.name}
                  name="name"
                  onChange={(e) => {
                    setModel({ ...model, name: e.target.value });
                  }}
                />
              </div>
              <div>
                <p>UrlSlug: </p>
                <p className="text-black-500 fw-bold">{model?.urlSlug}</p>
              </div>
              <div>
                <p>Số xe thuộc dòng: </p>
                <p className="text-black-500 fw-bold">{model?.carCount} xe</p>
              </div>
              <div>
                <label htmlFor="">Thay đổi ảnh nền</label>
                <input
                  type="file"
                  name="imageFile"
                  accept="image/*"
                  title="Image file"
                  onChange={(e) => {
                    setModel({ ...model, imageFile: e.target.files[0] });
                  }}
                />
              </div>
            </div>
            <div className="d-flex justify-content-center gap-3 mt-3">
              <Link
                to="/admin/models"
                className="btn"
                style={{ backgroundColor: "#dc3545" }}
              >
                Quay lại
              </Link>
              <button type="submit" className="btn">
                Lưu
              </button>
            </div>
          </div>
        </form>
      </div>
    </>
  );
};
export default EditModel;
