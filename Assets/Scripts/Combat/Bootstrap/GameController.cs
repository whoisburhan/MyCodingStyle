//using Combat.Behaviors;
//using Combat.Contracts;
//using Combat.Model;
//using Combat.View;
//using UnityEngine;

//namespace Combat.Bootstrap
//{
//    public class GameController: MonoBehaviour
//    {
//        [SerializeField] private EnemyView enemyView;

//        private EnemyPresenter _presenter;
//        private void Start()
//        {
//            var factory = new EnemyFactory();
//            var enemy = factory.Create(EnemyType.BasicMelee, 10);

//            Debug.Log($"Enemy created with {enemy.Hp} HP.");

//            //Wire presenter
//            IEnemyView view = enemyView;
//            _presenter = new EnemyPresenter(enemy, view);

//            Debug.Log("Pressed A = Attack, H = Take Damage(3)");

//        }

//        private void OnDestroy()
//        {
//            _presenter.Dispose();
//        }
//    }
//}