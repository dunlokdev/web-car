const Statistical = ({ countCar, countModel }) => {
  return (
    <>
      <div className="row g-3 my-2 flex-wrap">
        <div className="col-lg-3 col-md-4 col-sm-5">
          <div className="p-3 bg-white shadow-sm d-flex justify-content-around align-items-center rounded">
            <div>
              <h3 className="fs-2">{countCar}</h3>
              <p className="fs-5">Số lượng xe</p>
            </div>
            <i className="fas fa-car fs-1 primary-text border rounded-full secondary-bg p-3"></i>
          </div>
        </div>

        <div className="col-lg-3 col-md-4 col-sm-5">
          <div className="p-3 bg-white shadow-sm d-flex justify-content-around align-items-center rounded">
            <div>
              <h3 className="fs-2">{countModel}</h3>
              <p className="fs-5">Số loại xe</p>
            </div>
            <i className="fas fa-hand-holding-usd fs-1 primary-text border rounded-full secondary-bg p-3"></i>
          </div>
        </div>

        <div className="col-lg-3 col-md-4 col-sm-5">
          <div className="p-3 bg-white shadow-sm d-flex justify-content-around align-items-center rounded">
            <div>
              <h3 className="fs-2">3899</h3>
              <p className="fs-5">Bài viết</p>
            </div>
            <i className="fas fa-truck fs-1 primary-text border rounded-full secondary-bg p-3"></i>
          </div>
        </div>

        <div className="col-lg-3 col-md-4 col-sm-5">
          <div className="p-3 bg-white shadow-sm d-flex justify-content-around align-items-center rounded">
            <div>
              <h3 className="fs-2">25</h3>
              <p className="fs-5">Phản hồi</p>
            </div>
            <i className="fa fa-envelope fs-1 primary-text border rounded-full secondary-bg p-3"></i>
          </div>
        </div>
      </div>
    </>
  );
};
export default Statistical;
