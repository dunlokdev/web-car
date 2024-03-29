import { useEffect, useState } from "react";
import { Col, Container, Row } from "reactstrap";
import carsApi from "../api/carsApi";
import Helmet from "../components/Helmet/Helmet";
import AboutSection from "../components/UI/AboutSection";
import BecomeDriverSection from "../components/UI/BecomeDriverSection";
import BlogList from "../components/UI/BlogList";
import CarItem from "../components/UI/CarItem";
import HeroSlider from "../components/UI/HeroSlider";
import ModelList from "../components/UI/ModelList";
import modelsApi from "../api/modelsApi";
import Loading from "../components/Loading/Loading";
import postApi from "../api/postApi";

const Home = () => {
  // State
  const [carList, setCarList] = useState([]);
  const [modelList, setModelList] = useState([]);
  const [blogs, setBlogs] = useState([]);

  const [filtersBlog, setFiltersBlog] = useState({
    Keyword: "",
    PageSize: 10,
    PageNumber: 1,
  });

  const [isLoading, setIsLoading] = useState(false);
  const [filters, setFilters] = useState({
    PageSize: 6,
    PageNumber: 1,
  });

  // Effect
  useEffect(() => {
    (async () => {
      try {
        setIsLoading(true);
        const data = await carsApi.getAll(filters);
        const modelResponse = await modelsApi.getAll();
        const { result } = await postApi.getAll(filters);
        setBlogs(result.items);
        setModelList(modelResponse.result);
        setCarList(data.result.items);
        setIsLoading(false);
      } catch (error) {}
    })();
  }, [filters]);

  return (
    <div>
      {isLoading && <Loading />}

      <Helmet title="Home">
        {/* =========== slider section ============= */}
        <section className="p-0 hero__slider-section">
          <HeroSlider />
        </section>

        {/* =========== About section =========== */}
        <AboutSection />

        {/* =========== Model list =========== */}
        <section>
          <Container>
            <Row>
              <Col lg="12" className="mb-5 text-center">
                <h2 className="section__title">Các dòng xe</h2>
              </Col>
              <ModelList modelList={modelList} />
            </Row>
          </Container>
        </section>

        {/* =========== car offer section ============= */}
        <section>
          <Container>
            <Row>
              <Col lg="12" className="text-center mb-5">
                <h6 className="section__subtitle">Tận hưởng</h6>
                <h2 className="section__title">Các dòng Porsche</h2>
              </Col>
              {carList.map((item, index) => (
                <CarItem item={item} key={item.id} />
              ))}
            </Row>
          </Container>
        </section>

        {/* =========== adv section ============= */}
        <BecomeDriverSection />

        {/* =========== blog section ============= */}
        <section>
          <Container>
            <Row>
              <Col lg="12" className="mb-5 text-center">
                <h6 className="section__subtitle">
                  Khám phá Blog của chúng tôi
                </h6>
                <h2 className="section__title">Blog mới nhất</h2>
              </Col>
              <BlogList blogs={blogs} />
            </Row>
          </Container>
        </section>
      </Helmet>
    </div>
  );
};
export default Home;
