using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public static float VELOCIDAD = 10;

    void Update ()
    {
        transform.Translate(0, 0, VELOCIDAD * Time.deltaTime);
        CheckBordes();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Virus")
        {
            c.GetComponent<Virus>().Herir();
            Destroy(gameObject);
        }
    }

    void CheckBordes()
    {
        if (Camera.main.WorldToScreenPoint(transform.position).x < 0)
            transform.position += new Vector3(20, 0, 0);
        if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width)
            transform.position += new Vector3(-20, 0, 0);
        if (Camera.main.WorldToScreenPoint(transform.position).y < 0)
            transform.position += new Vector3(0, 0, 16);
        if (Camera.main.WorldToScreenPoint(transform.position).y > Screen.height)
            transform.position += new Vector3(0, 0, -16);
    }
}
