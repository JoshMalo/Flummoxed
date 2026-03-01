using UnityEngine;

namespace TuringTest
{
    public abstract class EnemyState
    {
        protected EnemyController enemyController;

        public EnemyState(EnemyController enemy)
        {
            enemyController = enemy;
        }

        public abstract void OnStateEnter();
        public abstract void OnStateUpdate();
        public abstract void OnStateExit();







    }
}

