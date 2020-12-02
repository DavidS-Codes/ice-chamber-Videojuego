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

    private Text textoTiempo;
    private float tiempoFrameConTimeSale = 0f;
    private float tiempoMostrarEnSegundos = 0f;
    private float escalaTiempoPausado, escalaTiempoInicial; //guardar tiempo al pausar

    private bool eventoTiempoCero = false;


    //Delegado para el evento tiempo cero
    public delegate void AccionTiempoCero();
    //Evento
    public static event AccionTiempoCero llegarCero;

    void Start()
    {
        escalaTiempoInicial = escalaTiempo; //guardar escala de tiempo
        textoTiempo = GetComponent<Text>(); //Obtener el componente texto del canvas
        
        //Variable que acumula los tiempos del frame con el tiempo inicial 
        tiempoMostrarEnSegundos = tiempoInicial; 
        ActualizarReloj(tiempoInicial); //El tiempo transcurido se debe ir modificando
    }
        
    // Update is called once per frame
    void Update()
    {   //tiempo de cada frame considerando la escala de tiempo
        tiempoFrameConTimeSale = Time.deltaTime * escalaTiempo; 

        //Va acumulando el tiempo transcurrido para luego mostrarlo en el reloj
        tiempoMostrarEnSegundos += tiempoFrameConTimeSale;
        ActualizarReloj(tiempoMostrarEnSegundos);

    }

    public void ActualizarReloj(float tiempoEnSegundos)
    { 
        int minutos = 0;
        int segundos = 0;
        // int milisegundos = 0;
        string textoDelReloj;

        //Validar que el tiempo no sea negativo
        if (tiempoEnSegundos <= 0 && !eventoTiempoCero)
        {
            if (llegarCero != null)
            {
                llegarCero();
            }
            eventoTiempoCero = true;
        }

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        //calcular minutos y segundos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;
        //milisegundos = (int)tiempoEnSegundos / 1000;

        //Convertir los minutos y segundos a string para poderlos visualizar
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); //+ ":" + milisegundos.ToString("00");

        //Actualiza el elemento  de texto de UI con la cadena de caracteres
        textoTiempo.text = textoDelReloj;
    }

    public void Reiniciar() {
        eventoTiempoCero = false;
    }
}
