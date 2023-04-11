import { useState } from "react";
import "../../styles/admin-layout.css";
import SideBar from "../dashboard/SideBar";
import { FaBars } from "react-icons/fa";

const AdminLayout = () => {
  const [collapsed, setCollapsed] = useState(false);

  return (
    <>
      <div className="d-flex">
        <div>
          <SideBar collapsed={collapsed} />
        </div>
        <div>
          <FaBars onClick={() => setCollapsed(!collapsed)} /> content goes here
        </div>
      </div>
    </>
  );
};
export default AdminLayout;
