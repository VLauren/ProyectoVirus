using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour
{
    static Interfaz instance;

    Text puntuacion;
    Text municion;

    void Awake ()
    {
        instance = this;
        puntuacion = transform.Find("Puntuacion").GetComponent<Text>();
        municion = transform.Find("Municion").GetComponent<Text>();
    }
	
	public static void SetPuntos(int puntuacion)
    {
        instance.puntuacion.text = "Score: " + puntuacion;

        instance.puntuacion.color = new Color(1, 0.7f, 0);
        instance.contador2 = 0.1f;
    }

    public static void SetMunicion(int municion)
    {
        instance.municion.text = "Ammo: " + municion;
    }

    public static void SinMunicion()
    {
        instance.municion.color = Color.red;
        instance.contador = 0.1f;
    }

    float contador;
    float contador2;

    void Update()
    {
        if (contador > 0)
            contador -= Time.deltaTime;
        if (contador < 0)
        {
            contador = 0;
            instance.municion.color = Color.white;
        }

        if (contador2 > 0)
            contador2 -= Time.deltaTime;
        if (contador2 < 0)
        {
            contador2 = 0;
            instance.puntuacion.color = Color.white;
        }

    }
}
