using Autofac;
using ClientAppointments.Core.Interfaces;
using ClientAppointments.Core.Services;

namespace ClientAppointments.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PractitionerSearchService>()
                .As<IPractitionerSearchService>().InstancePerLifetimeScope();
        }
    }
}
