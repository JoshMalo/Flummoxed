using UnityEngine;
using UnityEngine.SceneManagement;

namespace TuringTest
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObject wall;
        public void RestartGame()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex);
           
        }

        private void OnTriggerEnter(Collider other)
        {
            wall.SetActive(true);
        }
    }
}
