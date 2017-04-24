using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    static Camara instance;

    Vector3 posInicial;
    Transform jugador;
    Vector3 vel;
    float shake;

    void Awake()
    {
        instance = this;
        posInicial = transform.position;
        if(jugador != null)
            jugador = GameObject.Find("Jugador").transform;
    }

    void Update()
    {
        if(jugador == null && GameObject.Find("Jugador") != null)
            jugador = GameObject.Find("Jugador").transform;
        if (jugador == null)
            return;

        Vector3 desplazamiento = jugador.position / 20;
        Vector3 posObjetivo = posInicial + desplazamiento + Random.onUnitSphere * shake * 0.5f;
        transform.position = Vector3.SmoothDamp(transform.position, posObjetivo, ref vel, 0.1f);

        if(shake > 0)
            shake -= Time.deltaTime;
        if (shake < 0)
            shake = 0;
    }

    public static void Shake()
    {
        instance.shake += 0.5f;
        if (instance.shake > 1)
            instance.shake = 1;
    }
}
