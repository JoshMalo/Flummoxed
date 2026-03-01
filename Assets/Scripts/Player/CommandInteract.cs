using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace TuringTest
{
    public class CommandInteract : MonoBehaviour
    {
        Queue<Command> commands = new Queue<Command>();

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private GameObject moveToPointer;
        private Camera cam;

        private Command currentCommand;
        private PlayerInput playerInput;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {         
            playerInput = PlayerInput.GetInstance();
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInput.CommandPressed)
            {
                CommandSend();
            }
            ProcessCommands();
        }

        private void CommandSend()
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.CompareTag("Ground"))
                {
                    GameObject pointer = Instantiate(moveToPointer);
                    pointer.transform.position = hitInfo.point;
                    commands.Enqueue(new MoveCommand(agent, hitInfo.point));
                }
                else if (hitInfo.transform.CompareTag("Builder"))
                {
                    commands.Enqueue(new BuildCommand(agent, hitInfo.transform.GetComponent<Builder>()));

                }
            }
            
        }

        void ProcessCommands()
        {
            if (currentCommand != null && !currentCommand.isComplete)
                return;
            if (commands.Count == 0)
                return;

            currentCommand = commands.Dequeue();
            currentCommand.Execute();
        }
    }
}
