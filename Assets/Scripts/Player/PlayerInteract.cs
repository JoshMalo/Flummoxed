using UnityEngine;

namespace TuringTest
{
    public class PlayerInteract : MonoBehaviour
    {     
        [SerializeField] private LayerMask interactionLayer;
        [SerializeField] private float interactionDistance;

        private PlayerInput input;
        [SerializeField] private Camera cam;

        private RaycastHit rayCasthit;
        private ISelectable selectable;

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

            if(Physics.Raycast(ray, out rayCasthit, interactionDistance, interactionLayer))
            {
                selectable = rayCasthit.transform.GetComponent<ISelectable>();
            }
            if(selectable != null)
            {
                selectable.OnHoverEnter();
                if(input.InteractPressed)
                {
                    selectable.OnSelect();
                }
            }
            if(rayCasthit.transform == null && selectable != null)
            {
                selectable.OnHoverExit();
                selectable = null;
            }
        }
    }
}

