using JeugdLinkBLL;
using JeugdLinkBLL.UserService;
using JeugdLinkDAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserRepository>(provider =>
{
    // Get the connection string from configuration
    string connstring = builder.Configuration.GetConnectionString("DefaultConnection");

    // Get the logger from DI container
    var logger = provider.GetRequiredService<ILogger<UserRepository>>();

    // Return the UserRepository instance with the connection string and logger
    return new UserRepository(connstring, logger);
});

builder.Services.AddScoped<ICourseRepository>(provider =>
{
    
    string connstring = builder.Configuration.GetConnectionString("DefaultConnection");
  
    var logger = provider.GetRequiredService<ILogger<CourseRepository>>();
    
    return new CourseRepository(connstring, logger);
});

builder.Services.AddScoped<IRegistration, Registration>();
builder.Services.AddScoped<IAuthenticator, Authentication>();
builder.Services.AddScoped<ICourseManager, CourseManager>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
