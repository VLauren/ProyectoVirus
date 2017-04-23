using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particula : MonoBehaviour
{
    const float FRECUENCIA = 0.1f;
    const float AMPLITUD = 2;

    float tIni;
    float tIni2;
    Vector3 scaleIni;

    void Start ()
    {
        transform.Rotate(0, Random.value * 360, 0, Space.World);
        tIni = Random.value;
        tIni2 = Random.value;
        scaleIni = transform.localPosition;
    }
	
	void Update ()
    {
        float sX = Mathf.Sin(Mathf.PI * 2 * (Time.time * FRECUENCIA + tIni)) * AMPLITUD;
        float sZ = Mathf.Cos(Mathf.PI * 2 * (Time.time * FRECUENCIA + tIni2)) * AMPLITUD;

        //transform.localScale = new Vector3(sX, 0, sZ) + scaleIni;
        transform.localPosition = new Vector3(sX, 0, sZ) + scaleIni;

    }
}
