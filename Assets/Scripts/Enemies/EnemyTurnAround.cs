using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnAround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Detecte Pared");
            Vector3 scale = new Vector3(transform.root.localScale.x * -1,
                transform.root.localScale.y,
                transform.root.localScale.z);

            transform.root.localScale = scale;
        }
    }
}
