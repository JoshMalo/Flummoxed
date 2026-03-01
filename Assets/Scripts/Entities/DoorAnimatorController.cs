using UnityEngine;

namespace TuringTest
{
    public class DoorAnimatorController : MonoBehaviour
    {
        private Animator DoorAnimator;
        [SerializeField] private string animatorParameter = "isOpen";
        private void Start()
        {
            DoorAnimator = GetComponent<Animator>();
        }

        public void DoorState(bool isOpen)
        {
            DoorAnimator.SetBool(animatorParameter, isOpen);
        }
    }
}

