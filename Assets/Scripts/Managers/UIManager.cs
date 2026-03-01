using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

namespace TuringTest
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Health playerHealth;
        [SerializeField] private PlayerLook playerLook;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Image keyPad;

        [Header("Ui Elements")]
        public TMP_Text txtHealth;
        public GameObject gameOverText;

        private void Start()
        {
            gameOverText.SetActive(false);
        }

        private void OnEnable()
        {
            playerHealth.OnHealthUpdated += OnHealthUpdate; // subscribe to the c# action, and run our classes version of the method
            playerHealth.OnDeath += OnDeath;
        }

        private void OnHealthUpdate(float health)
        {
            txtHealth.text = "Health : " + Mathf.Floor(health).ToString();
        }

        private void OnDeath()
        {
            gameOverText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerLook.enabled = false;
            playerMovement.enabled = false;
            playerShoot.enabled = false; 
        }
        public void SetKeyPadActive()
        {
            StartCoroutine(SetKeyPadActiveDelay());
        }
        IEnumerator SetKeyPadActiveDelay()
        {
            yield return new WaitForSeconds(2.5f);
            keyPad.gameObject.SetActive(true);
        }
    }
}
