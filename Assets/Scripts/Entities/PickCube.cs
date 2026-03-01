using UnityEngine;

namespace TuringTest
{
    public class PickCube : MonoBehaviour, IPickable
    {
        Rigidbody cubeRb;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            cubeRb = GetComponent<Rigidbody>();
        }

        public void OnPicked(Transform attachTransform)
        {
            if(cubeRb.isKinematic == false)
            {
                transform.position = attachTransform.position;
                transform.rotation = attachTransform.rotation;
                transform.SetParent(attachTransform);

                cubeRb.isKinematic = true;
                cubeRb.useGravity = false;
            }
        }

        public void OnDropped()
        {
            cubeRb.isKinematic = false;
            cubeRb.useGravity = true;
            transform.SetParent(null);
        }
    }
}
