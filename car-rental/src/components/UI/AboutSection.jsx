import React from "react";
import { Container, Row, Col } from "reactstrap";
import "../../styles/about-section.css";
import aboutImg from "../../assets/all-images/cars-img/car-4.png";

const AboutSection = ({ aboutClass }) => {
  return (
    <section
      className="about__section"
      style={
        aboutClass === "aboutPage"
          ? { marginTop: "0px" }
          : { marginTop: "50px" }
      }
    >
      <Container>
        <Row className="align-items-center">
          <Col lg="6" md="6">
            <div className="about__section-content">
              <h4 className="section__subtitle">Về chúng tôi</h4>
              <h2 className="section__title">Porsche Việt Nam</h2>
              <p className="section__description">
                Thành lập từ năm 2007, Porsche đã đánh dấu một thập kỷ tại thị
                trường Việt Nam và đang phát triển vững mạnh, xác lập vị thế
                hàng đầu trong phân khúc xe hơi thể thao hạng sang. Hiện,
                Porsche có hai trung tâm: Porsche Sài Gòn, thành lập vào năm
                2008 và trung tâm […]
              </p>
            </div>
            <div className="about__section-more">
              <button className="btn">Khám phá thêm</button>
            </div>
          </Col>

          <Col lg="6" md="6">
            <div className="about__img">
              <img src={aboutImg} alt="" className="w-100" />
            </div>
          </Col>
        </Row>
      </Container>
    </section>
  );
};

export default AboutSection;
