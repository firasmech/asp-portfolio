namespace myPortfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Razor Pages support
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Only use HTTPS redirection in production
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();  // For wwwroot files
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();  // This enables Razor Pages

            // Redirect root URL to Home page
            app.MapGet("/", () => Results.Redirect("/Home"));
           
            app.Run();
        }
    }
}
