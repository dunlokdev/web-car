import Helmet from "../components/Helmet/Helmet";
import HeroSlider from "../components/UI/HeroSlider";

const Home = () => {
  return (
    <div>
      <Helmet title="Home">
        <section className="p-0 hero__slider-section">
          <HeroSlider />
        </section>
      </Helmet>
    </div>
  );
};
export default Home;
