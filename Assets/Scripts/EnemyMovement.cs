using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2.0f; 

    private Vector3 pointA;
    private Vector3 pointB;
    private Vector3 target;

    void Start()
    {
        // Buscar los puntos hijos de "Waypoints"
        Transform waypoints = transform.Find("Waypoints");
        if (waypoints != null)
        {
            pointA = waypoints.Find("PointA").position;
            pointB = waypoints.Find("PointB").position;
        }
        else
        {
            Debug.LogError("⚠️ No se encontraron waypoints en " + gameObject.name);
        }

        target = pointB;
    }

    void Update()
    {
        // Mueve el enemigo entre PointA y PointB
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
