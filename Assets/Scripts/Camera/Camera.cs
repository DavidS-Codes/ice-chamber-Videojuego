using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform TransformDestino; //refrencia a la posicion destino
    public bool UsarTiempo; //Si no usa tiempo usa velocidad
    public float Tiempo; //Tiempo en recorrer la distancia
    public float Velocidad; //A que velocidad //Solo se usa si UsarTiempo esta activo

    float rateTiempo;
    float rateVelocity;
    float rate; //El rate o factor movimiento que realmente se utilizara
    float t = 0.0f; //ayuda

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position; //Mi punto inicial del personaje
        if (UsarTiempo)
        {
            float rateTiempo = 1f / Tiempo; //Calculamos cuanto nos moveremos para comprir la distancia siempre en el mismo tiempo
            rate = rateTiempo;
        }
        else //Entonces nos moveremos a una velocidad fija
        {
            //Calculamos cuanto tenemos que movernos para movernos a una velocidad fija
            float rateVelocity = 1f / Vector3.Distance(startPos, TransformDestino.position) * Velocidad;
            rate = rateVelocity;
        }
    }

    void Update()
    {
        if (t <= 1f)
        {
            t += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, TransformDestino.position, t);
        }
    }
}
