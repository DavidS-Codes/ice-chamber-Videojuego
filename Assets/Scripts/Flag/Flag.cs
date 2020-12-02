using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D colider)
    {

        if (colider.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IniciarAnimacion", true);
        }
    }

    //void finalizarJuego()
    //{
    //    SceneManager.LoadScene("Scene2");
    //}
}
