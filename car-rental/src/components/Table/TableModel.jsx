import { Link } from "react-router-dom";
import { GetCurrency } from "../../Utils/common";
import "../../styles/common.css";
const TableModel = ({ modelList }) => {
  return (
    <>
      <div className="row my-5">
        <h3 className="fs-4 mb-3">Danh sách các loại xe</h3>
        <div className="col">
          <table className="table bg-white rounded shadow-sm  table-hover">
            <thead>
              <tr>
                <th scope="col" width="50">
                  #
                </th>
                <th scope="col">Tên loại</th>
                <th scope="col">Url</th>
                <th scope="col">Số lượng xe</th>
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
                    <td>{item.carCount}</td>
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
