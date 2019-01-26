// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Abstract;
using ProjectName.DataAccess;
using ProjectName.Domain;
using ProjectName.Domain.Users.Commands;
using ProjectName.Domain.Users.Handlers;
using ProjectName.Domain.Users.Queries;

namespace ProjectName.Infrastructure
{
    public static class CommonDiConfig
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper();
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            services.AddTransient(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();

                var connectionString = configuration["Params:DefaultConnectionString"];
                if (connectionString == "psql" || connectionString == "template")
                {
                    return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                        .UseNpgsql(configuration.GetConnectionString(connectionString))
                        .Options);
                }

                return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(configuration.GetConnectionString(connectionString))
                    .Options);
            });
            services.AddTransient<IAppUnitOfWork, AppUnitOfWork>();
            services.AddTransient<ICommandFactory, CommandFactory>();
            services.AddTransient<IQueryFactory, QueryFactory>();

            // todo: register all handlers
            services.AddTransient<ICommandHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddTransient<ICommandHandler<UpdatePasswordCommand>, UpdatePasswordCommandHandler>();
            services.AddTransient<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();

            // todo: register all queries
            services.AddTransient<UserByIdQuery>();
            services.AddTransient<UserByLoginAndPasswordQuery>();
        }
    }
}
