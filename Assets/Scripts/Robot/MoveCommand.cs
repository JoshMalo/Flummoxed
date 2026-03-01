using UnityEngine;
using UnityEngine.AI;

namespace TuringTest
{
    public class MoveCommand : Command
    {
        private NavMeshAgent agent;
        private Vector3 destination;

        public MoveCommand(NavMeshAgent agentMesh, Vector3 rayCastPosition)
        {
            agent = agentMesh;
            destination = rayCastPosition;
        }

            
        public override void Execute()
        {
            agent.SetDestination(destination);           
        }

        public override bool isComplete => ReachedDestination();

        bool ReachedDestination()
        {
            if(agent.remainingDistance > 0.1f)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        


    }
}
