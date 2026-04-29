using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointControl : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;
    float m_NormalSpeed;

    void Start ()
    {
        m_NormalSpeed = navMeshAgent.speed;
        navMeshAgent.SetDestination (waypoints[0].position);
    }

    void Update ()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);
        }
    }

    public void SlowDown (float duration, float slowPercent)
    {
        StartCoroutine (SlowCoroutine (duration, slowPercent));
    }

    IEnumerator SlowCoroutine (float duration, float slowPercent)
    {
        navMeshAgent.speed = m_NormalSpeed * (1f - slowPercent);
        yield return new WaitForSeconds (duration);
        navMeshAgent.speed = m_NormalSpeed;
    }
}