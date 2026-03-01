using UnityEngine;
using UnityEngine.AI;

namespace TuringTest
{
    public class BuildCommand : Command
    {
        private NavMeshAgent agent;
        private Builder builder;
        private Transform buildLocation;

        public BuildCommand(NavMeshAgent agent, Builder builder)
        {
            this.agent = agent;
            this.builder = builder;


        }

        public override bool isComplete => BuildComplete();

        public override void Execute()
        {
            if (builder == null)
                return;
            agent.SetDestination(builder.transform.position);
        }

        private bool BuildComplete()
        {
            if(agent.remainingDistance > 0.1f)
            {
                return false;
            }
            if (builder != null)
                builder.Build();
            return true;
           
        }
    }
}
