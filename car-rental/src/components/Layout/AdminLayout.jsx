import { useState } from "react";
import { Outlet } from "react-router";
import "../../styles/admin-layout.css";
import "../../styles/common.css";
import Sidebar from "../Sidebar/Sidebar";
import TopNav from "../TopNav/TopNav";

const AdminLayout = () => {
  const [toggle, setToggle] = useState(false);

  const handleToggle = (value) => {
    setToggle(value);
  };
  return (
    <>
      <div className={`d-flex ${toggle ? "toggled" : ""}`} id="wrapper">
        <Sidebar />
        <div id="page-content-wrapper">
          <nav className="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
            <TopNav onToggle={handleToggle} toggle={toggle} />
          </nav>
          <Outlet />
        </div>
      </div>
    </>
  );
};
export default AdminLayout;
