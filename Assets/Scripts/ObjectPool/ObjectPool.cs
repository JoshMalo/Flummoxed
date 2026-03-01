using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TuringTest
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject objectToPool;
        public int startSize;

        [SerializeField] private List<PooledObject> objectPool = new List<PooledObject>();
        [SerializeField] private List<PooledObject> usedObjectPool = new List<PooledObject>();

        private PooledObject tempObject;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            for (int i = 0; i < startSize; i++)
            {
                AddNewObject();
            }
        }

        void AddNewObject()
        {
            tempObject = Instantiate(objectToPool, transform).GetComponent<PooledObject>();
            tempObject.gameObject.SetActive(false);
            tempObject.SetObjectPool(this);
            objectPool.Add(tempObject);
        }

        public PooledObject GetPooledObject()
        {
            PooledObject tempPooledObject;
            if(objectPool.Count > 0)
            {
                tempPooledObject = objectPool[0];
                usedObjectPool.Add(tempPooledObject);
                objectPool.RemoveAt(0);
            }
            else
            {
                AddNewObject();
                tempPooledObject = GetPooledObject();
            }
            tempPooledObject.gameObject.SetActive(true);
            // tempPoolReset
            return tempPooledObject;

        }
        public void DestroyPooledObject(PooledObject obj, float time = 0)
        {
            if(time == 0)
            {
                obj.Destroy();
            }
            else
            {
                obj.Destroy(time);
            }
        }

     

        public void RestoreObject(PooledObject obj)
        {
            obj.gameObject.SetActive(false);
            usedObjectPool.Remove(obj);
            objectPool.Add(obj);

        }
        
    }
}

