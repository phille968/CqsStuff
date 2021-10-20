using System;
using System.Collections.Generic;
using System.Linq;
using FunctionApp.Domain.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp.Domain.Core
{
    public class Queries : IQueries
    {
        private static IEnumerable<(Type type, Func<object> factoryMethod)> _queries;

        public Queries(IServiceProvider serviceProvider)
        {
            _queries = QueriesLedger(serviceProvider);
        }

        public static IEnumerable<(Type, Func<object> factory)> QueriesLedger(IServiceProvider sp)
        {
            return new List<(Type query, Func<object> factory)>
            {
                (typeof(Querynr1), sp.GetService<Querynr1>),
                (typeof(Querynr2), sp.GetService<Querynr2>)
            };
        }

        public TQuery Get<TQuery>() where TQuery : IQuery<TQuery> => (TQuery)_queries.Single(x => x.type == typeof(TQuery)).factoryMethod();
    }
}