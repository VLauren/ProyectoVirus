using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BordePantalla
{
    public const int MARGEN = 50;

    public static void Check(Transform transform)
    {
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distancia;

        if (Camera.main.WorldToScreenPoint(transform.position).x < -MARGEN)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width + MARGEN / 2, 0, 0));
            plane.Raycast(ray, out distancia);
            transform.position = new Vector3(ray.GetPoint(distancia).x, 0, transform.position.z);
        }
        else if (Camera.main.WorldToScreenPoint(transform.position).x > Screen.width + MARGEN)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(-MARGEN / 2, 0, 0));
            plane.Raycast(ray, out distancia);
            transform.position = new Vector3(ray.GetPoint(distancia).x, 0, transform.position.z);
        }

        if (Camera.main.WorldToScreenPoint(transform.position).y < 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(0, Screen.height, 0));
            plane.Raycast(ray, out distancia);
            transform.position = new Vector3(transform.position.x, 0, ray.GetPoint(distancia).z);
        }
        else if (Camera.main.WorldToScreenPoint(transform.position).y > Screen.height)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(0, 0, 0));
            plane.Raycast(ray, out distancia);
            transform.position = new Vector3(transform.position.x, 0, ray.GetPoint(distancia).z);
        }
    }
}
