using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Make bullet speed
    public float speed = 50f;

    //Bullet lifetime
    public float lifeDuration = 1f;

    //Life clock
    private float lifeTimer;

    // Start is called before the first frame update
    void OnEnable()
    {
        lifeTimer = lifeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the bullet move
        transform.position += transform.forward * speed * Time.deltaTime;

        //Check if bullet should be destroyed
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            //Destroy bullet
            //Destroy(this.gameObject);

            //Set bullet to inactive
            gameObject.SetActive(false);
        }
    }
}
