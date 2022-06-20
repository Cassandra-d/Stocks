using Autofac;
using PublicApi.Services;
using PublicApi.Services.Interfaces;

namespace PublicApi.Application.Infrastructure.Autofac
{
    public class StocksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StocksService>()
                .As<IStocksService>()
                .InstancePerLifetimeScope();
        }
    }
}
