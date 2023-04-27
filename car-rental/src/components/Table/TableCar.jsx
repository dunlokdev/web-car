import { GetCurrency } from "../../Utils/common";
import "../../styles/common.css";
const TableCar = ({ carList }) => {
  return (
    <>
      <div className="row my-5">
        <h3 className="fs-4 mb-3">Danh sách các xe</h3>
        <div className="col">
          <table className="table bg-white rounded shadow-sm  table-hover">
            <thead>
              <tr>
                <th scope="col" width="50">
                  #
                </th>
                <th scope="col">Tên xe</th>
                <th scope="col">Mô tả</th>
                <th scope="col">Giá</th>
                <th scope="col">Hiển thị</th>
                <th scope="col">Loại</th>
                <th scope="col">Giảm giá</th>
              </tr>
            </thead>
            <tbody>
              {carList.map((item, index) => {
                return (
                  <tr key={item.id}>
                    <th scope="row">{index + 1}</th>
                    <td>{item.name}</td>
                    <td>{item.shortDescripton}</td>
                    <td>{GetCurrency(item.price)}</td>
                    <td>{item.isActived ? "Có" : "Không"}</td>
                    <td>{item.model}</td>
                    <td>-{item.discount}%</td>
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
export default TableCar;
