using UnityEngine;

namespace TuringTest
{
    public class Door : MonoBehaviour
    {
        private float openDelay = 1f;
        private float timer;
        private bool isOpen;

        private Color activeColor = Color.green;
        private Color defaultColor = Color.white;

        [SerializeField] private Animator animator;
        [SerializeField] private Renderer doorRenderer;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            timer = 0f;
            doorRenderer.material.color = activeColor;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            timer += Time.deltaTime;
            if(timer >= openDelay && !isOpen)
            {
                OpenDoor();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            CloseDoor();
            timer = 0f;
            doorRenderer.material.color = defaultColor;
        }

        private void OpenDoor()
        {
            isOpen = true;
            animator.SetBool("isOpen", true);
        }

        private void CloseDoor()
        {
            isOpen = true;
            animator.SetBool("isOpen", false);
        }
    }
}



