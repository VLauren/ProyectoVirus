using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public int vida = 1;
    public List<GameObject> spawn;

    public void Herir()
    {
        Destroy(gameObject);
    }
}
