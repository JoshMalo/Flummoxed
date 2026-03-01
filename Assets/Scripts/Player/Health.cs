using UnityEngine;
using System;


namespace TuringTest
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        public Action<float> OnHealthUpdated;
        public Action OnDeath;

        public bool isDead {  get; private set; }
        private float health;


        #region singleton
        private static Health instance;
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(instance);
                return;
            }
            instance = this; 

        }
        public static Health GetInstance() { return instance; }
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            health = maxHealth;
            OnHealthUpdated(maxHealth); // ui manager will update the health right away.
        }

        public void ChangeHealth(float value)
        {
            if (isDead) return;

            health += value;
            if(health <= 0)
            {
                isDead = true;
                OnDeath();
                health = 0;
            }

            OnHealthUpdated(health);
        }

        
     
    }
}
