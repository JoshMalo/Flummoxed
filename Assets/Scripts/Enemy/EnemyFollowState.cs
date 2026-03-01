using UnityEngine;

namespace TuringTest
{
    public class EnemyFollowState : EnemyState
    {
        float distanceToPlayer;

        public EnemyFollowState(EnemyController enemy) : base(enemy)
        {
            // Constructor
        }

        public override void OnStateEnter()
        {
            enemyController.agent.destination = enemyController.player.position;
            // Initialize - change color - speed - etc.
        }

        public override void OnStateExit()
        {
            Debug.Log("Enemy is no longer following player");
        }

        public override void OnStateUpdate()
        {
            if (enemyController.player != null)
            {
                distanceToPlayer = Vector3.Distance(enemyController.transform.position, enemyController.player.position);

                if(distanceToPlayer > enemyController.maxPlayerDistance)
                {
                    enemyController.ChangeState(new EnemyIdleState(enemyController));
                }

                if(distanceToPlayer < enemyController.minPlayerDistance)
                {
                    enemyController.ChangeState(new EnemyAttackState(enemyController));
                }

                enemyController.agent.destination = enemyController.player.position;
                    
            }
            else
            {
                enemyController.ChangeState(new EnemyIdleState(enemyController));
            }
        }
    }
}

