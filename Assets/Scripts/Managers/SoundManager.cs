using System.Collections;
using UnityEngine;

namespace TuringTest
{
    public class SoundManager : MonoBehaviour
    {
        private AudioSource audioSource1, audioSource2;
        [SerializeField] private AudioClip room2Intro, doorFailure, firstKeyPadFailure, alarmClip, countDown;
        [SerializeField] private float timer = 30f;
        [SerializeField] private float secondaryTimer = 11f;
        private bool alarmStarted = false;
        [SerializeField] private Health playerHealth;
        public bool countdownStarted;


        private void Start()
        {
            audioSource1 = gameObject.AddComponent<AudioSource>();
            audioSource2 = gameObject.AddComponent<AudioSource>();
        }

        private void Update()
        {
            if (alarmStarted)
            {
                if(timer > 10.9f)
                {
                    timer -= Time.deltaTime;
                    if (timer < 11f)
                    {
                        PlayCountDown();
                        countdownStarted = true;
                    }
                }  
            }
            if (countdownStarted)
            {
                secondaryTimer -= Time.deltaTime;
                if(secondaryTimer <= 0)
                {
                    playerHealth.ChangeHealth(-100f);
                }
            }
        }
        public void PlayRoom2Intro()
        {
            audioSource1.clip = room2Intro;
            audioSource1.Play();
        }
        public void DoorClip()
        {
            StartCoroutine(DoorClipDelay());
        }
        public void PlayFirstKeyPadFailure()
        {
            audioSource2.clip = firstKeyPadFailure;
            audioSource2.Play();
        }
        public void PlayAlarmClip()
        {
            audioSource1.clip = alarmClip;
            audioSource1.Play();
            alarmStarted = true;
        }
        public void StopAlarmClip()
        {
            audioSource1.Stop();
        }
        public void PlayCountDown()
        {
            audioSource2.clip = countDown;
            audioSource2.Play();
        }
        public void StopCountDown()
        {
            audioSource2.clip = null;
        }
        public void CancelCountDown()
        {
            alarmStarted = false;
        }
        

        IEnumerator DoorClipDelay()
        {
            yield return new WaitForSeconds(1.75f);
            audioSource1.clip = doorFailure;
            audioSource1.Play();
        }


    }
}
