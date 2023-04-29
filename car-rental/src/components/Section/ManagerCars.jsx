import { useEffect, useState } from "react";
import { Col } from "reactstrap";
import carsApi from "../../api/carsApi";
import modelsApi from "../../api/modelsApi";
import TableCar from "../Table/TableCar";
import CommonSection from "../UI/CommonSection";

const ManagerCars = () => {
  // State
  const [carList, setCarList] = useState([]);
  const [filters, setFilters] = useState({
    PageSize: 100,
    PageNumber: 1,
    SortColumn: "Name",
    SortOrder: "ASC",
  });

  const [models, setModels] = useState([]);
  const [keyword, setKeyword] = useState("");

  // Effect
  useEffect(() => {
    (async () => {
      try {
        const { result } = await carsApi.getAll(filters);
        const response = await modelsApi.getAll();
        const models = response.result.map((item, index) => {
          return {
            id: item.id,
            name: item.name,
            urlSlug: item.urlSlug,
          };
        });

        setCarList(result.items);
        setModels(models);
      } catch (error) {}
    })();
  }, [filters]);

  const handleSortChange = (e) => {
    let sortOrder = e.target.value;
    let sortColumn = "Price";
    if (!sortOrder) {
      sortColumn = "Name";
      sortOrder = "ASC";
    }

    setFilters({ ...filters, SortColumn: sortColumn, SortOrder: sortOrder });
  };

  const handleModelChange = (e) => {
    if (!e.target.value) {
      setFilters({ ...filters });
      return;
    }
    const slug = e.target.value;

    (async () => {
      const data = await modelsApi.getCarByModelSlug(slug, {
        PageSize: 100,
        PageNumber: 1,
      });
      console.log("data: ", data);
      setCarList(data.result.items);
    })();
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    setFilters({ ...filters, Keyword: keyword });
    setKeyword("");
  };

  const handleResetFilter = () => {};

  return (
    <>
      <CommonSection title="Quản lý xe" />

      <Col lg="12" className="px-4 pt-4">
        <div className=" d-flex align-items-center gap-3 mb-5">
          <span className=" d-flex align-items-center gap-2">
            <i className="ri-sort-asc"></i> Sắp xếp theo
          </span>

          <select
            style={{ width: "150px" }}
            className="form-select"
            onChange={handleSortChange}
          >
            <option value=""> A-Z </option>
            <option value="ASC">Thấp đến cao</option>
            <option value="DESC">Cao đến thấp</option>
          </select>

          <span className="d-flex align-items-center gap-2">
            <i className="ri-car-line"></i> Dòng xe
          </span>
          <select
            title="Dòng xe"
            name="authorId"
            style={{ width: "150px" }}
            className="form-select"
            onChange={handleModelChange}
          >
            <option value=""> Tất cả</option>
            {models.map((item) => (
              <option key={item.id} value={item.urlSlug}>
                {item.name}
              </option>
            ))}
          </select>

          <form onSubmit={handleSubmit}>
            <div className="input-group">
              <div className="form-control">
                <input
                  style={{ outline: "none", border: "none" }}
                  type="text"
                  placeholder="Tìm kiếm"
                  value={keyword}
                  onChange={(e) => setKeyword(e.target.value)}
                />
              </div>
              <button onChange={handleResetFilter} className="btn btn-sm">
                <i className="ri-search-line"></i>
              </button>
            </div>
          </form>

          <button className="btn">
            <i className="ri-add-fill"></i>
          </button>
        </div>
      </Col>

      <div className="manager-cars px-4">
        <TableCar carList={carList} />
      </div>
    </>
  );
};
export default ManagerCars;
