using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private GameObject target;
    private NavMeshAgent nma;

    private void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        nma.SetDestination(target.transform.position);
    }
}
