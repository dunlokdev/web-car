import React from "react";
import "../../styles/become-driver.css";
import { Container, Row, Col } from "reactstrap";

import driverImg from "../../assets/all-images/cars-img/car-5.png";

const BecomeDriverSection = () => {
  return (
    <section className="become__driver">
      <Container>
        <Row className="align-items-center">
          <Col lg="6" md="6" sm="12" className="become__driver-img">
            <img src={driverImg} alt="" className="w-100" />
          </Col>

          <Col lg="6" md="6" sm="12">
            <h2 className="section__title become__driver-title">
              <span className="primary">Hãy chọn Porsche.</span>
              <span className="sub">
                Bạn muốn điều gì đó thật đặc biệt. Đó là lí do tại sao bạn lái
                một chiếc Porsche. Và tại sao bạn xứng đáng nhận được một dịch
                vụ đặc biệt tương xứng. Tinh tế, chuyên nghiệp và cực kỳ mạnh
                mẽ. Trên tất cả: dành riêng cho yêu cầu chính xác của bạn. Đó
                chính là chuẩn Porsche.
                <br />
                Bất kể là dòng xe cổ điển hay hiện đại, hay dòng xe GT. Chúng
                tôi sẽ dành sự phục vụ tốt nhất cho chiếc Porsche của bạn – cho
                việc bảo trì, bảo dưỡng và sửa chữa. Và với đội ngũ Porsche
                Genuine Parts, bạn sẽ được đảm bảo rằng mọi thứ sẽ được hoàn hảo
                như nguyên bản ban đầu.
              </span>
            </h2>
          </Col>
        </Row>
      </Container>
    </section>
  );
};

export default BecomeDriverSection;
