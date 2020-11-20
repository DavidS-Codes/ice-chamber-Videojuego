using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){

    }
    // Update is called once per frame
    void Update(){
            
    }
    private void OnTriggerEnter2D(Collider2D colider){

        if(colider.gameObject.transform.root.gameObject.CompareTag("Player")){
            colider.gameObject.transform.root.gameObject.GetComponentInChildren<PlayerMovement>().destroyPlayer();
        }
    }
}
