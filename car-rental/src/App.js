import { Route, Routes } from "react-router-dom";
import AdminLayout from "./components/Layout/AdminLayout";
import Layout from "./components/Layout/Layout";
import About from "./pages/About";
import Blog from "./pages/Blog";
import BlogDetails from "./pages/BlogDetails";
import CarDetails from "./pages/CarDetails";
import CarListing from "./pages/CarListing";
import Contact from "./pages/Contact";
import Home from "./pages/Home";
import NotFound from "./pages/NotFound";
import Dashboard from "./components/Section/Dashboard";
import ManagerModels from "./components/Section/ManagerModels";
import ManagerCars from "./components/Section/ManagerCars";
import ManagerPosts from "./components/Section/ManagerPosts";

function App() {
  return (
    <>
      <Routes>
        <Route path="/admin" element={<AdminLayout />}>
          <Route index element={<Dashboard />} />
          <Route path="models" element={<ManagerModels />} />
          <Route path="cars" element={<ManagerCars />} />
          <Route path="posts" element={<ManagerPosts />} />
        </Route>
        <Route path="/" element={<Layout />} exact>
          <Route index element={<Home />} />
          <Route path="about" element={<About />} />
          <Route path="cars" element={<CarListing />} />
          <Route path="cars/models/:slug" element={<CarListing />} />
          <Route path="cars/:slug" element={<CarDetails />} />
          <Route path="blogs" element={<Blog />} />
          <Route path="blogs/:slug" element={<BlogDetails />} />
          <Route path="contact" element={<Contact />} />
        </Route>
        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
}

export default App;
