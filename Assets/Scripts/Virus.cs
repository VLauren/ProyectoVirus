using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    const float FRECUENCIA = 0.5f;
    const float AMPLITUD = 0.2f;

    public int vida = 1;
    public int puntos = 100;
    public float velocidad = 2;
    public List<GameObject> spawn;
    
    Vector3 direccion;

    GameObject modelo;
    float tIni;
    Vector3 scaleIni;

    public void Awake()
    {
        modelo = transform.Find("Modelo").gameObject;
        direccion = Quaternion.Euler(0, Random.value * 360, 0) * new Vector3(0, 0, 1);
        tIni = Random.value;
        scaleIni = modelo.transform.localScale;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        BordePantalla.Check(transform);

        float sX = Mathf.Sin(Mathf.PI * 2 * (Time.time * FRECUENCIA + tIni)) * AMPLITUD;
        float sZ = Mathf.Cos(Mathf.PI * 2 * (Time.time * FRECUENCIA + tIni)) * AMPLITUD;
        modelo.transform.localScale = new Vector3(sX, 0, sZ) + scaleIni;
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
                GameObject obj = Instantiate(go, transform.position + ((Quaternion.Euler(0, y, 0) * new Vector3(0, 0, 1)) * 0.3f), Quaternion.identity);
                Debug.Log(obj.name + " " + obj.transform.rotation.eulerAngles);
                if (obj.GetComponent<Virus>() != null)
                    SpawnEnemigos.VirusNuevo(obj.GetComponent<Virus>());
            }

            SpawnEnemigos.VirusMuerto(this);
            FX.GenerarFX(1,transform.position);
            Camara.Shake();
            Puntos.SumarPuntos(puntos);
            Destroy(gameObject);
        }
    }
}
