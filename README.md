## Website quảng bá các mẫu mã ô tô

<h1 align="center">
   <b>
        <a href=""><img src="https://upload.wikimedia.org/wikipedia/commons/a/a7/React-icon.svg" style="width: 150px; object-fit: cover;" /></a>
        <a href=""><img src="https://cdn.worldvectorlogo.com/logos/dot-net-core-7.svg" style="width: 150px; object-fit: cover" /></a>
        <a href=""><img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" style="width: 150px; object-fit: cover" /></a><br>
    </b>
</h1>

### Hướng dẫn chạy dự án

#### 1. Setup Backend API (ASP.Net Core 7)

Mở dự án bằng Visual Studio

Thay đổi `Server name Sql Server` theo máy local:

- CarRentalApi.WebApi/appsettings.json

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=Server_name;Database=CarRentalV2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
```

> **Note:** Thay Server_name = Server name `Sql Server` của máy

Build dự án:

- Build > Build Solution (Ctrl + Shift + B)

Chạy dự án: Ctrl + F5

#### 2. Setup Frontend ReactJS (CRA)

> **Note:** Dự án sử dụng package manager là `Yarn`

Clone dự án từ **Github repository**:

```
Link repository: git@github.com:dunlokdev/web-car.git
```

Mở dự án Frondend bằng `VSCode`:

- Terminal > New terminal (Ctrl + Shift + `) để mở terminal

Install node_modules:

```bash
$ yarn
```

<div style="page-break-after: always;"></div>
Sau đó khởi động dự án Frontend:

```bash
yarn start
```

