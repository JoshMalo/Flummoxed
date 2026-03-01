using UnityEngine;
using UnityEngine.UIElements;

namespace TuringTest
{
    public class PlayerPickup : MonoBehaviour
    {
        [SerializeField] private LayerMask interactionLayer;
        [SerializeField] private float interactionDistance = 2f;

        private PlayerInput input;
        [SerializeField] private Camera cam;

        private RaycastHit rayCasthit;
        private IPickable pickable;
        private bool isPicked = false;
        [SerializeField] private Transform attachTransform;

        private void Awake()
        {
            input = PlayerInput.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            Interact();
        }

        void Interact()
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (Physics.Raycast(ray, out rayCasthit, interactionDistance, interactionLayer))
            {
                pickable = rayCasthit.transform.GetComponent<IPickable>();

                if (pickable != null)
                {
                    if (input.InteractPressed && !isPicked)
                    {

                        pickable.OnPicked(attachTransform);
                        isPicked = true;
                        return;
                    }
                }

            }
            
            if(input.InteractPressed && isPicked && pickable != null)
            {
                pickable.OnDropped();
                pickable = null;
                isPicked = false;
            }
        }
    }
}