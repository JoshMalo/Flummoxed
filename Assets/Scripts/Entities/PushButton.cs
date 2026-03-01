using UnityEngine;
using UnityEngine.Events;

namespace TuringTest
{
    public class PushButton : MonoBehaviour, ISelectable
    {
        [SerializeField] private Material hoverColor;

        private MeshRenderer meshRenderer;
        private Material defaultColor;

        public UnityEvent onPush;

        private void Start()
        {
            
            meshRenderer = GetComponent<MeshRenderer>();
            defaultColor = meshRenderer.material;
        }

        public void OnHoverEnter()
        {
            meshRenderer.material = hoverColor;
        }

        public void OnHoverExit()
        {
            meshRenderer.material = defaultColor;
        }

        public void OnSelect()
        {
            onPush?.Invoke();
        }

    }
}

