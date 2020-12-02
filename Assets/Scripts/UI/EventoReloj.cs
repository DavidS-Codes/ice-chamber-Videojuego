using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EventoReloj : MonoBehaviour
{
    private void OnEnable() {
        Reloj.llegarCero += tiempoFinalizado;   
    }

    private void OnDisable() {
        Reloj.llegarCero -= tiempoFinalizado;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void tiempoFinalizado() {
        SceneManager.LoadScene(0);
    }
}
