using UnityEngine;

namespace TuringTest
{
    public class EnemyAttackState : EnemyState
    {
        float distanceToPlayer;
        Health playerHealth;
        float damagePerSecond = -5f;
        public EnemyAttackState(EnemyController enemy) : base(enemy)
        {
            playerHealth = enemyController.player.GetComponent<Health>();
        }

        public override void OnStateEnter()
        {
            // debug
        }

        public override void OnStateUpdate()
        {
            Attack();
            if(enemyController.player != null)
            {
                distanceToPlayer = Vector3.Distance(enemyController.transform.position, enemyController.player.position);
                // Go To follow mode
                if(distanceToPlayer > 2)
                {
                    enemyController.ChangeState(new EnemyFollowState(enemyController));
                }
                enemyController.agent.destination = enemyController.player.position;
            }
            else
            {
                enemyController.ChangeState(new EnemyIdleState(enemyController));
            }
        }

        void Attack()
        {
            if(playerHealth != null)
            {
                playerHealth.ChangeHealth(damagePerSecond * Time.deltaTime);
            }
        }

        public override void OnStateExit()
        {
            // debug
        }      
    }
}

