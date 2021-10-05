using Project.Scripts.Utils;
using UnityEngine;

namespace Project.Scripts.Game
{
    public class Player : MonoBehaviour
    {
        //Camera position
        public Camera playerCamera;

        //Prefab bullet
        //public GameObject bulletPrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Listen for gun mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Test bullet in console
                //Debug.Log("Fire!!");

                //Test pooling mananger
                //ObjectPoolingManager.Instance.GetBullet();
                //Instatiate a new bullet (Hard on memory)
                //GameObject bulletObject = Instantiate(bulletPrefab);
                //Use pooling manager to get a bullet
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();

                //Set bullet to the position of the current position of the player
                //we can also write: bulletObject.transform.position = this.transform.position
                //transform.forward means not a place i space but a place between x and y
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;


                //Make bullet move
                bulletObject.transform.forward = playerCamera.transform.forward;
            }
        }

        public void Kill()
        {
            
        }
    }
}
