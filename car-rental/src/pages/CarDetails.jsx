import React, { useEffect, useState } from "react";

import { useParams } from "react-router-dom";
import { Col, Container, Row } from "reactstrap";
import { GetCurrency } from "../Utils/common";
import carsApi from "../api/carsApi";
import Helmet from "../components/Helmet/Helmet";
import Galery from "../components/UI/Galery";
import "../styles/car-detail.css";
import Comment from "../components/UI/Comment";
import commentApi from "../api/commentApi";

const CarDetails = () => {
  const { slug } = useParams();

  const [car, setCar] = useState({});
  const [comments, setComments] = useState([]);
  const [galeries, setGaleries] = useState([]);

  useEffect(() => {
    window.scrollTo(0, 0);
    (async () => {
      try {
        const data = await carsApi.getBySlug(slug);
        setCar(data.result);
        const galeriesData = await carsApi.getGaleriesByCarId(data.result.id);
        setGaleries(galeriesData.result);

        const commentsData = await carsApi.getCommentByIdCar(data.result.id);
        setComments(commentsData.result);
      } catch (error) {
        console.log("An error occurred, ", error);
      }
    })();
  }, [slug]);

  const handleOnSubmit = (value) => {
    console.log("🚀 ~ handleOnSubmit ~ value:", value);
    (async () => {
      // {
      //   "name": "Nga Nga",
      //   "description": "Xe này đẹp quá",
      //   "isApproved": true,
      //   "carId": 1
      // }
      const data = {
        ...value,
        isApproved: true,
        carId: car.id,
      };
      const response = await commentApi.add(data);
      const commentsData = await carsApi.getCommentByIdCar(car.id);
      console.log("🚀 ~ commentsData:", commentsData);
      setComments(commentsData.result);
      console.log("🚀 ~ response:", response);
    })();
  };

  return (
    <Helmet title={car?.name}>
      <section>
        <Container>
          <Row>
            <Col lg="6">
              <Galery
                img={
                  car?.thumbnail ||
                  "https://placehold.co/600x400?text=Thumbnail"
                }
                galeries={galeries}
              />
            </Col>

            <Col lg="6">
              <div className="car__info">
                <h2 className="section__title">{car?.name}</h2>

                <div className=" d-flex align-items-center gap-5 mb-4 mt-3 flex-wrap car__subdesc">
                  <h6 className="rent__price fw-bold fs-4">
                    ${GetCurrency(car?.price)}
                  </h6>
                  {car?.evaluate !== 0 ? (
                    <span className=" d-flex align-items-center gap-2">
                      <span style={{ color: "#f9a826" }}>
                        <i className="ri-star-s-fill"></i>
                        <i className="ri-star-s-fill"></i>
                        <i className="ri-star-s-fill"></i>
                        <i className="ri-star-s-fill"></i>
                        <i className="ri-star-s-fill"></i>
                      </span>
                      {car?.evaluate} ratings
                    </span>
                  ) : (
                    <span>{car?.evaluate} ratings</span>
                  )}
                </div>

                <p className="section__description">{car?.description}</p>

                <div
                  className=" d-flex align-items-start mt-3 flex-column"
                  style={{ columnGap: "4rem" }}
                >
                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-roadster-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Loại xe - {car?.model}
                  </span>

                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-settings-2-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Tự động
                  </span>

                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-timer-flash-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Tăng tốc từ 1 - 100km/h là {car?.speedUp} giây
                  </span>

                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-map-pin-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Công suất đến {car?.wattage} PS / 300 kW
                  </span>

                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-wheelchair-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Mô men xoắn cực đại - {car?.torque} Nm
                  </span>

                  <span className=" d-flex align-items-center gap-1 section__description">
                    <i
                      className="ri-building-2-line"
                      style={{ color: "#f9a826" }}
                    ></i>{" "}
                    Tốc độ tối đa - {car?.maxSpeed} km/h
                  </span>
                </div>
              </div>
            </Col>
          </Row>

          <Comment comments={comments} handleOnSubmit={handleOnSubmit} />
        </Container>
      </section>
    </Helmet>
  );
};

export default CarDetails;
