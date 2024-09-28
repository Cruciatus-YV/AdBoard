using AdBoard.ComponentRegistrar;
using AdBoard.DataAccess;
using AdBoard.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

// �������� ������ ���������� `WebApplicationBuilder`.
// ��� ������ ��������� ����������, ������� �������� ������������ �������� � ���������� ����������.
var builder = WebApplication.CreateBuilder(args);

// ��������� ������� � ��������� ������������.
builder.Services.AddControllers();

// ������� ������ � ������������ Swagger/OpenAPI �� ������ https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// ��������� Swagger ��� ��������� ������������ API
builder.Services.AddSwaggerGen();

// ����������� ���������������� �������� � ���������� ������������
builder.Services.AddServices();

// ��������� ��������� ���� ������ ��� ������������� PostgreSQL
builder.Services.AddDbContext<AdBoardDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"))
);

// �������� ���������� ���������� �� ������ ��������, �������� � `builder`.
// ��� ��������� ��������� � ������������ ���������� � �������������� ��� � �������.
var app = builder.Build();

// ��������� ������������� �� ��� ��������� ���������� �� ������ ����� ����������.
// ��� ��������� ������������� � ������������ �������������� ����������, ��������� ������� �������� �����.
app.UseMiddleware<ExceptionHandlingMiddleware>();

// ������������ ��������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    // �������� Swagger ��� ����������� ������������ API � ������ ����������
    app.UseSwagger();

    // �������� ��������� Swagger UI ��� �������������� � ������������� API
    app.UseSwaggerUI();
}

// �������� ��������������� � HTTP �� HTTPS
app.UseHttpsRedirection();

// �������� ��������� �����������
app.UseAuthorization();

// ������������� �������� � ������������
app.MapControllers();

// ������ ����������
app.Run();