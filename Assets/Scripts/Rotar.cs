using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public float velocidad = 120;
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * velocidad, 0, Space.World);
    }
}
