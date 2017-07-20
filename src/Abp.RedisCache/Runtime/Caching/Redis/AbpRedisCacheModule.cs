using System.Reflection;
using Abp.Modules;
using Castle.MicroKernel.Registration;

namespace Abp.Runtime.Caching.Redis
{
    /// <summary>
    /// This modules is used to replace ABP's cache system with Redis server.
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpRedisCacheModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.IocContainer.Register(Component
                .For<AbpRedisCacheOptions>()
                .ImplementedBy<AbpRedisCacheOptions>().OnlyNewServices());
            
            //IocManager.Register<AbpRedisCacheOptions>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
