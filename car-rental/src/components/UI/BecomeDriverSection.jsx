import React from "react";
import { Col, Container, Row } from "reactstrap";
import "../../styles/become-driver.css";

import driverImg from "../../assets/all-images/cars-img/car-6.png";
import { Link } from "react-router-dom";

const BecomeDriverSection = () => {
  return (
    <section className="become__driver">
      <Container>
        <Row>
          <Col lg="6" md="6" sm="12" className="become__driver-img">
            <img src={driverImg} alt="" className="w-100" />
          </Col>

          <Col lg="6" md="6" sm="12">
            <h2 className="section__title become__driver-title">
              Chúng tôi đặt ra những tiêu chuẩn cao cấp.
            </h2>

            <Link to={`/about`} className="btn become__driver-btn mt-4">
              Hãy chọn chúng tôi
            </Link>
          </Col>
        </Row>
      </Container>
    </section>
  );
};

export default BecomeDriverSection;
