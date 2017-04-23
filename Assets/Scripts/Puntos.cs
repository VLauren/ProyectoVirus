using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Puntos
{
    public static int puntos;
	
    public static void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        Interfaz.SetPuntos(puntos);
    }

    public static void Reset()
    {
        puntos = 0; ;
        Interfaz.SetPuntos(puntos);
    }
}
