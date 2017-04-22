using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    public static float VELOCIDAD = 2;

    public int cantidad = 1;
    Vector3 direccion;

    void Awake()
    {
        direccion = Quaternion.Euler(0, Random.value * 360, 0) * new Vector3(0, 0, 1);
    }

    void Update()
    {
        transform.Translate(direccion * VELOCIDAD * Time.deltaTime, Space.World);

        BordePantalla.Check(transform);
    }
}
