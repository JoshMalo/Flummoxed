using UnityEngine;

namespace TuringTest
{
    public interface IPickable
    {
        public void OnPicked(Transform attachTransform);
        public void OnDropped();
    }
}