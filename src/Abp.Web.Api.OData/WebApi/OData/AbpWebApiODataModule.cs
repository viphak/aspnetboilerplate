using System.Reflection;
using System.Web.OData;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Abp.Modules;
using Abp.WebApi.OData.Configuration;
using Castle.MicroKernel.Registration;

namespace Abp.WebApi.OData
{
    [DependsOn(typeof(AbpWebApiModule))]
    public class AbpWebApiODataModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.IocContainer.Register(Component
                .For<IAbpWebApiODataModuleConfiguration, AbpWebApiODataModuleConfiguration>()
                .ImplementedBy<AbpWebApiODataModuleConfiguration>().OnlyNewServices());

            //IocManager.Register<IAbpWebApiODataModuleConfiguration, AbpWebApiODataModuleConfiguration>();

            Configuration.Validation.IgnoredTypes.AddIfNotContains(typeof(Delta));
        }

        public override void Initialize()
        {
            IocManager.RegisterIfNot<MetadataController>(DependencyLifeStyle.Transient);
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApiOData().MapAction?.Invoke(Configuration);
        }
    }
}
