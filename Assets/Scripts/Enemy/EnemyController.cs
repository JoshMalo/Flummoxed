using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace TuringTest
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyState currentState;

        public Transform[] targetPoints;
        public Transform enemyEye;
        public float playerCheckDistance;
        public float checkRadius = 0.4f;
        public float maxPlayerDistance = 10f;
        public float minPlayerDistance = 2f;

        [HideInInspector]public NavMeshAgent agent;
        [HideInInspector]public Transform player;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            currentState = new EnemyIdleState(this);
            currentState.OnStateEnter();
        }

        private void Update()
        {
            currentState.OnStateUpdate();
        }

        public void ChangeState(EnemyState newState)
        {
            currentState.OnStateExit();
            currentState = newState;
            newState.OnStateEnter();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.rebeccaPurple;
            Gizmos.DrawWireSphere(enemyEye.position, checkRadius);
            Gizmos.DrawWireSphere(enemyEye.position + enemyEye.forward * playerCheckDistance, checkRadius);

            Gizmos.DrawLine(enemyEye.position, enemyEye.position + enemyEye.forward * playerCheckDistance);
        }

    }
}


