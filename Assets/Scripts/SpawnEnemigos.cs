using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemigos : MonoBehaviour
{
    private const int INCREMENTO_VG = 1;
    private const int INCREMENTO_VM = 1;
    private const int INCREMENTO_VC = 1;

    private static SpawnEnemigos instance;

    public GameObject VirusGrande;
    public GameObject VirusMedianoA;
    public GameObject VirusMedianoB;
    public GameObject VirusChicoA;
    public GameObject VirusChicoB;
    public GameObject VirusChicoC;

    List<Virus> virusActuales = new List<Virus>();

    // ===========================

    int virusGrandes = 1;
    int virusMedianos = 1;
    int virusChicos = 1;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SiguienteNivel();
    }

    public static void VirusNuevo(Virus v)
    {
        instance.virusActuales.Add(v);
    }

    public static void VirusMuerto(Virus v)
    {
        instance.virusActuales.Remove(v);
        if (instance.virusActuales.Count == 0)
            instance.SiguienteNivel();
    }


    void SiguienteNivel()
    {
        StartCoroutine(SpawnSiguienteNivel());
    }

    public static void GameOver()
    {
        instance.StartCoroutine(instance.Restart());
    }

    float minX, minZ, maxX, maxZ, distancia;
    IEnumerator SpawnSiguienteNivel()
    {
        yield return new WaitForSeconds(1);

        // Hallo los bordes de la pantalla
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width, Screen.height, 0));
        plane.Raycast(ray, out distancia);
        maxX = ray.GetPoint(distancia).x;
        maxZ = ray.GetPoint(distancia).z;

        ray = Camera.main.ScreenPointToRay(new Vector3(0, 0, 0));
        plane.Raycast(ray, out distancia);
        minX = ray.GetPoint(distancia).x;
        minZ = ray.GetPoint(distancia).z;

        Spawn(virusGrandes, VirusGrande);
        Spawn(virusMedianos, VirusMedianoB);
        Spawn(virusChicos, VirusChicoC);

        virusGrandes += INCREMENTO_VG;
        virusMedianos += INCREMENTO_VM;
        virusChicos += INCREMENTO_VC;
    }

    void Spawn(int num, GameObject tipo)
    {
        for (int i = 0; i < num; i++)
        {
            Vector3 randomPosition = Vector3.zero;
            randomPosition.x = minX + Random.value * (maxX - minX);
            randomPosition.z = minZ + Random.value * (maxZ - minZ);

            if (Random.value > 0.5f)
            {
                if (Random.value > 0.5f)
                    randomPosition.x = minX;
                else
                    randomPosition.x = maxX;
            }
            else
            {
                if (Random.value > 0.5f)
                    randomPosition.z = minZ;
                else
                    randomPosition.z = maxZ;
            }

            GameObject v = Instantiate(tipo, randomPosition, Quaternion.identity);
            virusActuales.Add(v.GetComponent<Virus>());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1);

        Puntos.Reset();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }
}
