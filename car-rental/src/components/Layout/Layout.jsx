import { Outlet } from "react-router-dom";
import Routers from "../../routers/Routers";
import Footer from "../Footer/Footer";
import Header from "../Header/Header";

const Layout = () => {
  return (
    <>
      <Header />
      <div>
        {/* <Routers /> */}
        <Outlet />
      </div>
      <Footer />
    </>
  );
};
export default Layout;
