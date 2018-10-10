using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualReward : MonoBehaviour
{
    public GameObject[] numbers;
    public GameObject demolitionParticles;
    public float delayDemolition;
    private float auxDelay;
    public bool bInitDemolition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bInitDemolition)
        {
            if (delayDemolition > 0)
            {
                delayDemolition -= Time.deltaTime;
            }

            if (delayDemolition <= 0)
            {
                hideDemolitionParticles();
            }
        }
    }

    public GameObject GetNumberAnimation(int index)
    {
        return numbers[index];
    }

    public void showDemolitionParticles()
    {
        if (!bInitDemolition)
        {
            bInitDemolition = true;
            auxDelay = delayDemolition;
            demolitionParticles.SetActive(true);
        }
    }

    public void hideDemolitionParticles()
    {
        bInitDemolition = false;
        delayDemolition = auxDelay;
        demolitionParticles.SetActive(false);
    }
}