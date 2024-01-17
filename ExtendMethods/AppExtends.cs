


using System.Net;

namespace AppExtendMedthods
{
    public static class AppExtends {
        public static void AddStatusCodePage ( this WebApplication app) {
            app.UseStatusCodePages(
                appError => {
                    appError.Run(async context => {
                        var respone = context.Response;
                        var code = respone.StatusCode;

                        var content = @$"
                            <html>
                                <head>
                                    <meta   charset='UTF-8'/>
                                    <title>lỗi {code}</title>
                                <head/>
                                <body>
                                    <p>
                                        Có lỗi sảy ra : {code} -    {(HttpStatusCode)code}
                                    </>
                                </body>
                            </html>
                        ";

                        await respone.WriteAsync(content);
                    }) ;
                }
            ); 

        }

        // MyEndpoint 

        public static void AddMyEndPoint (this WebApplication app ) {
            app.MapGet("/sayhi" , async (context) => {
                await context.Response.WriteAsync($"Hello Asp.Net mvc {DateTime.Now}");
            });
        }
    }
}