using System.Runtime.CompilerServices;
using UnityEngine;

namespace TuringTest
{
    public class PlayerShoot : MonoBehaviour
    {
        private PlayerInput input;
        [Header("Gun")]
        public MeshRenderer gunRenderer;
        public Color bulletGunColor;
        public Color rocketGunColor;

        [Header("Pools")]
        [field: SerializeField] public ObjectPool bulletPool {  get; private set; }
        [field: SerializeField] public ObjectPool rocketPool { get; private set; }

        [Header("Etc")]
        [field: SerializeField] public Transform shootCrosshair { get; private set; }
        [field: SerializeField] public float shootForceMultiplier { get; private set; }

        private bool isSwitched;
        private IShootStrategy currentShootStrategy;

        private void Awake()
        {
           input = PlayerInput.GetInstance();
        }

        private void Update()
        {
            ShootStrategy();
        }

        private void ShootStrategy()
        {
            if (currentShootStrategy == null)
                currentShootStrategy = new BulletShootStrategy(this);

            if (input.NextPressed)
            {
                isSwitched = !isSwitched;
            }

            if (isSwitched)
            {
                currentShootStrategy = new BulletShootStrategy(this);
                if (input.IsShooting)
                {
                    
                    currentShootStrategy.Shoot();
                }   
            }
            else
            {
                currentShootStrategy = new RocketShootStrategy(this);
                if (input.IsShooting)
                {
                    
                    currentShootStrategy.Shoot();
                }
            }
        }
    }
}

