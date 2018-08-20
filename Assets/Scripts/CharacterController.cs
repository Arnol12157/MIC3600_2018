using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent agent;
    public Boolean bGoToTarget;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bGoToTarget)
        {
            agent.SetDestination(target);
            bGoToTarget = false;
        }
    }

    private void OnMouseDown()
    {
        
        bGoToTarget = true;
    }
}