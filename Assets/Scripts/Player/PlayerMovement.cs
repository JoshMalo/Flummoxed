using UnityEngine;
using UnityEngine.Windows;

namespace TuringTest
{
    [RequireComponent(typeof(CharacterController))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 6.0f, sprintSpeed = 10.0f, gravity = -9.81f, jumpHeight = 2f;

        private CharacterController controller;
        private PlayerInput input;
        private Vector3 velocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            input = PlayerInput.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            ApplyGravity();
            Jump();
        }

        private void Move()
        {

            Vector2 moveInput = input.MoveInput;
            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;

            float currentSpeed;

            if (input.SprintPressed)
            {
                currentSpeed = sprintSpeed;
            }
            else
            {
                currentSpeed = moveSpeed;
            }

            controller.Move(move * currentSpeed * Time.deltaTime);
        }


        private void Jump()
        {
            if (controller.isGrounded && velocity.y < 0)
                velocity.y = -1f;

            if (controller.isGrounded && input.JumpPressed)
                velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        private void ApplyGravity()
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
