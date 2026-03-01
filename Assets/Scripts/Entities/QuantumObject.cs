using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TuringTest
{
    public class QuantumObject : MonoBehaviour
    {
        [SerializeField] private Transform[] possiblePositions;
        [SerializeField] private LayerMask layerToCheck;
        [SerializeField] private GameObject cubeToMove;
        [SerializeField] private Camera mainCam;
        [SerializeField] private bool lookingAtCube, canMove = false;
        [SerializeField] private Transform cubeTransform;

        private Plane[] cameraFrustum;
        private Collider collider;
        
        


        private void Start()
        {
            cubeTransform = cubeToMove.transform;
            collider = GetComponent<Collider>();
        }


        private void Update()
        {
            var bounds = collider.bounds;
            cameraFrustum = GeometryUtility.CalculateFrustumPlanes(mainCam);

            if(GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
                lookingAtCube = true;
                canMove = true;
                return;  
            }
            else
            {
                if (lookingAtCube && canMove) 
                {
                    cubeToMove.transform.position = GetRandomIndex(possiblePositions).position;
                    canMove = false;
                    lookingAtCube = false;
                } 
            }

        }


 

        private Transform GetRandomIndex(Transform[] transformArray)
        {
            int randomIndex = Random.Range(0, transformArray.Length);
            return transformArray[randomIndex];
        }

    }
}
