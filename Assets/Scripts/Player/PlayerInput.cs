using UnityEngine;
using UnityEngine.InputSystem;

namespace TuringTest
{
    [DefaultExecutionOrder(-100)]
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; } 
        public Vector2 LookInput { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool SprintPressed { get; private set; }
        public bool IsShooting { get; private set; }
        public bool NextPressed { get; private set; }
        public bool InteractPressed { get; private set; }
        public bool CommandPressed { get; private set; }


        [SerializeField] private PlayerInputAction actions;

        #region singleton
        private static PlayerInput instance;
        private void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(instance);
                return;
            }
            instance = this;
            actions = new PlayerInputAction();
        }
        public static PlayerInput GetInstance() { return instance; }
        #endregion

        private void OnEnable()
        {
            actions.Player.Enable();

            // Performed is a callback context and  we read the value from that. => means when its done performing
            actions.Player.Move.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
            actions.Player.Move.canceled += _ => MoveInput = Vector2.zero;

            actions.Player.Look.performed += ctx => LookInput = ctx.ReadValue<Vector2>();
            actions.Player.Look.canceled += _ => LookInput = Vector2.zero;

            actions.Player.Jump.performed += ctx => JumpPressed = true;
            actions.Player.Attack.performed += ctx => IsShooting = true;
            actions.Player.Next.performed += ctx => NextPressed = true;
            actions.Player.Command.performed += ctx => CommandPressed = true;

            actions.Player.Sprint.performed += ctx => SprintPressed = true;
            actions.Player.Sprint.canceled += _ => SprintPressed = false;  
            
            actions.Player.Interact.performed += ctx => InteractPressed = true;
        }

        private void LateUpdate()
        {
            JumpPressed = false;
            IsShooting = false;
            NextPressed = false;
            InteractPressed = false;
            CommandPressed = false;
            
        }

        private void OnDisable()
        {
            actions.Player.Disable(); // unsubscribing to the actions so that if the gameobject is turned off it isnt still trying to access them.
        }
    }
}