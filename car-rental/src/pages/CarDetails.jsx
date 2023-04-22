import React, { useEffect, useState } from "react";

import { useParams } from "react-router-dom";
import { Col, Container, Row } from "reactstrap";
import { GetCurrency } from "../Utils/common";
import carsApi from "../api/carsApi";
import Helmet from "../components/Helmet/Helmet";

const CarDetails = () => {
  const { slug } = useParams();

  const [car, setCar] = useState({});

  useEffect(() => {
    window.scrollTo(0, 0);
    (async () => {
      try {
        const data = await carsApi.getBySlug(slug);
        setCar(data.result);
        console.log("data.result: ", data.result);
      } catch (error) {}
    })();
  }, [slug]);

  return (
    <Helmet title={car?.name}>
      <section>
        <Container>
          <Row>
            <Col lg="6">
              <img src={car?.thumbnail} alt="" className="w-100" />
            </Col>

            <Col lg="6">
              <div className="car__info">
                <h2 className="section__title">{car?.name}</h2>

                <div className=" d-flex align-items-center gap-5 mb-4 mt-3">
                  <h6 className="rent__price fw-bold fs-4">
                    ${GetCurrency(car?.price)}
                  </h6>

                  <span className=" d-flex align-items-center gap-2">
                    <span style={{ color: "#f9a826" }}>
                      <i className="ri-star-s-fill"></i>
                      <i className="ri-star-s-fill"></i>
                      <i className="ri-star-s-fill"></i>
                      <i className="ri-star-s-fill"></i>
                      <i className="ri-star-s-fill"></i>
                    </span>
                    ({car?.evaluate} ratings)
                  </span>
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
                    Tăng tốc từ 0 - 100 km/giờ (0 - 62 dặm/giờ) - {car?.speedUp}{" "}
                    giây
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

            {/* <Col lg="7" className="mt-5">
              <div className="booking-info mt-5">
                <h5 className="mb-4 fw-bold ">Booking Information</h5>
                <BookingForm />
              </div>
            </Col>

            <Col lg="5" className="mt-5">
              <div className="payment__info mt-5">
                <h5 className="mb-4 fw-bold ">Payment Information</h5>
                <PaymentMethod />
              </div>
            </Col> */}
          </Row>
        </Container>
      </section>
    </Helmet>
  );
};

export default CarDetails;
