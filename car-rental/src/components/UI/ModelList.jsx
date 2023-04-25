import { Link } from "react-router-dom";
import "../../styles/model-list.css";
const ModelList = ({ modelList }) => {
  return (
    <div className="model__list">
      {modelList.map((item, index) => {
        return (
          <Link
            to={`cars/models/${item.urlSlug}`}
            key={item?.id}
            className="model__item"
          >
            <img src={item?.thumbnail} alt={item?.name} />
            <span> {item?.name}</span>
          </Link>
        );
      })}
    </div>
  );
};
export default ModelList;
