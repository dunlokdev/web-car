import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Col, Container, Row } from "reactstrap";
import carsApi from "../api/carsApi";
import modelsApi from "../api/modelsApi";
import Helmet from "../components/Helmet/Helmet";
import CarItem from "../components/UI/CarItem";
import CommonSection from "../components/UI/CommonSection";
import Pager from "../components/UI/Pager";

const CarListing = () => {
  const { slug } = useParams();

  // State
  const [carList, setCarList] = useState([]);
  const [metadata, setMetadata] = useState([]);
  const [models, setModels] = useState([]);
  const [filters, setFilters] = useState({
    PageSize: 6,
    PageNumber: 1,
  });

  const [keyword, setKeyword] = useState("");
  const [sortOrder, setSortOrder] = useState("ASC");
  const [sortColumn, setSortColumn] = useState("Name");
  const [modelId, setModelId] = useState(0);

  // Effect
  useEffect(() => {
    window.scrollTo(0, 50);
    (async () => {
      console.log("Hello");
      try {
        let data = [];
        if (slug) {
          console.log("🚀 ~ slug:", slug);
          data = await modelsApi.getCarByModelSlug(slug, filters);
          console.log("🚀 ~ data:", data);
        } else {
          data = await carsApi.getAll(filters);
        }
        const response = await modelsApi.getAll();
        const models = response.result.map((item, index) => {
          return {
            id: item.id,
            name: item.name,
            urlSlug: item.urlSlug,
          };
        });

        setModels(models);
        setMetadata(data.result.metadata);
        setCarList(data.result.items);
      } catch (error) {}
    })();
  }, [filters, slug]);

  const handleChange = (e) => {
    let sortOrder = e.target.value;
    let sortColumn = "Price";
    if (!sortOrder) {
      sortColumn = "Name";
      sortOrder = "ASC";
    }

    setSortOrder(sortOrder);
    setSortColumn(sortColumn);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    let value = {};

    if (modelId > 0) {
      value = {
        ...filters,
        SortColumn: sortColumn,
        SortOrder: sortOrder,
        Keyword: keyword,
        ModelId: +modelId,
      };
      setFilters(value);
      console.log("🚀 ~ handleSubmit ~ value:", value);

      return;
    }
    console.log("hanlde on submit");

    value = {
      ...filters,
      SortColumn: sortColumn,
      SortOrder: sortOrder,
      Keyword: keyword,
    };
    console.log("🚀 ~ handleSubmit ~ value:", value);

    setFilters(value);
  };

  const handlePageChange = (value) => {
    setFilters({ ...filters, PageNumber: value });
  };

  const handleUnFilter = () => {
    console.log("Handle un filter");
    setKeyword("");
    setModelId(0);
    setSortOrder("ASC");
    setSortColumn("Name");

    const value = {
      ...filters,
      SortColumn: sortColumn,
      SortOrder: sortOrder,
      Keyword: keyword,
      ModelId: modelId,
    };
    setFilters(value);
  };

  return (
    <Helmet title="Cars">
      {slug ? (
        <CommonSection title={`${slug}`} />
      ) : (
        <CommonSection title="Danh sách xe" />
      )}

      <section>
        <Container>
          <Row>
            <Col lg="12">
              <form onSubmit={handleSubmit}>
                <div className=" d-flex align-items-center gap-3 mb-5">
                  <span className=" d-flex align-items-center gap-2">
                    <i className="ri-sort-asc"></i> Sắp xếp theo
                  </span>

                  <select
                    className="form-select"
                    onChange={handleChange}
                    style={{ width: "150px" }}
                    value={sortOrder}
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
                    name="ModelId"
                    style={{ width: "150px" }}
                    className="form-select"
                    value={modelId}
                    onChange={(e) => {
                      setModelId(e.target.value);
                    }}
                  >
                    <option value="">Tất cả</option>
                    {models.map((item) => (
                      <option key={item.id} value={item.id}>
                        {item.name}
                      </option>
                    ))}
                  </select>

                  <div className="input-group w-25">
                    <div className="form-control">
                      <input
                        style={{ outline: "none", border: "none" }}
                        type="text"
                        placeholder="Tìm kiếm"
                        value={keyword}
                        onChange={(e) => setKeyword(e.target.value)}
                      />
                    </div>
                  </div>

                  <button type="submit" className="btn btn-sm">
                    Lọc
                  </button>

                  <button className="btn btn-sm" onClick={handleUnFilter}>
                    Bỏ lọc
                  </button>
                </div>
              </form>
            </Col>

            {carList.length > 0 ? (
              carList.map((item, index) => (
                <CarItem item={item} key={item.id} />
              ))
            ) : (
              <h2 className="section__title py-5">Không tìm thấy sản phẩm</h2>
            )}

            <Pager metadata={metadata} handlePageChange={handlePageChange} />
          </Row>
        </Container>
      </section>
    </Helmet>
  );
};

export default CarListing;
