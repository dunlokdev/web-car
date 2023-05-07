import { useEffect, useState } from "react";
import carsApi from "../../api/carsApi";
import modelsApi from "../../api/modelsApi";
import Statistical from "../TopNav/Statistical";
import CarBank from "../UI/CarBank";
import CommonSection from "../UI/CommonSection";

const Dashboard = () => {
  // State
  const [countCar, setCountCar] = useState(0);
  const [countModel, setCountModel] = useState(0);
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
        setCountCar(data.result.items.length);
        setCountModel(modelResponse.result.length);
      } catch (error) {}
    })();
  }, [filters]);

  return (
    <>
      <CommonSection title="Hệ thống quản trị" />
      <div className="container-fluid px-4">
        <Statistical countCar={countCar} countModel={countModel} />
        <CarBank />
      </div>
    </>
  );
};
export default Dashboard;
