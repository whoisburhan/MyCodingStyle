using Combat.Model;
using Combat.View;
using UnityEngine;
using Zenject;

namespace Combat.Presenter
{
    public class EnemyPresenterFactory: PlaceholderFactory<Enemy, IEnemyView, EnemyPresenter>
    {

    }
}
