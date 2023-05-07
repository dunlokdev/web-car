import { Container, Row } from "reactstrap";
import Helmet from "../components/Helmet/Helmet";
import CommonSection from "../components/UI/CommonSection";
import BlogList from "../components/UI/BlogList";
import { useEffect, useState } from "react";
import postApi from "../api/postApi";

const Blog = () => {
  // State
  const [blogs, setBlogs] = useState([]);
  const [filters, setFilters] = useState({
    Keyword: "",
    PageSize: 10,
    PageNumber: 1,
  });

  // useEffect
  useEffect(() => {
    (async () => {
      try {
        const { result } = await postApi.getAll(filters);
        setBlogs(result.items);
      } catch (error) {}
    })();
  }, [filters]);

  return (
    <Helmet title="Blogs">
      <CommonSection title="Blogs" />
      <section>
        <Container>
          <Row>
            <BlogList blogs={blogs} />
          </Row>
        </Container>
      </section>
    </Helmet>
  );
};
export default Blog;
