
using UnityEngine;

namespace TuringTest
{
    public class Lift : MonoBehaviour
    {
        [SerializeField] private float moveDistance;
        [SerializeField] private bool isUp;
        [SerializeField] private float speed;

        private bool isMoving;
        Vector3 targetPosition;

        public void ToggleLift()
        {
            if(isMoving)
                return;

            if (isUp)
            {
                targetPosition = transform.localPosition - new Vector3(0f, moveDistance, 0f);
                isUp = false;
            }
            else
            {
                targetPosition = transform.localPosition + new Vector3(0f, moveDistance, 0f);
                isUp = true;
            }
            isMoving = true;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isMoving)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, speed * Time.deltaTime);
            }

            if(Vector3.Distance(transform.localPosition, targetPosition) < 0.05f)
            {
                isMoving = false;
            }
        }
    }
}

