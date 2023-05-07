import React from "react";
import { Link } from "react-router-dom";
import { Col } from "reactstrap";
import "../../styles/blog-item.css";

const BlogList = ({ blogs }) => {
  return (
    <>
      {blogs?.map((item) => (
        <BlogItem item={item} key={item.id} />
      ))}
    </>
  );
};

const BlogItem = ({ item }) => {
  const { id, imageUrl, title, author, postedDate, shortDescription, urlSlug } =
    item;
  console.log("🚀 ~ BlogItem ~ imgUrl:", imageUrl);

  return (
    <Col lg="4" md="6" sm="6" className="mb-5">
      <div className="blog__item">
        <img
          src={imageUrl || "https://placehold.co/600x400?text=Thumbnail"}
          alt=""
          className="w-100"
        />
        <div className="blog__info p-3">
          <Link to={`/blogs/${urlSlug}`} className="blog__title">
            {title}
          </Link>
          <p className="section__description mt-3">
            {shortDescription.length > 100
              ? shortDescription.substr(0, 100)
              : shortDescription}
          </p>

          <Link to={`/blogs/${title}`} className="read__more">
            Đọc thêm
          </Link>

          <div className="blog__time pt-3 mt-3 d-flex align-items-center justify-content-between">
            <span className="blog__author">
              <i className="ri-user-line"></i> {author}
            </span>

            <div className=" d-flex align-items-center gap-3">
              <span className=" d-flex align-items-center gap-1 section__description">
                <i className="ri-calendar-line"></i> {postedDate}
              </span>

              {/* <span className=" d-flex align-items-center gap-1 section__description">
                <i className="ri-time-line"></i> {time}
              </span> */}
            </div>
          </div>
        </div>
      </div>
    </Col>
  );
};

export default BlogList;
