import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import { Col, Container, Row } from "reactstrap";
import carsApi from "../api/carsApi";
import modelsApi from "../api/modelsApi";
import Helmet from "../components/Helmet/Helmet";
import CarItem from "../components/UI/CarItem";
import CommonSection from "../components/UI/CommonSection";
import { useRef } from "react";

const CarListing = () => {
  const { slug } = useParams();

  // State
  const [carList, setCarList] = useState([]);
  const [filters, setFilters] = useState({
    PageSize: 10,
    PageNumber: 1,
    SortColumn: "Name",
    SortOrder: "ASC",
  });

  // Effect
  useEffect(() => {
    (async () => {
      try {
        let data = [];
        if (slug) {
          data = await modelsApi.getCarByModelSlug(slug, filters);
        } else {
          data = await carsApi.getAll(filters);
        }
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

    console.log("sortColumn: ", sortColumn);
    console.log("sortOrder: ", sortOrder);
    setFilters({ ...filters, SortColumn: sortColumn, SortOrder: sortOrder });
  };

  if (carList.length > 0) {
    return (
      <Helmet title="Cars">
        {slug ? (
          <CommonSection title={`Danh sách xe - Phiên bản ${slug}`} />
        ) : (
          <CommonSection title="Danh sách xe" />
        )}

        <section>
          <Container>
            <Row>
              <Col lg="12">
                <div className=" d-flex align-items-center gap-3 mb-5">
                  <span className=" d-flex align-items-center gap-2">
                    <i className="ri-sort-asc"></i> Sắp xếp theo
                  </span>

                  <select onChange={handleChange}>
                    <option value=""> -- Giá --</option>
                    <option value="ASC">Thấp đến cao</option>
                    <option value="DESC">Cao đến thấp</option>
                  </select>
                </div>
              </Col>

              {carList.map((item, index) => (
                <CarItem item={item} key={item.id} />
              ))}
            </Row>
          </Container>
        </section>
      </Helmet>
    );
  } else {
    return (
      <>
        <h2 className="section__title py-5">Không có sản phẩm</h2>
      </>
    );
  }
};

export default CarListing;
