import { Link, NavLink } from "react-router-dom";
import { Container, Row, Col } from "reactstrap";
import "../../styles/header.css";
import { useRef } from "react";

// Routes
const navLinks = [
  {
    path: "/home",
    display: "Trang chủ",
  },
  {
    path: "/about",
    display: "Về Đà Lạt Auto",
  },
  {
    path: "/cars",
    display: "Siêu xe",
  },

  {
    path: "/blogs",
    display: "Tin tức",
  },
  {
    path: "/contact",
    display: "Liên hệ",
  },
];

const Header = () => {
  const menuRef = useRef(null);

  // Get current class to swap moble/pc
  const toggleMenu = () => menuRef.current.classList.toggle("menu__active");

  return (
    <header className="header">
      {/* ============= Header top ============== */}
      <div className="header__top">
        <Container>
          <Row>
            <Col lg="6" md="6" sm="6">
              <div className="header__top__left">
                <span>Cần giúp đỡ?</span>
                <span className="header__top__help">
                  <i className="ri-phone-fill"></i> 0916 203 153
                </span>
              </div>
            </Col>

            <Col lg="6" md="6" sm="6">
              <div className="header__top__right d-flex align-items-center justify-content-end gap-3">
                <Link to="#" className="d-flex align-items-center gap-1">
                  <i className="ri-login-circle-line"></i> Đăng nhập
                </Link>

                <Link to="#" className="d-flex align-items-center gap-1">
                  <i className="ri-user-line"></i> Đăng ký
                </Link>
              </div>
            </Col>
          </Row>
        </Container>
      </div>

      {/* ============= Header middle ============== */}
      <div className="header__middle">
        <Container>
          <Row className="d-flex align-items-center">
            <Col lg="4" md="3" sm="4">
              <div className="logo">
                <h1>
                  <Link to="/home" className=" d-flex align-items-center gap-2">
                    <i className="ri-car-line"></i>
                    <span>
                      Đà Lạt <br /> Auto
                    </span>
                  </Link>
                </h1>
              </div>
            </Col>

            <Col lg="3" md="3" sm="4">
              <div className="header__location d-flex align-items-center gap-2">
                <span>
                  <i className="ri-map-pin-line" />
                </span>
                <div className="header__location-content">
                  <h4>Đà Lạt</h4>
                  <h6>1 Đường Phù Đổng Thiên Vương, Phường 8</h6>
                </div>
              </div>
            </Col>

            <Col lg="3" md="3" sm="4">
              <div className="header__location d-flex align-items-center gap-2">
                <span>
                  <i className="ri-time-line"></i>
                </span>
                <div className="header__location-content">
                  <h4>Thứ 2 - Thứ 7</h4>
                  <h6>10am - 7pm</h6>
                </div>
              </div>
            </Col>

            <Col
              lg="2"
              md="3"
              sm="0"
              className=" d-flex align-items-center justify-content-end "
            >
              <button className="header__btn btn ">
                <Link to="/contact">Liên hệ công việc</Link>
              </button>
            </Col>
          </Row>
        </Container>
      </div>

      {/* ========== main navigation =========== */}
      <div className="main__navbar">
        <Container>
          <div className="navigation__wrapper d-flex align-items-center justify-content-between">
            <span className="mobile__menu">
              <i class="ri-menu-line" onClick={toggleMenu}></i>
            </span>

            <div className="navigation" ref={menuRef} onClick={toggleMenu}>
              <div className="menu">
                {navLinks.map((item, index) => (
                  <NavLink
                    to={item.path}
                    className={(navClass) =>
                      navClass.isActive ? "nav__active nav__item" : "nav__item"
                    }
                    key={index}
                  >
                    {item.display}
                  </NavLink>
                ))}
              </div>
            </div>

            <div className="nav__right">
              <div className="search__box">
                <input type="text" placeholder="Search" />
                <span>
                  <i class="ri-search-line"></i>
                </span>
              </div>
            </div>
          </div>
        </Container>
      </div>
    </header>
  );
};
export default Header;
