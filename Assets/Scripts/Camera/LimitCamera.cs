using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    //public GameObject camara;
    //public Rigidbody2D rb;
    //public GameObject camara;



    // Start is called before the first frame update
    void Start()
    {
        //camara = ;

    }
    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnTriggerEnter2D(Collider2D colider) {

        if(colider.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            colider.gameObject.transform.root.gameObject.GetComponentInChildren<PlayerMovement>().destroyPlayer();
        }


     }
}
