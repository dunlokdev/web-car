import { Link } from "react-router-dom";
import { GetCurrency } from "../../Utils/common";
import "../../styles/common.css";

const TableCar = ({ carList, handleDeleteCar }) => {
  const handleDelete = (id) => {
    if (handleDeleteCar) handleDeleteCar(id);
  };

  return (
    <>
      <div className="row my-5">
        <h3 className="fs-4 mb-3">Danh sách các xe</h3>
        <div className="table-responsive table-responsive-lg table-responsive-md">
          <table className="table bg-white rounded shadow-sm  table-hover">
            <thead>
              <tr>
                <th scope="col" width="50">
                  #
                </th>
                <th scope="col">Tên xe</th>
                <th scope="col">Ảnh</th>
                <th scope="col">Mô tả</th>
                <th scope="col">Giá</th>
                <th scope="col">Hiển thị</th>
                <th scope="col">Loại</th>
                <th scope="col">Giảm giá</th>
                <th scope="col"></th>
              </tr>
            </thead>
            <tbody>
              {carList.length > 0 ? (
                carList.map((item, index) => {
                  return (
                    <tr key={item.id}>
                      <th scope="row">{index + 1}</th>
                      <td className="cursor">{item.name}</td>
                      <td>
                        <img
                          src={
                            item?.thumbnail ||
                            "https://placehold.co/600x400?text=Thumbnail"
                          }
                          alt=""
                          style={{
                            height: "100px",
                            width: "200px",
                            objectFit: "cover",
                          }}
                        />
                      </td>
                      <td>{item.shortDescripton}</td>
                      <td>{GetCurrency(item.price)}</td>
                      <td>{item.isActived ? "Có" : "Không"}</td>
                      <td>{item.model}</td>
                      <td>-{item.discount}%</td>
                      <td>
                        <div className="d-flex gap-1">
                          <Link
                            to={`/admin/cars/edit/${item.id}`}
                            className="action edit"
                          >
                            <i className="ri-pencil-line"></i>
                          </Link>
                          <button
                            onClick={() => {
                              handleDelete(item.id);
                            }}
                            className="action delete"
                          >
                            <i className="ri-delete-bin-line"></i>
                          </button>
                        </div>
                      </td>
                    </tr>
                  );
                })
              ) : (
                <tr>
                  <td>#</td>
                  <td>Không tìm thấy</td>
                  <td>#</td>
                  <td>#</td>
                  <td>#</td>
                  <td>#</td>
                  <td>#</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};
export default TableCar;
