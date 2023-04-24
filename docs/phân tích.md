## Create model EF

- [x] Tạo model Car:
- ID
- ModelID
- Name
- Price (\*)
- Discount
- Thumbnail
- ShortDescripton
- Description
- UrlSlug
- IsActived
- Wattage: Công xuất (\*)
- Torque: Mô men xoắn (\*)
- SpeedUp: Tăng tốc từ 0 - 100km (0 - 62 dặm) (\*)
- MaxSpeed: Tốc độ tối đa (\*)
- Consume: Lượng tiêu thụ
- Emissions: Lượng khí thải
- Evaluate: Đánh giá
- CreateAt
- UpdateAt

> Ví dụ về Url lưu image:
> https://localhost:7044/uploads/pictures/55a4b8415bbc45d78464b4abbe794472.png

## Phân tích chức năng

- Các chức năng cơ bản phía người dùng
- Giới thiệu trung tâm/cửa hàng/…
- Liệt kê các hoạt động/sản phẩm/khóa học/… nổi bật
- Hiển thị danh sách các hoạt động/sản phẩm/khóa học/… theo từng chủ đề, kèm theo thông tin về giá cả, chi phí, …
- Hiển thị thông tin chi tiết về hoạt động/sản phẩm/khóa học/…
- Cho phép người dùng gửi góp ý, đăng ký theo dõi bài viết mới, chia sẻ bài viết lên mạng xã hội, …
- Mua hàng và thanh toán (Không bắt buộc, nếu làm được sẽ có điểm cộng)
- Hiển thị album ảnh về sản phẩm/hoạt động/…
- Hiển thị thông tin liên lạc, bản đồ, …
- Đối với những ứng dụng dạng khóa học (dạy đàn, hát, võ, nấu ăn, ...) thì cần có chức năng đăng ký khóa học

```mermaid
graph TD;
    A-->B;
    A-->C;
    B-->D;
    C-->D;
```
