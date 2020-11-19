using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
    {
       [Tooltip("Tiempo inicial en segundos")]
    public int tiempoInicial;

    [Tooltip("Escala de Tiempo")]
    [Range(-10.0f, 10.0f)]

    public float escalaTiempo = 1;
    // Start is called before the first frame update

    private Text textoTiempo;
    private float tiempoFrameConTimeSale = 0f;
    private float tiempoMostrarEnSegundos = 0f;
    private float escalaTiempoPausado, escalaTiempoInicial;
  //  private bool estaPausado = false;
    private bool eventoTiempoCero = false;


    //Delegado para el evento tiempo cero
    public delegate void AccionTiempoCero();
    //Evento
    public static event AccionTiempoCero llegarCero;

    void Start()
    {
        escalaTiempoInicial = escalaTiempo;

        textoTiempo = GetComponent<Text>();

        tiempoMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoFrameConTimeSale = Time.deltaTime * escalaTiempo;
        tiempoMostrarEnSegundos += tiempoFrameConTimeSale;
        ActualizarReloj(tiempoMostrarEnSegundos);

    }

    public void ActualizarReloj(float tiempoEnSegundos)
    { 
        int minutos = 0;
        int segundos = 0;
        // int milisegundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos <= 0 && !eventoTiempoCero)
        {

            if (llegarCero != null)
            {
                llegarCero();
            }
            eventoTiempoCero = true;

        }

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;
        //milisegundos = (int)tiempoEnSegundos / 1000;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); //+ ":" + milisegundos.ToString("00");

        //Actualiza el elemento  de texto de UI con la cadena de caracteres
        textoTiempo.text = textoDelReloj;
    }

    public void Reiniciar() {
        eventoTiempoCero = false;
    }
}
