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
    public Boolean bToDeposit;
    public Animator anim_ctrl;
    
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //bGoToTarget = true;
        setRandomCrystalTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (bGoToTarget)
        {
            setRandomCrystalTarget();
            currentCrystalTarget = crystalsTargets[index];
            agent.SetDestination(currentCrystalTarget.transform.position);
            bGoToTarget = false;
            bToDeposit = false;
            anim_ctrl.ResetTrigger("toIdle");
            anim_ctrl.SetTrigger("toRun");
        }

        if (currentCrystalTarget!= null && Vector3.Distance(currentCrystalTarget.transform.position, gameObject.transform.position) <= 2f)
        {
            bCrystalRecolected = true;
        }

        if (bCrystalRecolected)
        {
            bToDeposit = true;
            agent.SetDestination(deposit.transform.position);
            bCrystalRecolected = false;
        }
        
        if (Vector3.Distance(deposit.transform.position, gameObject.transform.position) <= 2f && bToDeposit)
        {
            anim_ctrl.SetTrigger("toIdle");
            anim_ctrl.ResetTrigger("toRun");
        }
    }

    private void OnMouseDown()
    {
        GameObject.Find("CameraController").GetComponent<CameraController>().EnableWellcomeCinematicCamera();
        anim_ctrl.SetTrigger("toIdle");
        GameObject.Find("LevelController").GetComponent<LevelController>().gameState =
            LevelController.GameState.InitGame;
        //bGoToTarget = true;
        //setRandomCrystalTarget();
    }

    void setRandomCrystalTarget()
    {
        index = UnityEngine.Random.Range(0, crystalsTargets.Length);
    }
}