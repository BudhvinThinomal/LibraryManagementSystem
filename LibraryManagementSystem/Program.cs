using LibraryManagementSystem.Repository;
using LibraryManagementSystem.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Service
builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<StudentService>();
builder.Services.AddTransient<IssueBookService>();
//Repository
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<StudentRepository>();
builder.Services.AddTransient<IssueBookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
