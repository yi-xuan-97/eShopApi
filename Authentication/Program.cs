

using JWTAuth;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://example.com",
                "http://www.contoso.com");
        });
});
builder.Services.AddControllersWithViews();
// Add services to the container.
// builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtTokenHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

var AngularUrl = Environment.GetEnvironmentVariable("angularURL");

app.UseCors(policy => { policy.WithOrigins(AngularUrl).AllowAnyMethod().AllowAnyHeader().AllowCredentials(); });

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection(); 

app.MapControllers();

app.Run();