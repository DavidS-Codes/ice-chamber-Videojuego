using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject camara;
    public GameObject destino;
    public Vector3 posicionCamara;
    public Vector3 posicionDestino;
    public static float tiempo;

    public Transform transformDestino; //Refrencia a la posicion destino
    public bool UsarTiempo; //Si no usa tiempo usa velocidad
    public float Tiempo; //Tiempo en recorrer la distancia
    public float Velocidad; //A que velocidad //Solo se usa si UsarTiempo esta activo

    public float rateTiempo;
    public float rateVelocity;
    public float rate; //El rate o factor movimiento que realmente se utilizara
    public float t = 0.0f; //ayuda


    // Start is called before the first frame update
    void Start()
    {
        camara = GameObject.Find("Main Camera");
        posicionCamara = camara.transform.position;

        destino = GameObject.Find("Destino");
        posicionDestino = destino.transform.position;

        Tiempo = 1.2f;
        UnityEngine.Debug.Log("posicionCamara :" + posicionCamara);
        UnityEngine.Debug.Log("posicionDestino :" + posicionDestino);

        if (UsarTiempo)
        {
            float rateTiempo = 1f / Tiempo; //Calculamos cuanto nos moveremos para comprir la distancia siempre en el mismo tiempo
            rate = rateTiempo;
        }
        else //Entonces nos moveremos a una velocidad fija
        {
            //Calculamos cuanto tenemos que movernos para movernos a una velocidad fija
            float rateVelocity = 1f / Vector3.Distance(posicionCamara, posicionDestino) * Velocidad;
            rate = rateVelocity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 1f)
        {
            t += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(posicionCamara, posicionDestino, t);
        }
    }
}
