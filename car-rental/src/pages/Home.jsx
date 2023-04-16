import Helmet from "../components/Helmet/Helmet";
import AboutSection from "../components/UI/AboutSection";
import HeroSlider from "../components/UI/HeroSlider";

const Home = () => {
  return (
    <div>
      <Helmet title="Home">
        <section className="p-0 hero__slider-section">
          <HeroSlider />
        </section>

        {/* About section */}
        <AboutSection />
      </Helmet>
    </div>
  );
};
export default Home;
