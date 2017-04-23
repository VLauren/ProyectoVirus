using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    public static float VELOCIDAD = 2;
    public static Transform jugador;

    public int cantidad = 1;
    Vector3 inercia = Vector3.zero;

    Vector3 direccion;

    void Awake()
    {
        inercia = Quaternion.Euler(0, Random.value * 360, 0) * new Vector3(0, 0, 1) * VELOCIDAD;
        if (jugador == null)
            jugador = GameObject.Find("Jugador").transform;
    }

    void Update()
    {
        transform.Translate(inercia * Time.deltaTime, Space.World);

        BordePantalla.Check(transform);

        if (jugador == null)
            return;

        if (Vector3.Distance(jugador.position, transform.position) < 4)
        {
            inercia += (jugador.position - transform.position).normalized * (0.1f + Time.deltaTime);
        }
        else if (inercia.magnitude > VELOCIDAD)
        {
            Vector3 v = Vector3.zero;
            inercia = Vector3.SmoothDamp(inercia, Vector3.ClampMagnitude(inercia, VELOCIDAD), ref v, 0.2f);
        }
    }
}
