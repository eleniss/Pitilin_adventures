using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 2;
    public Transform[] WayPoints;
    private int currentWaypointIndex;
    public bool Move2D;
    public float MinDistance = 0.01f;
    Transform CurrentWaypoint => WayPoints[currentWaypointIndex];
    void Start()
    {
        
    }

    void Update()
    {
        if (CloseToWaypoint())
        {
            ChangeWaypoint();
        }
        Move();
    }

    private bool CloseToWaypoint()
    {
        return Vector3.Distance(transform.position, CurrentWaypoint.position) < MinDistance;
    }

    private void ChangeWaypoint()
    {
        currentWaypointIndex++;
        currentWaypointIndex = currentWaypointIndex % WayPoints.Length;
    }
    private void Move()
    {
        Vector3 target = CurrentWaypoint.position;
        target.y = transform.position.y;
        transform.LookAt(CurrentWaypoint);
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
