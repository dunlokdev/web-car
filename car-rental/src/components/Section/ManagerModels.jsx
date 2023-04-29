import { useEffect, useState } from "react";
import modelsApi from "../../api/modelsApi";
import TableModel from "../Table/TableModel";
import CommonSection from "../UI/CommonSection";
import FilterPane from "../UI/FilterPane";

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
  });

  return (
    <>
      <CommonSection title="Quản lý dòng xe" />
      <FilterPane />
      <div className="manager-models px-4">
        <TableModel modelList={modelList} />
      </div>
    </>
  );
};
export default ManagerModels;
