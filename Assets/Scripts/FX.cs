using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    static FX instance;

    public GameObject FX1;

	void Awake()
    {
        instance = this;
    }

    public static void GenerarFX(int n, Vector3 pos)
    {
        if (n == 1 && instance.FX1 != null)
            Instantiate(instance.FX1, pos, Quaternion.identity);
    }

}
