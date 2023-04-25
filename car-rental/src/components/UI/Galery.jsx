import "react-responsive-carousel/lib/styles/carousel.min.css"; // requires a loader
import { Carousel } from "react-responsive-carousel";

const Galery = ({ img, galeries }) => {
  return (
    <Carousel
      showArrows={true}
      showStatus={false}
      autoPlay={true}
      infiniteLoop={true}
      interval={2000}
    >
      <div>
        <img src={img} alt="" />
      </div>

      {galeries.slice(0, 4).map((item, index) => {
        return (
          <div key={item.id}>
            <img src={item.thumbnail} alt="" />
          </div>
        );
      })}
    </Carousel>
  );
};
export default Galery;
