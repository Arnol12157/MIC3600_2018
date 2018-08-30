using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public GameObject[] crystalsTargets;
    public GameObject deposit;
    public Boolean bGoToTarget;
    private int index;
    private GameObject currentCrystalTarget;
    public Boolean bCrystalRecolected;
    
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        setRandomCrystalTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (bGoToTarget)
        {
            currentCrystalTarget = crystalsTargets[index];
            agent.SetDestination(currentCrystalTarget.transform.position);
            bGoToTarget = false;
        }

        if (currentCrystalTarget!= null && Vector3.Distance(currentCrystalTarget.transform.position, gameObject.transform.position) <= 2f)
        {
            bCrystalRecolected = true;
        }

        if (bCrystalRecolected)
        {
            agent.SetDestination(deposit.transform.position);
            bCrystalRecolected = false;
        }
        
        if (Vector3.Distance(deposit.transform.position, gameObject.transform.position) <= 2f)
        {
            bGoToTarget = true;
            setRandomCrystalTarget();
        }
    }

    private void OnMouseDown()
    {
        bGoToTarget = true;
        setRandomCrystalTarget();
    }

    void setRandomCrystalTarget()
    {
        index = UnityEngine.Random.Range(0, crystalsTargets.Length);
    }
}