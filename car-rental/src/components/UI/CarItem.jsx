import React from "react";
import { Link } from "react-router-dom";
import { Col } from "reactstrap";
import "../../styles/car-item.css";

const CarItem = (props) => {
  const { name, price, thumbnail, urlSlug, model, maxSpeed } = props.item;

  const priceVnd = new Intl.NumberFormat("vi-VN", {
    style: "currency",
    currency: "VND",
  }).format(price);

  // handle img not found
  const img = thumbnail
    ? thumbnail
    : "https://placehold.co/600x400?text=Thumbnail";

  return (
    <Col lg="4" md="4" sm="6" className="mb-5">
      <div className="car__item">
        <div className="car__img">
          <img src={img} alt="" className="w-100" />
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

          <div className="d-flex justify-content-center">
            <button className="w-50 car__item-btn car__btn-details">
              <Link to={`/cars/${urlSlug}`}>Tất cả thông số</Link>
            </button>
          </div>
        </div>
      </div>
    </Col>
  );
};

export default CarItem;
