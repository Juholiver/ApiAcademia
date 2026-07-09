using AcademiaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Adicione a política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Porta padrão do Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddSingleton<ExerciciosService>();

var app = builder.Build();

// 2. Ative o CORS (coloque antes de App.MapControllers ou UseAuthorization)
app.UseCors("AllowReact");

app.UseAuthorization();

app.MapControllers();

app.Run();