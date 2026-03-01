using UnityEngine;

namespace TuringTest
{
    public class PooledObject : MonoBehaviour
    {
        private float timer;
        private bool setToDestroy = false;
        private float destroyTime = 0f;

        ObjectPool associatedPool;

        private void Update()
        {
            if (setToDestroy)
            {
                timer += Time.deltaTime;
                if(timer>=destroyTime)
                {
                    setToDestroy = false;
                    timer = 0;
                    Destroy();
                }
            }
        }
        public void SetObjectPool(ObjectPool pool)
        {
            associatedPool = pool;
            timer = 0f;
            destroyTime = 0f;
            setToDestroy = false;
        }

        public void Destroy()
        {
            if(associatedPool != null)
            {
                associatedPool.RestoreObject(this);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy();
        }


        public void Destroy(float time)
        {
            setToDestroy = true;
            destroyTime = time;
        }
    }
}
