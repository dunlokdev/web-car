import { useEffect, useState } from "react";
import modelsApi from "../../api/modelsApi";
import TableModel from "../Table/TableModel";
import CommonSection from "../UI/CommonSection";
import { Link } from "react-router-dom";

const ManagerModels = () => {
  // State
  const [modelList, setModelList] = useState([]);

  // Effect
  useEffect(() => {
    (async () => {
      try {
        const { result } = await modelsApi.getAll();
        setModelList(result);
      } catch (error) {}
    })();
  }, []);

  const handleDeleteModel = (id) => {
    (async () => {
      try {
        const { isSuccess, result } = await modelsApi.remove(id);
        if (isSuccess) {
          alert(`Xoá thành công dòng xe có id = ${id}`);
          const { result } = await modelsApi.getAll();
          setModelList(result);
        }
      } catch (error) {
        console.log("Try again to delete car...", error);
      }
    })();
  };

  return (
    <>
      <CommonSection title="Quản lý dòng xe" />

      <div className="manager-models px-4">
        <div className="mt-3 d-flex align-items-center justify-content-end gap-3">
          <p>Thêm mới</p>
          <Link to={`edit/${0}`} className="btn">
            <i className="ri-add-fill"></i>
          </Link>
        </div>
        <TableModel
          modelList={modelList}
          handleDeleteModel={handleDeleteModel}
        />
      </div>
    </>
  );
};
export default ManagerModels;
