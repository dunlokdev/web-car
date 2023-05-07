import { React, useEffect } from "react";

import { Col, Container, Row } from "reactstrap";
import Helmet from "../components/Helmet/Helmet";
import AboutSection from "../components/UI/AboutSection";
import CommonSection from "../components/UI/CommonSection";

import driveImg from "../assets/all-images/drive.jpg";
import Map from "../components/UI/Map";

const About = () => {
  useEffect(() => {
    window.scrollTo(0, 0);
  }, []);

  return (
    <Helmet title="About">
      <CommonSection title="About Us" />
      <AboutSection aboutClass="aboutPage" />

      <section className="about__page-section">
        <Container>
          <Row>
            <Col lg="6" md="6" sm="12">
              <div className="about__page-img">
                <img src={driveImg} alt="" className="w-100 rounded-3" />
              </div>
            </Col>

            <Col lg="6" md="6" sm="12">
              <div className="about__page-content">
                <h2 className="section__title">
                  We Are Committed To Provide Safe Ride Solutions
                </h2>

                <p className="section__description">
                  Thành lập từ năm 2007, Porsche đã đánh dấu một thập kỷ tại thị
                  trường Việt Nam và đang phát triển vững mạnh, xác lập vị thế
                  hàng đầu trong phân khúc xe hơi thể thao hạng sang. Hiện,
                  Porsche có hai trung tâm: Porsche Sài Gòn, thành lập vào năm
                  2008 và trung tâm Porsche Hà Nội, thành lập năm 2012 với cơ sở
                  hạ tầng và trang thiết bị hiện đại cùng đội ngũ gần 100 nhân
                  viên, cung cấp những dịch vụ theo tiêu chuẩn của Porsche toàn
                  cầu. Porsche mang đến thị trường Việt Nam các dòng xe đậm chất
                  thể thao bao gồm: dòng xe 911 huyền thoại, dòng xe “roadster”
                  718 Boxster, dòng xe coupe 718 Cayman, dòng xe Gran Turismo
                  Panamera, dòng xe SUV Cayenne và dòng xe SUV cỡ trung Macan.
                  Đặc biệt, Taycan, phiên bản thương mại của dòng xe vận hành
                  hoàn toàn bằng điện đầu tiên của Porsche đã được chính thức
                  giới thiệu và sẽ thiết lập các tiêu chuẩn cho công nghệ di
                  động trong tương lai. Bên cạnh đó, khả năng cá nhân hóa tối ưu
                  và tính thể thao ở mỗi dòng xe chính là yếu tố tạo nên sự độc
                  đáo của thương hiệu xe thể thao Porsche. Bên cạnh lĩnh vực
                  kinh doanh xe, đóng góp không nhỏ vào hoạt động kinh doanh đó
                  chính là các hiệu ứng cộng hưởng tích cực và sự phát triển ở
                  mọi lĩnh vực, điển hình như dịch vụ Hậu mãi, Trang Thiết Bị
                  Đặc Biệt của Porsche (Tequipment), Bộ Sưu Tập Thời Trang
                  Porsche (Porsche Lifestyle) và nhiều dịch vụ cao cấp khác. Tất
                  cả lĩnh vực đều mang bản sắc và giá trị đẳng cấp của Porsche.
                  Porsche Việt Nam sẽ tiếp tục giới thiệu những dòng xe hấp dẫn,
                  hệ thống dịch vụ chuyên nghiệp cùng những trải nghiệm đầy cảm
                  xúc đến những người yêu mến Porsche.
                </p>

                <div className=" d-flex align-items-center gap-3 mt-4">
                  <span className="fs-4">
                    <i className="ri-phone-line"></i>
                  </span>

                  <div>
                    <h6 className="section__subtitle">Need Any Help?</h6>
                    <h4>+00123456789</h4>
                  </div>
                </div>
              </div>
            </Col>
          </Row>
        </Container>
        <Map />
      </section>
    </Helmet>
  );
};

export default About;
