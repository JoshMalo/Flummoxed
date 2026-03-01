using UnityEngine;

namespace TuringTest
{
    public class PlayerLook : MonoBehaviour
    {
        private PlayerInput input;
        [SerializeField] private Transform cameraPivot;
        [SerializeField] private float lookSensitivity = 0.1f;
        private float xRotation;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            input = PlayerInput.GetInstance();
        }

        private void Update()
        {
            Look();
        }

        private void Look()
        {
            Vector2 look = input.LookInput * lookSensitivity;
            xRotation -= look.y;
            xRotation = Mathf.Clamp(xRotation, -80, 80);

            cameraPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);
            transform.Rotate(Vector3.up * look.x);
        }

        public void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        public void UnlockMouse()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
