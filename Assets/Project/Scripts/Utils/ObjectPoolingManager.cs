using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        private static ObjectPoolingManager instance;
        public static ObjectPoolingManager Instance { get { return instance; } }

        public GameObject bulletPrefab;
        public int bulletAmount = 20;

        private List<GameObject> bullets;

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;

            //Preload bullets
            bullets = new List<GameObject>(bulletAmount);

            //Make 20 diabled bullets
            for(int i = 0 ; i < bulletAmount ; i++)
            {
                GameObject prefabInstance = Instantiate(bulletPrefab);
                //Make the bullets show under the manager
                prefabInstance.transform.SetParent(transform);
                prefabInstance.SetActive(false);

                bullets.Add(prefabInstance);
            }
        }

        public GameObject GetBullet()
        {
            //Debug.Log("Bullet");
            //return null;

            //We loop over the billets to find an inactive one
            foreach (GameObject bullet in bullets)
            {
                if (!bullet.activeInHierarchy){
                    bullet.SetActive(true);
                    return bullet;
                }
            }

            //If we have no inactive bullets, we make a new one.
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            bullets.Add(prefabInstance);
            return prefabInstance;
        }
    }
}
