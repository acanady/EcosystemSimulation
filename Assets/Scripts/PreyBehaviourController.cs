using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehaviourController : EntityBehaviourController
{

    [SerializeField]
    private Vector3 fleeDirection;

    public List<GameObject> predators;

    void Update()
    {
        if (flee && predators.Count > 0)
        {
            fleeDirection = Vector3.zero;
            //agent.ResetPath();
            foreach (var predator in predators)
            {
                fleeDirection += (predator.transform.position - this.transform.position).normalized;
            }
            agent.destination = -1 * fleeDirection + this.transform.position;
        }
    }

    public void FruitSeen(GameObject fruit)
    {
        throw new NotImplementedException();

    }

    public void PredatorSeen(List<GameObject> _predators)
    {
        flee = true;
        predators = _predators;
    }

    public void PredatorLost() { flee = false; predators = null; agent.ResetPath(); }
}
