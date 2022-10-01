using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorRadius : SensoryRadius
{
    public PredatorBehaviourController entityBehaviour;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Prey") && !entityBehaviour.Chase) entityBehaviour.PreySeen(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag.Equals("Prey"))
            entityBehaviour.PreyLost();
    }
}
