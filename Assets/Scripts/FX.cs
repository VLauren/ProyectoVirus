using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    static FX instance;

    public GameObject FX1;
    public GameObject FX2;
    public GameObject FX3;

    void Awake()
    {
        instance = this;
    }

    public static GameObject GenerarFX(int n, Vector3 pos)
    {
        GameObject res = null;
        if (n == 1 && instance.FX1 != null)
            res = Instantiate(instance.FX1, pos, Quaternion.identity);
        if (n == 2 && instance.FX2 != null)
            res = Instantiate(instance.FX2, pos, Quaternion.identity);
        if (n == 3 && instance.FX2 != null)
            res = Instantiate(instance.FX3, pos, Quaternion.identity);
        return res;
    }

}
