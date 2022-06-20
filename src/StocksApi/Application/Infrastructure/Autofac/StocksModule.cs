using Autofac;
using StocksApi.Services;
using StocksApi.Services.Application;
using StocksApi.Services.Interfaces;

namespace StocksApi.Application.Infrastructure.Autofac
{
    public class StocksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StocksService>()
                .As<IStocksService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<IndexesGetter>()
                .As<IIndexesGetter>()
                .SingleInstance();
        }
    }
}
