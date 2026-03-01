using UnityEngine;

namespace TuringTest
{
    public class Builder : MonoBehaviour
    {
        [SerializeField] private GameObject objectToBuild;
        [SerializeField] private Transform placementPoint;
        

        public void Build()
        {
            Instantiate(objectToBuild, placementPoint.position, placementPoint.rotation * Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }
    }
}
