using UnityEngine;

namespace TuringTest
{
    public class LevelTrigger : MonoBehaviour
    {
        [SerializeField] private LevelManager endingLevel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                endingLevel.LevelExit();
            }
        }

    }
}
