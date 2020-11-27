using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersecutionEnemy : MonoBehaviour
{

    GameObject personaje;
    float speed = 1;

    private void OnTriggerStay2D(Collider2D collider)
    {
        Vector3 scalaEnemy = transform.root.localScale;
        if (collider.transform.root.gameObject.CompareTag("Player"))
        {
            personaje = collider.transform.root.gameObject;

            float fixedSpeed = speed * Time.deltaTime;
            transform.root.position = Vector3.MoveTowards(transform.root.position, personaje.transform.position, fixedSpeed);

            Vector3 scalaPersonaje = collider.transform.root.Find("Animator").transform.localScale;

            //if (scalaPersonaje.x == 1.0)
            //{
            //    transform.root.localScale.Set(-1, 1, 1);
            //}
            //else
            //{
            //    transform.root.localScale.Set(1, 1, 1);
            //}

            Vector3 posicion;
            if (scalaPersonaje.x == 1)
            //collider.transform.root.Find("Animator").transform.localScale.x > 0)
            {
                posicion = new Vector3(-1, 1, 1);
                transform.root.localScale = posicion;
            }
            else
            {
                posicion = new Vector3(1, 1, 1);
                transform.root.localScale = posicion;
            }


            Debug.DrawLine(transform.root.position, personaje.transform.position, Color.green);

            Debug.Log(transform.root.name);

        }

    }
}
