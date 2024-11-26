using Microsoft.EntityFrameworkCore;
using WealthSphere.Repository;
using WealthSphere.Repository.Implementation;
using WealthSphere.Repository.Interface;
using WealthSphere.Services;
using WealthSphere.Services.Implementation;
using WealthSphere.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<WealthSphereDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;MultipleActiveResultSets=true;"));

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();

builder.Services.AddTransient<IIncomeService, IncomeService>();
builder.Services.AddTransient<IIncomeRepository, IncomeRepository>();

builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();

builder.Services.AddTransient<IInvestmentService, InvestmentService>();
builder.Services.AddTransient<IInvestmentRepository, InvestmentRepository>();

builder.Services.AddTransient<IFeedbackService, FeedbackService>();
builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();

builder.Services.AddTransient<IGoalSettingService, GoalSettingService>();
builder.Services.AddTransient<IGoalSettingRepository, GoalSettingRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapping));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();
