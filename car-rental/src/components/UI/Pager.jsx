import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";

export default function Pager({ metadata, handlePageChange }) {
  const { pageCount, hasNextPage, hasPreviousPage, pageNumber, pageSize } =
    metadata;

  const handlePrevPage = () => {
    if (!handlePageChange) return;

    const PageNumber = pageNumber - 1;
    handlePageChange(PageNumber);
  };
  const handleNextPage = () => {
    if (!handlePageChange) return;

    const PageNumber = pageNumber + 1;
    handlePageChange(PageNumber);
  };
  return (
    <>
      {pageCount > 1 ? (
        <div className="my-4 text-center">
          {hasPreviousPage ? (
            <Button onClick={handlePrevPage}>
              <i className="ri-arrow-left-s-line"></i>
              Trang trước
            </Button>
          ) : (
            <Button variant="outline-secondary" disabled>
              <i className="ri-arrow-left-s-line"></i>
              Trang trước
            </Button>
          )}
          <span className="mx-2"></span>
          {hasNextPage ? (
            <Button onClick={handleNextPage}>
              Trang sau
              <i className="ri-arrow-right-s-line"></i>
            </Button>
          ) : (
            <Button variant="outline-secondary" className="ms-1" disabled>
              Trang sau
              <i className="ri-arrow-right-s-line"></i>
            </Button>
          )}
        </div>
      ) : null}
    </>
  );
}
