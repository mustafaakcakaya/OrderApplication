using CommonLibrary.Context;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Behaviours;
using Order.Application.Data;
using Order.Application.Features.Commands.CreateOrder;
using Order.Application.Features.Queries.GetOrders;
using Order.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Order.Application.ServiceRegistration
{
    public static class AppServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderContext>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            return services;
        }
    }
}
