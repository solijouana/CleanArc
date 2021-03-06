﻿using CleanArc.Application.Interfaces;
using CleanArc.Application.Services;
using CleanArc.Domain.Interfaces;
using CleanArc.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArc.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IUserServices, UserServices>();

            //Infra Data Layer
            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
