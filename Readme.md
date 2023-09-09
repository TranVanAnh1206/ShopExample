### sau khi đã hoàn thiện xong được các Model class cho các bảng

vào Package Manager Console
PM > enable-migrations (chọn PM > enable-migrations -Force nếu đã tồn tại để ghi đè)
PM > add-migration InitialDB
PM > update-database

### Sau khi đã có được database rồi mà muốn thêm vào một bảng thì

-> Tạo một model mới -> Tạo DBSet trong file <NameDatabse>DbContext.cs
PM > add-migration AddNewTable (-> tạo tên gì thì tùy)
PM > update-database
-> Sau đó tiếp tục tạo đến Repository và Service của bảng vừa tạo

### Các bước Thực hiện cài đặt Dependency Injection AutoFac

Cài các gói NuGet Autofac, Autofac.MVC5, Autofac.WebApi
Tạo file Startup.cs: Chuột phải App_Start > Add > New item > Chọn OWIN Startup class > Add
Cài gói Microsoft.OWin.Host.SystemWeb để chạy file Startup.cs
Register Startup cho cả controller mvc và controller api
Chạy thử

### Tích hợp ASP NET Identity cho phần chứng thực người dùng
## Các bước thực hiện cài đặt DI Autofic

Cài 3 thư viện : Microsoft.ASPNet.Identity.EntityFramword, Microsoft.ASPNet.Identity.Core, Microsoft.ASPNet.Identity.OWIN \n
Tạo mới class User kế thừa từ IdentityUser \n
Tạo mới class Role kế thừa từ IdentityRole\n
Kế thừa lớp DbContext từ IdentityDbContext<User>\n
Cấu hình Authentication từ file Startup.cs\n
Thực hiện migration vào database\n
Tạo class quản lý Authen\n

