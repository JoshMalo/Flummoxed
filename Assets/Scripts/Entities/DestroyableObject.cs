using UnityEngine;

namespace TuringTest
{
    public class DestroyableObject : MonoBehaviour, IDestroyable
    {
        public void OnCollided()
        {
            Destroy(gameObject);
        }
    }
}

