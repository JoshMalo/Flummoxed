using UnityEngine;
using UnityEngine.AI;

namespace TuringTest
{
    public class AIAgentHuman : MonoBehaviour
    {
        [SerializeField] private Transform followTarget;
        private NavMeshAgent agent;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
           agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.destination = followTarget.position;
        }
    }
}

