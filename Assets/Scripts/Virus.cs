﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public int vida = 1;
    public float velocidad = 2;
    public List<GameObject> spawn;
    
    Vector3 direccion;

    GameObject modelo;

    public void Start()
    {
        modelo = transform.Find("Modelo").gameObject;
        direccion = Quaternion.Euler(0, Random.value * 360, 0) * new Vector3(0, 0, 1);
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

        CheckBordes();
    }

    public void Herir()
    {
        // Destruir
        {
            Vector3 direccionSpawn = new Vector3(0, 0, 1);

            float y = Random.value * 360;
            foreach (GameObject go in spawn)
            {
                y += 360 / spawn.Count;
                Instantiate(go, transform.position + ((Quaternion.Euler(0, y, 0) * new Vector3(0, 0, 1)) * 0.3f), Quaternion.identity);
            }

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
