using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public static float VELOCIDAD_MAXIMA = 5;
    public static float ACCELERACION = 0.2f;
    public static float VELOCIDAD_ROTACION = 180;
    public static bool APLICAR_MUNICION = true;

    public GameObject disparo;

    public int municion = 3;

    bool propulsion = false;
    GameObject objetoPropulsion;
    float contMunicion;

    Vector3 inercia = Vector3.zero;
	
	void Update ()
    {
        // Movimiento

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            // accelerar
            inercia += transform.forward * (ACCELERACION + Time.deltaTime);
            //inercia.x = Mathf.Clamp(inercia.x, -VELOCIDAD_MAXIMA, VELOCIDAD_MAXIMA);
            //inercia.z = Mathf.Clamp(inercia.z, -VELOCIDAD_MAXIMA, VELOCIDAD_MAXIMA);
            inercia = Vector3.ClampMagnitude(inercia, VELOCIDAD_MAXIMA);
            if (!propulsion)
            {
                propulsion = true;
                objetoPropulsion = FX.GenerarFX(2, transform.Find("FXPropulsion").position);
                objetoPropulsion.transform.parent = transform.Find("FXPropulsion");
                objetoPropulsion.transform.localRotation = Quaternion.identity;
            }
        }
        else
        {
            if (propulsion)
            {
                objetoPropulsion.transform.parent = null;
                objetoPropulsion.GetComponent<ParticleSystem>().Stop();
                Destroy(objetoPropulsion.transform.Find("Halo").gameObject);
                objetoPropulsion.AddComponent<TTL>().tiempo = 3;
                propulsion = false;
            }

            Vector3 aux = Vector3.zero;
            inercia = Vector3.SmoothDamp(inercia, Vector3.zero, ref aux, 0.3f);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
            transform.Rotate(0, Time.deltaTime * VELOCIDAD_ROTACION, 0);
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.Rotate(0, - Time.deltaTime * VELOCIDAD_ROTACION, 0);

        transform.Translate(inercia * Time.deltaTime, Space.World);

        // Disparo
        if (Input.GetButtonDown("Fire1") && APLICAR_MUNICION && municion == 0)
            Interfaz.SinMunicion();

        if (Input.GetButtonDown("Fire1") && (!APLICAR_MUNICION || municion > 0))
        {
            if (disparo != null)
                Instantiate(disparo, transform.position + transform.forward, transform.rotation);
            if (APLICAR_MUNICION)
                municion--;
        }

        BordePantalla.Check(transform);
        Interfaz.SetMunicion(municion);

        transform.Find("Cadena").gameObject.SetActive(municion != 0);

        if (municion == 0)
            contMunicion += Time.deltaTime;
        else
            contMunicion = 0;

        if (contMunicion > 3)
            municion++;
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Virus")
        {
            FX.GenerarFX(3, transform.position);

            SpawnEnemigos.GameOver();
            Destroy(gameObject);
        }

        if (c.tag == "Municion")
        {
            municion += c.GetComponent<Municion>().cantidad;
            Destroy(c.gameObject);
            Puntos.SumarPuntos(50);
        }
    }
}
