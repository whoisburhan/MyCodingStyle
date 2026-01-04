using Combat.Behaviors;
using Combat.Contracts;
using Combat.Model;
using Combat.Presenter;
using Combat.View;
using UnityEngine;
using Zenject;

namespace Combat.Bootstrap
{
    public class CombatInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView EnemyView;

        public override void InstallBindings()
        {
            Container.Bind<IEnemyView>().FromInstance(EnemyView).AsSingle();
            Container.Bind<EnemyFactory>().AsSingle();

            // Bind Factory for EnemyPresenter
            Container.BindFactory<Enemy, IEnemyView, EnemyPresenter, EnemyPresenterFactory>();

            Container.BindInterfacesTo<Combatflow>().AsSingle().NonLazy();
            //Container.Bind<EnemyPresenter>().AsSingle().NonLazy();

            //// Bind View from Scene Instance
            //Container.Bind<IEnemyView>().FromInstance(EnemyView).AsSingle();

            //// Bind Attack Behaviors
            //Container.Bind<IAttackBehavior>().To<MeleeAttack>().AsTransient();

            //// Bind Health
            //Container.Bind<IHealth>().To<Health>().AsTransient()
            //    .WithArguments(10);

            //// Bind Enemy
            //Container.Bind<Enemy>().AsTransient();

            //// Bind Presenter
            //Container.Bind<EnemyPresenter>().AsSingle().NonLazy();
        }
    }
}