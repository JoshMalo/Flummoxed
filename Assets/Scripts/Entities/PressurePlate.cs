using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace TuringTest
{
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private float checkRadius;
        [SerializeField] private LayerMask pickUpLayer;

        public UnityEvent OnCubePlaced;
        public UnityEvent OnCubeRemoved;

        private void OnCollisionEnter(Collision collision)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius, pickUpLayer);

            foreach(Collider collider in hitColliders)
            {
                if (collider.CompareTag("PickCube") || collider.CompareTag("QuantumCube"))
                {
                    OnCubePlaced?.Invoke();
                    break;
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("PickCube"))
            {
                OnCubeRemoved?.Invoke();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, checkRadius);
              
        }
    }
}

