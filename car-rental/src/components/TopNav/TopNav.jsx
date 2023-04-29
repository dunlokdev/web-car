import { Link } from "react-router-dom";

const TopNav = ({ onToggle, toggle }) => {
  return (
    <>
      <div className="d-flex align-items-center">
        <i
          className="fas fa-align-left primary-text fs-4 me-3"
          id="menu-toggle"
          onClick={() => onToggle(!toggle)}
        ></i>
        <h2 className="fs-2 m-0">Porsche Đà Lạt</h2>
      </div>
    </>
  );
};
export default TopNav;
