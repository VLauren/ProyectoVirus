using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public static float VELOCIDAD = 10;

    void Update ()
    {
        transform.Translate(0, 0, VELOCIDAD * Time.deltaTime);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Virus")
        {
            c.GetComponent<Virus>().Herir();
            Destroy(gameObject);
        }
    }
}
