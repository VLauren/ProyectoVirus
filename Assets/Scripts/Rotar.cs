using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 120, 0, Space.World);
    }
}
