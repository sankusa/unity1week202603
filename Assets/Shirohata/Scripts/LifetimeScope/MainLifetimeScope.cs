using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField] ClickChecker _clickChecker;
        [SerializeField] WisdomView _wisdomView;

        protected override void Configure(IContainerBuilder builder)
        {
            // Domain
            builder.Register<Tablet>(Lifetime.Scoped);
            builder.Register<Wisdom>(Lifetime.Scoped);
            builder.Register<ClickPower>(Lifetime.Scoped);
            builder.Register<SaveData>(Lifetime.Singleton);

            // Presentation
            builder.RegisterInstance(_clickChecker);
            builder.RegisterInstance(_wisdomView);
            builder.RegisterEntryPoint<WisdomPresenter>(Lifetime.Scoped);

            // Sequence
            builder.Register<MainGameLoop>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MainSequence>();
        }
    }

}