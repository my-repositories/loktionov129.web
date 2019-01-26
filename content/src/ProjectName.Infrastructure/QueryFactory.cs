// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.Extensions.DependencyInjection;
using ProjectName.Abstract;

namespace ProjectName.Infrastructure
{
    public class QueryFactory : IQueryFactory
    {
        private readonly IServiceProvider serviceProvider;

        public QueryFactory(IServiceProvider serviceProvider) => this.serviceProvider = serviceProvider;

        public T ResolveQuery<T>()
            where T : class, IQuery
            => serviceProvider.GetService<T>();
    }
}
