using UnityEngine;

namespace TuringTest
{
    public abstract class Command
    {
        public abstract bool isComplete {  get; }
        public abstract void Execute();
    }
}
