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
    }

    public static void SetMunicion(int municion)
    {
        instance.municion.text = "Ammo: " + municion;
    }
}
