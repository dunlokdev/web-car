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
              <h2 className="section__title">Porsche Đà Lạt</h2>
              <p className="section__description">
                Thành lập từ năm 2007, Porsche đã đánh dấu một thập kỷ tại thị
                trường Việt Nam và đang phát triển vững mạnh, xác lập vị thế
                hàng đầu trong phân khúc xe hơi thể thao hạng sang. Hiện,
                Porsche có hai trung tâm: Porsche Sài Gòn, thành lập vào năm
                2008 và trung tâm […]
              </p>
            </div>
            <div className="about__section-item d-flex flex-column align-items-start justify-content-center">
              <p className="section__description d-flex align-items-center gap-2">
                <i className="ri-checkbox-circle-line"></i>
                Porsche là thương hiệu sản xuất xe hybrid đầu tiên trên thế giới
              </p>

              <p className="section__description d-flex align-items-center gap-2">
                <i className="ri-checkbox-circle-line"></i>
                Logo “ngựa chồm” của Ferrari và Porsche đều xuất phát từ một nơi
              </p>

              <p className="section__description d-flex align-items-center gap-2">
                <i className="ri-checkbox-circle-line"></i>
                Porsche thiết kế Volkswagen Beetle cho Adolf Hitler
              </p>

              <p className="section__description d-flex align-items-center gap-2">
                <i className="ri-checkbox-circle-line"></i>
                Kỷ lục trên đường đua Nürburgring được thiết lập 30 năm trước
              </p>
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
