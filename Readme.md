## Controller 
-   Là một lớp kết thừa từ lớp Controller : Microsoft.AspNetCore.Mvc.Controller
-   Có thể lấy được : 
        this.HttpContext
        this.Request
        this.Response
        this.RouteData

        this.User
        this.ModelState
        this.ViewData
        this.ViewBag
        this.Url
        this.Template

-       Action trong controller là một phương thức public (không được phép static)
-       Action có thể trả về bất kỳ kiểu dữ liệu nào (hầu hết là IActionResult)
## View 
-       là file .cshtml
-       Thêm thư mục lưu trữ view 
```
builder.Services.Configure<RazorViewEngineOptions> (

        options => {
                // {0} Action
                // {1} Controller
                // {2} Area 
                options.ViewLocationFormats.Add("/Myview/{1}/{0}" + RazorViewEngine.ViewExtension );
        }
)


```
## Truyền dữ liệu sang view 

        -       Model 
        -       ViewData
        -       ViewBag
        -       TempData
        
        