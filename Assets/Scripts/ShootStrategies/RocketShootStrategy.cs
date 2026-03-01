using UnityEngine;

namespace TuringTest
{
    public class RocketShootStrategy : IShootStrategy
    {

        PlayerShoot playerShoot;
        Transform shootPoint;
        private float extraSpeed = 1.2f;

        public RocketShootStrategy(PlayerShoot shootStrategy)
        {
            playerShoot = shootStrategy;
            shootPoint = playerShoot.shootCrosshair;
            playerShoot.gunRenderer.material.color = playerShoot.rocketGunColor;
        }
           
        public void Shoot()
        {
            PooledObject poolRocket = playerShoot.rocketPool.GetPooledObject();
            poolRocket.gameObject.SetActive(true);
            Rigidbody rocket = poolRocket.GetComponent<Rigidbody>();
            rocket.linearVelocity = Vector3.zero;
            rocket.transform.position = shootPoint.position;
            rocket.transform.rotation = shootPoint.rotation;

            rocket.AddForce(shootPoint.forward * playerShoot.shootForceMultiplier * extraSpeed);
            playerShoot.rocketPool.DestroyPooledObject(poolRocket, 5.0f);
        }
    }
}