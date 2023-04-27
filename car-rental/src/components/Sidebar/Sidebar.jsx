import { Link, NavLink } from "react-router-dom";
import "../../styles/common.css";

const Sidebar = () => {
  return (
    <div className="bg-white" id="sidebar-wrapper">
      <div className="sidebar-heading text-center py-4 primary-text fs-4 fw-bold text-uppercase border-bottom">
        <i className="fas fa-user-secret me-2"></i>Dunlok Dev
      </div>
      <div className="list-group list-group-flush my-3">
        <NavLink
          to="/admin"
          end
          className="list-group-item list-group-item-action bg-transparent second-text"
        >
          <i className="fas fa-tachometer-alt me-2"></i>Dashboard
        </NavLink>
        <NavLink
          to="/admin/models"
          className="list-group-item list-group-item-action bg-transparent second-text fw-bold"
        >
          <i className="fas fa-project-diagram me-2"></i>Quản lý model
        </NavLink>
        <NavLink
          to="/admin/cars"
          className="list-group-item list-group-item-action bg-transparent second-text fw-bold"
        >
          <i className="fas fa-chart-line me-2"></i>Quản lý xe
        </NavLink>
        <NavLink
          to="/admin/posts"
          className="list-group-item list-group-item-action bg-transparent second-text fw-bold"
        >
          <i className="fas fa-chart-line me-2"></i>Quản lý bài viết
        </NavLink>
      </div>
    </div>
  );
};
export default Sidebar;
