using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar2 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Time.deltaTime * 15, Time.deltaTime * 5, Time.deltaTime * 5, Space.World);
    }
}
