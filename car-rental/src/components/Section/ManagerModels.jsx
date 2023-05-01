import { useEffect, useState } from "react";
import modelsApi from "../../api/modelsApi";
import TableModel from "../Table/TableModel";
import CommonSection from "../UI/CommonSection";

const ManagerModels = () => {
  // State
  const [modelList, setModelList] = useState([]);
  const [filter, setFilters] = useState({
    PageSize: 100,
    PageNumber: 1,
    SortColumn: "Name",
    SortOrder: "ASC",
  });

  // Effect
  useEffect(() => {
    (async () => {
      try {
        const { result } = await modelsApi.getAll();
        setModelList(result);
      } catch (error) {}
    })();
  }, []);

  return (
    <>
      <CommonSection title="Quản lý dòng xe" />
      <div className="manager-models px-4">
        <TableModel modelList={modelList} />
      </div>
    </>
  );
};
export default ManagerModels;
