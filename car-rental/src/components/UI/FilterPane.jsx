import { Col } from "reactstrap";

const FilterPane = () => {
  return (
    <>
      <div className="filter-pane px-4 pt-4">
        <Col lg="12">
          <div className=" d-flex align-items-center gap-3 mb-5">
            <span className=" d-flex align-items-center gap-2">
              <i className="ri-sort-asc"></i> Sắp xếp theo
            </span>

            <select style={{ width: "150px" }} className="form-select">
              <option value=""> -- Giá --</option>
              <option value="ASC">Thấp đến cao</option>
              <option value="DESC">Cao đến thấp</option>
            </select>

            <form>
              <div className="input-group">
                <div className="form-control">
                  <input
                    style={{ outline: "none", border: "none" }}
                    type="text"
                    placeholder="Tìm kiếm"
                  />
                </div>
                <button type="submit" className="btn btn-sm">
                  <i className="ri-search-line"></i>
                </button>
              </div>
            </form>
          </div>
        </Col>
      </div>
    </>
  );
};
export default FilterPane;
