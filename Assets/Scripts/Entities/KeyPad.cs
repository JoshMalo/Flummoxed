using System.Collections;
//using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.LowLevel;
using UnityEngine.UI;

namespace TuringTest
{
    public class KeyPad : MonoBehaviour
    {

        [SerializeField] private Text Ans;
        private string Answer = "8547";
        public UnityEvent OnCodeCorrect;
        private bool firstAttempt = true;
        private bool canType = true;
        [SerializeField] private PlayerLook playerLook;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private Animator animator;
        [SerializeField] private Button button;

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerLook.enabled = false;
            playerMovement.enabled = false;
            playerShoot.enabled = false;
        }
        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            playerLook.enabled = true;
            playerMovement.enabled = true;
            playerShoot.enabled = true;
        }
        public void Number(int number)
        {
            if (canType)
            {
                Ans.text += number.ToString();
            }     
        }
        public void Execute()
        {
            if (Ans.text == Answer)
            {
                Ans.text = "Correct";
                soundManager.countdownStarted = false;
                soundManager.StopAlarmClip();
                soundManager.StopCountDown();
                canType = false;
                OnCodeCorrect.Invoke();
                StartCoroutine(ExitKeypad());
                StartCoroutine(ResetKeypad());
                animator.Play("DoorBrokenComplete");
            }
            else
            {
                if (firstAttempt)
                {
                    if (Ans.text == Answer)
                    {
                        Ans.text = "Correct";
                        soundManager.countdownStarted = false;
                        canType = false;
                        OnCodeCorrect.Invoke();
                        StartCoroutine(ExitKeypad());
                        StartCoroutine(ResetKeypad());
                        animator.Play("DoorBrokenComplete");
                    }

                    soundManager.PlayAlarmClip();
                    soundManager.PlayFirstKeyPadFailure();
                    Ans.text = "Invalid";
                    firstAttempt = false;
                    canType = false;
                    StartCoroutine(ResetKeypad());
                    StartCoroutine(ExitKeypad());
                }
                Ans.text = "Invalid";
                canType = false;
                StartCoroutine(ResetKeypad());

            }   
        }
           
        IEnumerator ResetKeypad()
        {
            yield return new WaitForSeconds(1f);
            Ans.text = "";
            canType = true;
        }

        IEnumerator ExitKeypad()
        {
            yield return new WaitForSeconds(1f);
            this.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
            
        }
    }
}
