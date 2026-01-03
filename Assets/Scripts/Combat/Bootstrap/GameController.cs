using Combat.Behaviors;
using Combat.Contracts;
using Combat.Model;
using Combat.View;
using UnityEngine;

namespace Combat.Bootstrap
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private EnemyView enemyView;

        private EnemyPresenter _presenter;
        private void Start()
        {
            // Build Model
            var attack = new MeleeAttack();
            var health = new Health(10);
            var enemy = new Enemy(attack, health);

            //Wire presenter
            IEnemyView view = enemyView;
            _presenter = new EnemyPresenter(enemy, view);

            Debug.Log("Pressed A = Attack, H = Take Damage(3)");

        }

        private void OnDestroy()
        {
            _presenter.Dispose();
        }
    }
}