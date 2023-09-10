# Những lưu ý trong lúc làm project
- Tạo một class library là Model, Data, Service, Unittest, Common
- trong tầng Model, Tạo một folder lưu trữ các class đại diện cho các bảng trong database
- Tạo folder Abstract, mọt interface để lưu trữ các attr dùng chung, sau đó tạo class kế thừa từ interface đó
- Ở file App.config tạo một connection string
````<connectionStrings>
		<clear/>
		<add name="ShopExampleConnection" providerName="System.Data.SqlClient" connectionString="data source=.\sqlexpress;initial catalog=ShopExample_InitialCodeFirst;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"/>
	</connectionStrings>````
*
- Tạo class với đúng tên đã khai báo ở phần ConnectionString kế thừa từ interface DbContext, và khai báo các DbSet<Tênclass> Ví dụ: 
 ````public ShopExampleDBContext() : base("ShopExampleConnection")
        {
            // khi chúng ta load một bẳng cha thì không tự động include thêm bảng con
            this.Configuration.LazyLoadingEnabled = false;
        }
  public DbSet<Footer> Footers { get; set; }````
- Ở tầng Data, Tạo một folder Repository để chứa các Repositori của các lớp đại diện
- trong từng Repository, tạo một interface kế thừa từ IRepository chứa các phương thức phổ biến cho các hoạt động với Entity code first, sau đó là repositoy kế thừa từ RepositoriBase và Interface tương ứng.
- RepositoryBase kế thừa từ IRepository, định nghĩa các phương thức như Add, GetAll, Delete, Update đã được khai báo trong IRepository
- RepositoryBase và IRepository được định ngĩa trong folder Infrastructure

### sau khi đã hoàn thiện xong được các Model class đại diện cho các bảng cho các bảng

vào Package Manager Console
1. PM > enable-migrations (chọn PM > enable-migrations -Force nếu đã tồn tại để ghi đè)
2. PM > add-migration InitialDB
3. PM > update-database

### Sau khi đã có được database rồi mà muốn thêm vào một bảng thì

1. -> Tạo một model mới -> Tạo DBSet trong file <NameDatabse>DbContext.cs
2. PM > add-migration AddNewTable (-> tạo tên gì thì tùy)
3. PM > update-database
4. -> Sau đó tiếp tục tạo đến Repository và Service của bảng vừa tạo

### Các bước Thực hiện cài đặt Dependency Injection AutoFac

1. Cài các gói NuGet Autofac, Autofac.MVC5, Autofac.WebApi
2. Tạo file Startup.cs: Chuột phải App_Start > Add > New item > Chọn OWIN Startup class > Add
3. Cài gói Microsoft.OWin.Host.SystemWeb để chạy file Startup.cs
4. Register Startup cho cả controller mvc và controller api
5. Chạy thử

### Tích hợp ASP NET Identity cho phần chứng thực người dùng
## Các bước thực hiện cài đặt DI Autofic

*
1. Cài 3 thư viện : Microsoft.ASPNet.Identity.EntityFramword, Microsoft.ASPNet.Identity.Core, Microsoft.ASPNet.Identity.OWIN
2. Tạo mới class User kế thừa từ IdentityUser 
3. Tạo mới class Role kế thừa từ IdentityRole 
4. Kế thừa lớp DbContext từ IdentityDbContext<User> 
5. Cấu hình Authentication từ file Startup.cs
6. Thực hiện migration vào database 
7. Tạo class quản lý Authen 
*

