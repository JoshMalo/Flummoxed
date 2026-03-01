using UnityEngine;

namespace TuringTest
{
    public class EnemyIdleState : EnemyState
    {
        int currentTarget = 0;
        public EnemyIdleState(EnemyController enemy) : base(enemy)
        {

        }

        public override void OnStateEnter()
        {
            enemyController.agent.destination = enemyController.targetPoints[currentTarget].position;
        }

        public override void OnStateExit()
        {
            
        }

        public override void OnStateUpdate()
        {
            if (enemyController.agent.remainingDistance < 0.1f) 
            {
                currentTarget++;
                if(currentTarget >= enemyController.targetPoints.Length)
                {
                    currentTarget = 0;
                }
                enemyController.agent.destination = enemyController.targetPoints[currentTarget].position;
            }
            if (Physics.SphereCast(enemyController.enemyEye.position, enemyController.checkRadius, enemyController.transform.forward, out RaycastHit hit, enemyController.playerCheckDistance))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    enemyController.player = hit.transform;
                    enemyController.ChangeState(new EnemyFollowState(enemyController));
                }
            } 
        }
    }
}

