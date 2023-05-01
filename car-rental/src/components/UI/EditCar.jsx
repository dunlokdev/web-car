import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { decode } from "../../Utils/common";
import carsApi from "../../api/carsApi";
import modelsApi from "../../api/modelsApi";
import "../../styles/edit-car.css";

const AddOrEdit = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [car, setCar] = useState({
    id: 0,
    name: "",
    consume: 0,
    description: "",
    discount: 0,
    emission: 0,
    evaluate: 0,
    isActived: true,
    maxSpeed: 0,
    modelId: 0,
    price: 0,
    speedUp: 0,
    torque: 0,
    wattage: 0,
    shortDescripton: "",
    imageFile: "",
    thumbnail: "",
  });
  const [models, setModels] = useState([]);

  useEffect(() => {
    window.scrollTo(0, 0);

    (async () => {
      try {
        if (id > 0) {
          const data = await carsApi.getById(id);
          setCar(data.result);
        }
        const response = await modelsApi.getAll();
        console.log("response: ", response);
        const models = response.result.map((item, index) => {
          return {
            id: item.id,
            name: item.name,
            urlSlug: item.urlSlug,
          };
        });

        setModels(models);
      } catch (error) {
        console.log("An error occurred, ", error);
      }
    })();
  }, [id]);

  const handleOnSubmit = (e) => {
    e.preventDefault();

    let formData = new FormData(e.target);

    (async () => {
      const response = await carsApi.addOrUpdate(formData);

      if (response.isSuccess) {
        alert("Đã lưu thành công!");
        navigate("/admin/cars");
      } else alert("Đã xảy ra lỗi!");
    })();
  };

  return (
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

        <div className="row gap-3">
          <div className="col-5">
            <img
              src={car?.thumbnail || "https://via.placeholder.com/1368x400"}
              alt=""
              className="edit-thumbnail"
            />
            <h3 className="text-center">{car?.name}</h3>
          </div>

          <div className="col-3 d-flex gap-3 flex-column">
            <input type="hidden" readOnly name="id" value={car?.id} />
            <div className="form-group">
              <label>Tên xe</label>
              <input
                type="text"
                className="form-control"
                value={car?.name}
                name="name"
                onChange={(e) => {
                  setCar({ ...car, name: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Giá (*)</label>
              <input
                type="text"
                className="form-control"
                value={car?.price}
                name="price"
                onChange={(e) => {
                  setCar({ ...car, price: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Khuyến mãi</label>
              <input
                type="text"
                name="discount"
                className="form-control"
                value={car?.discount}
                onChange={(e) => {
                  setCar({ ...car, discount: e.target.value || 0 });
                }}
              />
            </div>

            <div className="form-group">
              <label>Mô tả (*)</label>
              <textarea
                rows={3}
                className="form-control"
                name="shortDescripton"
                value={decode(car?.shortDescripton || "")}
                onChange={(e) => {
                  setCar({ ...car, shortDescripton: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Chi tiết (*)</label>
              <textarea
                rows={5}
                className="form-control"
                name="description"
                value={decode(car?.description || "")}
                onChange={(e) => {
                  setCar({ ...car, description: e.target.value });
                }}
              />
            </div>

            <div className="form-control">
              <input
                type="file"
                name="imageFile"
                accept="image/*"
                title="Image file"
                onChange={(e) => {
                  setCar({ ...car, imageFile: e.target.files[0] });
                }}
              />
            </div>

            <div className="form-check">
              <input
                className="form-check-input"
                type="checkbox"
                name="isActived"
                checked={car?.isActived}
                title="Published"
                onChange={(e) =>
                  setCar({ ...car, isActived: e.target.checked })
                }
              />
              <label className="form-check-label">Hiển thị</label>
            </div>
          </div>

          <div className="col-3 d-flex gap-3 flex-column">
            <div className="form-group">
              <label>Công xuất (*)</label>
              <input
                type="text"
                className="form-control"
                name="wattage"
                value={car?.wattage}
                onChange={(e) => {
                  setCar({ ...car, wattage: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Mô men xoắn cực đại (*)</label>
              <input
                type="text"
                className="form-control"
                name="torque"
                value={car?.torque}
                onChange={(e) => {
                  setCar({ ...car, torque: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Tăng tốc từ 0 - 100 km/giờ (0 - 62 dặm/giờ) (*)</label>
              <input
                type="text"
                className="form-control"
                name="speedUp"
                value={car?.speedUp}
                onChange={(e) => {
                  setCar({ ...car, speedUp: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Tốc độ tối đa (*)</label>
              <input
                type="text"
                className="form-control"
                name="maxSpeed"
                value={car?.maxSpeed}
                onChange={(e) => {
                  setCar({ ...car, maxSpeed: e.target.value });
                }}
              />
            </div>

            <div className="form-group">
              <label>Tiêu thụ nhiên liệu kết hợp (lít/100km)</label>
              <input
                type="text"
                className="form-control"
                name="consume"
                value={car?.consume}
                onChange={(e) => {
                  setCar({ ...car, consume: e.target.value || 0 });
                }}
              />
            </div>

            <div className="form-group">
              <label>Lượng khí thải CO2 (g/km)</label>
              <input
                type="text"
                className="form-control"
                name="emission"
                value={car?.emission}
                onChange={(e) => {
                  setCar({ ...car, emission: e.target.value || 0 });
                }}
              />
            </div>

            <div className="form-group">
              <label>Đánh giá</label>
              <input
                type="text"
                className="form-control"
                name="evaluate"
                value={car?.evaluate}
                onChange={(e) => {
                  setCar({ ...car, evaluate: e.target.value || 0 });
                }}
              />
            </div>

            <div className="form-group">
              <label>Dòng xe (*)</label>
              <select
                title="Dòng xe"
                name="modelId"
                style={{ width: "150px" }}
                value={car?.modelId}
                className="form-select"
                onChange={(e) => {
                  setCar({ ...car, modelId: e.target.value });
                }}
              >
                <option value={0}>-- Chọn --</option>
                {models.map((item) => (
                  <option key={item.id} value={item?.id}>
                    {item.name}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="d-flex justify-content-center gap-3 mt-3">
            <Link
              to="/admin/cars"
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
  );
};
export default AddOrEdit;
