using Unity.VisualScripting;
using UnityEngine;

namespace TuringTest
{
    public class BulletShootStrategy : IShootStrategy
    {
        PlayerShoot playerShoot;
        Transform shootPoint;

        public BulletShootStrategy(PlayerShoot shootStrategy)
        {
            playerShoot = shootStrategy;
            shootPoint = playerShoot.shootCrosshair;
            playerShoot.gunRenderer.material.color = playerShoot.bulletGunColor;
        }


        public void Shoot()
        {
            PooledObject poolBullet = playerShoot.bulletPool.GetPooledObject();
            poolBullet.gameObject.SetActive(true);
            Rigidbody bullet = poolBullet.GetComponent<Rigidbody>();
            bullet.linearVelocity = Vector3.zero;
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;

            bullet.AddForce(shootPoint.forward * playerShoot.shootForceMultiplier);
            playerShoot.bulletPool.DestroyPooledObject(poolBullet, 5.0f);
        }

       
    }
}
