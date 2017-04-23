﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public static float VELOCIDAD_MAXIMA = 4;
    public static float ACCELERACION = 0.2f;
    public static float VELOCIDAD_ROTACION = 150;
    public static bool APLICAR_MUNICION = true;

    public GameObject disparo;

    public int municion = 3;

    Vector3 inercia = Vector3.zero;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        // Movimiento

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            // accelerar
            inercia += transform.forward * (ACCELERACION + Time.deltaTime);
            inercia.x = Mathf.Clamp(inercia.x, -VELOCIDAD_MAXIMA, VELOCIDAD_MAXIMA);
            inercia.z = Mathf.Clamp(inercia.z, -VELOCIDAD_MAXIMA, VELOCIDAD_MAXIMA);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
            transform.Rotate(0, Time.deltaTime * VELOCIDAD_ROTACION, 0);
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.Rotate(0, - Time.deltaTime * VELOCIDAD_ROTACION, 0);

        transform.Translate(inercia * Time.deltaTime, Space.World);

        // Disparo

        if (Input.GetButtonDown("Fire1") && (!APLICAR_MUNICION || municion > 0))
        {
            if (disparo != null)
                Instantiate(disparo, transform.position + transform.forward, transform.rotation);
            if (APLICAR_MUNICION)
                municion--;
            Debug.Log(APLICAR_MUNICION + " " + municion);
        }

        BordePantalla.Check(transform);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Virus")
        {
            Debug.Log("MUERTO");

            SpawnEnemigos.GameOver();
            Destroy(gameObject);
        }

        if (c.tag == "Municion")
        {
            municion += c.GetComponent<Municion>().cantidad;
            Destroy(c.gameObject);
        }
    }
}
