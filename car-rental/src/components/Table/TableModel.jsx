import { Link } from "react-router-dom";
import "../../styles/common.css";
const TableModel = ({ modelList }) => {
  return (
    <>
      <div className="row my-5">
        <h3 className="fs-4 mb-3">Danh sách các dòng xe</h3>
        <div className="col">
          <table className="table bg-white rounded shadow-sm table-hover">
            <thead>
              <tr>
                <th scope="col" width="50">
                  #
                </th>
                <th scope="col">Tên loại</th>
                <th scope="col">Url</th>
                <th scope="col">Ảnh</th>
                <th scope="col">Số lượng xe</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {modelList.map((item, index) => {
                return (
                  <tr key={item.id}>
                    <th scope="row">{index + 1}</th>
                    <td>{item.name}</td>

                    <td>
                      <Link to={`/cars/models/${item.urlSlug}`}>
                        {item.urlSlug}
                      </Link>
                    </td>
                    <td>
                      <img
                        src={item.thumbnail}
                        alt=""
                        style={{
                          height: "100px",
                          width: "auto",
                          objectFit: "cover",
                        }}
                      />
                    </td>
                    <td>{item.carCount}</td>
                    <td>
                      <div className="d-flex">
                        <Link
                          to={`/admin/models/edit/${item.id}`}
                          className="action edit mx-2"
                        >
                          <i className="ri-pencil-line"></i>
                        </Link>
                        <button onClick={() => {}} className="action delete">
                          <i className="ri-delete-bin-line"></i>
                        </button>
                      </div>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </div>
    </>
  );
};
export default TableModel;
