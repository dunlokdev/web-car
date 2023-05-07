import React, { useRef } from "react";
import { Link } from "react-router-dom";
import { Container, Row, Col, Form, FormGroup, Input } from "reactstrap";
import Helmet from "../components/Helmet/Helmet";
import CommonSection from "../components/UI/CommonSection";
import emailjs from "@emailjs/browser";

import "../styles/contact.css";
import "../styles/booking-form.css";
import Map from "../components/UI/Map";
import { useSnackbar } from "notistack";
import Loading from "../components/Loading/Loading";
import { useState } from "react";

const socialLinks = [
  {
    url: "#",
    icon: "ri-facebook-line",
  },
  {
    url: "#",
    icon: "ri-instagram-line",
  },
  {
    url: "#",
    icon: "ri-linkedin-line",
  },
  {
    url: "#",
    icon: "ri-twitter-line",
  },
];

const Contact = () => {
  const form = useRef();
  const { enqueueSnackbar, closeSnackbar } = useSnackbar();
  const [isLoading, setIsLoading] = useState(false);

  const sendEmail = (e) => {
    e.preventDefault();
    setIsLoading(true);
    enqueueSnackbar("Cảm ơn bạn vì đã phản hồi 🎉", {
      variant: "success",
    }); // show snackbark

    emailjs
      .sendForm(
        "service_44kk9hk",
        "template_tnx89ib",
        form.current,
        "jZ6iVcXE5C7ITnhhc"
      )
      .then(
        (result) => {
          console.log(result.text);
          setIsLoading(false);
        },
        (error) => {
          console.log(error.text);
        }
      );
  };

  return (
    <Helmet title="Contact">
      {isLoading && <Loading />}
      <CommonSection title="Contact" />
      <section>
        <Container>
          <Row className="justify-content-around">
            <Col lg="5" md="5">
              <div className="contact__info mb-3 shadow p-3 mb-5 bg-white rounded">
                <h6 className="fw-bold">Thông tin liên hệ</h6>
                <p className="section__description mb-0">
                  Số 5, Dường Thống Nhất, huyện Lạc Dương
                </p>
                <div className=" d-flex align-items-center gap-2">
                  <h6 className="fs-6 mb-0">Phone:</h6>
                  <p className="section__description mb-0">0916 203 153</p>
                </div>

                <div className=" d-flex align-items-center gap-2">
                  <h6 className="mb-0 fs-6">Email:</h6>
                  <p className="section__description mb-0">
                    dunlokphuongnga@gmail.com
                  </p>
                </div>

                <h6 className="fw-bold mt-4">Follow Us</h6>

                <div className=" d-flex align-items-center gap-4 mt-3">
                  {socialLinks.map((item, index) => (
                    <Link
                      to={item.url}
                      key={index}
                      className="social__link-icon"
                    >
                      <i className={item.icon}></i>
                    </Link>
                  ))}
                </div>
              </div>

              <h6 className="fw-bold mb-4">Liên hệ với chúng tôi</h6>

              <form ref={form} onSubmit={sendEmail}>
                <FormGroup className="contact__form">
                  <Input
                    placeholder="Your Name"
                    type="text"
                    name="user_name"
                    required
                  />
                </FormGroup>
                <FormGroup className="contact__form">
                  <Input
                    placeholder="Email"
                    type="email"
                    name="user_email"
                    required
                  />
                </FormGroup>
                <FormGroup className="contact__form">
                  <textarea
                    name="message"
                    rows="5"
                    placeholder="Message"
                    className="textarea"
                    required
                  ></textarea>
                </FormGroup>

                <button className=" contact__btn" type="submit">
                  Send Message
                </button>
              </form>
            </Col>
            <Col lg={6} md={6}>
              <Map />
            </Col>
          </Row>
        </Container>
      </section>
    </Helmet>
  );
};

export default Contact;
