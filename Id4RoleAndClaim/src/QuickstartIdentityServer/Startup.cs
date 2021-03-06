// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace QuickstartIdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // configure identity server with in-memory stores, keys, clients and scopes
	        services.AddIdentityServer()
		        .AddDeveloperSigningCredential()
		        .AddInMemoryIdentityResources(Config.GetIdentityResourceResources())
				.AddInMemoryApiResources(Config.GetApiResources())
		        .AddInMemoryClients(Config.GetClients())
		        .AddTestUsers(Config.GetUsers())
		        .AddProfileService<CustomProfileService>()
		        .AddResourceOwnerValidator<CustomResourceOwnerPasswordValidator>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
        }
    }
}