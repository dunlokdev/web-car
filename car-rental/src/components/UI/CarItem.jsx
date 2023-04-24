import React from "react";
import { Col } from "reactstrap";
import { Link } from "react-router-dom";
import "../../styles/car-item.css";
import img01 from "../../assets/all-images/cars-img/car-4.png";

const CarItem = (props) => {
  const {
    name,
    price,
    discount,
    thumbnail,
    description,
    urlSlug,
    model,
    maxSpeed,
  } = props.item;

  const priceVnd = new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(price);

  return (
    <Col lg="4" md="4" sm="6" className="mb-5">
      <div className="car__item">
        <div className="car__img">
          <img src={thumbnail} alt="" className="w-100" />
        </div>

        <div className="car__item-content mt-4">
          <h4 className="section__title text-center">{name}</h4>
          <h6 className="rent__price text-center mt-">
            Giá tiêu chuẩn: ${priceVnd}*
          </h6>

          <div className="car__item-info d-flex align-items-center justify-content-between mt-3 mb-4">
            <span className=" d-flex align-items-center gap-1">
              <i className="ri-car-line"></i> Dòng xe - {model}
            </span>
            <span className=" d-flex align-items-center gap-1">
              <i className="ri-settings-2-line"></i> Tự động
            </span>
            <span className=" d-flex align-items-center gap-1">
              <i className="ri-timer-flash-line"></i> Tốc độ {maxSpeed}km/h
            </span>
          </div>

          <button className=" w-50 car__item-btn car__btn-rent">
            <Link to={`/cars/${urlSlug}`}>Khám phá</Link>
          </button>

          <button className=" w-50 car__item-btn car__btn-details">
            <Link to={`/cars/${urlSlug}`}>Đặt mua</Link>
          </button>
        </div>
      </div>
    </Col>
  );
};

export default CarItem;
