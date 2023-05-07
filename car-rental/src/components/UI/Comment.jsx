import { Form, FormGroup, Input } from "reactstrap";
import img from "../../assets/users/user3.png";
import "../../styles/comment.css";
import { useState } from "react";

const Comment = ({ comments, handleOnSubmit }) => {
  const count = comments.length || 0;

  const [name, setName] = useState("");
  const [desc, setDesc] = useState("");

  const handleNameChange = (e) => {
    setName(e.target.value);
  };

  const handleDescChange = (e) => {
    setDesc(e.target.value);
  };

  const handleAddComment = (e) => {
    e.preventDefault();
    if (handleOnSubmit) handleOnSubmit({ name, description: desc });

    setName("");
    setDesc("");
  };

  return (
    <div className="comment__list mt-5">
      <h4 className="mb-5">{count} Bình luận</h4>

      {comments.map((item, index) => {
        return (
          <div key={item.id} className="single__comment d-flex gap-3">
            <img src={img} alt="" className="comment__img" />
            <div className="comment__content">
              <h6 className=" fw-bold">{item.name}</h6>
              <p className="section__description mb-0">
                {new Date(item.postedDate).toDateString()}
              </p>
              <p className="section__description">{item.description}</p>
            </div>
          </div>
        );
      })}

      {/* =============== comment form ============ */}
      <div className="leave__comment-form mt-5">
        <h4 className="mb-3">Bình luận</h4>

        <form onSubmit={handleAddComment}>
          <FormGroup className=" d-flex gap-3">
            <Input
              type="text"
              placeholder="Tên của bạn"
              value={name}
              onChange={handleNameChange}
            />
          </FormGroup>

          <FormGroup>
            <textarea
              rows="5"
              className="w-100 py-2 px-3"
              placeholder="Nội dung..."
              value={desc}
              onChange={handleDescChange}
            ></textarea>
          </FormGroup>

          <button type="submit" className="btn comment__btn mt-3">
            Post a Comment
          </button>
        </form>
      </div>
    </div>
  );
};
export default Comment;
