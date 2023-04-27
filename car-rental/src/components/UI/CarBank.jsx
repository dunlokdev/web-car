import "../../styles/car-bank.css";
import logo from "../../assets/mastercard.png";
const CarBank = () => {
  return (
    <>
      <div className="card-banking mt-3">
        <div className="card-body">
          <div className="card-top">
            <h5 className="card-bank-name">Agribank</h5>
          </div>
          <div className="card-middle">
            <h3 className="card-id-bank">11 09 2002</h3>
          </div>
          <div className="card-bottom">
            <div className="card-info">
              <span>Tên người dùng</span>
              <h3>Lê Thị Phương Nga</h3>
            </div>
            <div className="card-info">
              <span>Hạn thẻ</span>
              <h3>07/05</h3>
            </div>
            <div className="card-logo">
              <img src={logo} alt="" />
            </div>
          </div>
        </div>
        <div className="card-mask"></div>
      </div>
    </>
  );
};
export default CarBank;
