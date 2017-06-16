using EncounterGen.Domain.Generators.Factories;
using Ninject.Activation;

namespace EncounterGen.Domain.IoC.Providers
{
    class JustInTimeFactoryProvider : Provider<JustInTimeFactory>
    {
        protected override JustInTimeFactory CreateInstance(IContext context)
        {
            return new NinjectJustInTimeFactory(context.Kernel);
        }
    }
}
