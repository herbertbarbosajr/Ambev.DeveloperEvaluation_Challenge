using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();

        builder.Services.AddTransient<IBusinessRules, NoDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, TenPercentDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, TwentyPercentDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, QuantityValidationRule>();

        builder.Services.AddTransient<DiscountBusinessRuleHandler>();

        builder.Services.AddTransient<IValidator<CreateSaleCommand>, CreateSaleCommandValidator>();
        builder.Services.AddTransient<IValidator<DeleteSaleCommand>, DeleteSaleValidator>();
        builder.Services.AddTransient<IValidator<GetSaleCommand>, GetSaleValidator>();

        builder.Services.AddTransient<IValidator<CreateSalesItemsCommand>, CreateSaleItemsCommandValidator>();
        builder.Services.AddTransient<IValidator<DeleteSalesItemsCommand>, DeleteSalesItemsValidator>();
        builder.Services.AddTransient<IValidator<GetSalesItemsCommand>, GetSaleItemsValidator>();

        builder.Services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        builder.Services.AddTransient<IValidator<DeleteUserCommand>, DeleteUserValidator>();
        builder.Services.AddTransient<IValidator<GetUserCommand>, GetUserValidator>();

        // Registrar o LogEventPublisher
        builder.Services.AddTransient<IEventPublisher, LogEventPublisher>();
    }
}