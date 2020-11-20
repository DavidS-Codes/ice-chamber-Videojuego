using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootUnique : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = transform.right * speed;
        //The direction to shoot the bullet
        Vector3 pos = rb.transform.forward * speed;
        //Shoot
        rb.velocity = pos;
    }

    // Update is called once per frame
   void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
