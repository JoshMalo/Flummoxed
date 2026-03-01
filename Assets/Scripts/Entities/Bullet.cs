using UnityEngine;

namespace TuringTest
{
    public class Bullet : MonoBehaviour
    {
        private Health playerHealth;

        private void Start()
        {
            playerHealth = Health.GetInstance();
        }

        private void OnCollisionEnter(Collision collision)
        {
            IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
            if (destroyable != null)
            {
                destroyable.OnCollided();
            }
            //Destroy(gameObject);

            else if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.ChangeHealth(-25f);
            }
        }
    }
}

