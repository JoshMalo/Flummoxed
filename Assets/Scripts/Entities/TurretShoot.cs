using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace TuringTest
{
    public class TurretShoot : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        private bool canShoot = true;
        [SerializeField] private ObjectPool turretBulletPool;
        [SerializeField] private Transform turretTransform;
        [SerializeField] private Transform shootPoint;

        private void Start()
        {
            
        }

        private void Update()
        {
            if (canShoot)
                StartCoroutine(TurretShootCooldown());
        }

       private void Shoot()
       {
            PooledObject poolBullet = turretBulletPool.GetPooledObject();
            poolBullet.gameObject.SetActive(true);
            Rigidbody bullet = poolBullet.GetComponent<Rigidbody>();
            bullet.linearVelocity = Vector3.zero;
            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;

            bullet.AddForce(shootPoint.forward * 200);
            turretBulletPool.DestroyPooledObject(poolBullet, 5.0f);

        }

        IEnumerator TurretShootCooldown()
        {
            Shoot();
            canShoot = false;
            yield return new WaitForSeconds(0.5f);
            canShoot = true;
            
        }
    }
}
