import { useEffect, useState } from "react";
import carsApi from "../../api/carsApi";
import modelsApi from "../../api/modelsApi";
import TableCar from "../Table/TableCar";
import TableModel from "../Table/TableModel";
import Statistical from "../TopNav/Statistical";
import CommonSection from "../UI/CommonSection";
import CarBank from "../UI/CarBank";

const Dashboard = () => {
  // State
  const [carList, setCarList] = useState([]);
  const [countCar, setCountCar] = useState(0);
  const [countModel, setCountModel] = useState(0);
  const [modelList, setModelList] = useState([]);
  const [filters, setFilters] = useState({
    PageSize: 10,
    PageNumber: 1,
  });

  // Effect
  useEffect(() => {
    (async () => {
      try {
        const data = await carsApi.getAll(filters);
        const modelResponse = await modelsApi.getAll();

        setModelList(modelResponse.result);
        setCarList(data.result.items);
        setCountCar(data.result.items.length);
        setCountModel(modelResponse.result.length);
      } catch (error) {}
    })();
  }, [filters]);

  return (
    <>
      <div className="container-fluid px-4">
        <CommonSection title="Hệ thống quản trị" />
        <Statistical countCar={countCar} countModel={countModel} />
        <CarBank />
        <TableCar carList={carList} />
        <TableModel modelList={modelList} />
      </div>
    </>
  );
};
export default Dashboard;
