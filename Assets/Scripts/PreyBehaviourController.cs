using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyBehaviourController : EntityBehaviourController
{

    [SerializeField]
    private Vector3 fleeDirection;
    public List<GameObject> predators;
    [SerializeField]
    private GameObject selectedFruit;



    //private bool drinking;

    void Update()
    {
        if (flee && predators.Count > 0)
        {
            fleeDirection = Vector3.zero;
            foreach (var predator in predators)
            {
                fleeDirection += (predator.transform.position - this.transform.position).normalized;
            }
            agent.destination = -1 * fleeDirection + this.transform.position;
        }

        if(selectedFruit!= null)
        {
            if (Ecomanager.berriesEdibility[selectedFruit].FoodEdible)
            {
                if (Vector3.Distance(this.transform.position, selectedFruit.transform.position) < 0.5f)
                {
                    FruitConsumed();
                }
            }
            else
            {
                eating = false;
                selectedFruit = null;
            }
        }

        DeathIsInevitable();

        if (agent.velocity.magnitude > 0.2) { hunger -= (0.5 * walkingSpeed) * Time.fixedDeltaTime; }
        else { hunger -= (0.5 * Time.fixedDeltaTime); }

        if (hunger < 0)
        {
            RemoveEntityFromManager();
            Destroy(this.gameObject);
        }
    }
   
    public void FruitSeen(GameObject fruit)
    {
        if(hunger < 75 && !flee && Ecomanager.berriesEdibility[fruit].FoodEdible && !eating)
        {
            eating = true;
            //agent.ResetPath();
            agent.destination = fruit.gameObject.transform.position;
            selectedFruit = fruit;
        }

    }

    public void FruitConsumed()
    {
        if (Ecomanager.berriesEdibility[selectedFruit].FoodEdible)
        {
            hunger = (hunger + 25) % 100;
            Ecomanager.berriesEdibility[selectedFruit].Eaten();
            selectedFruit = null;
            eating = false;
        }
        eating = false;
        selectedFruit = null;
    }

    public void PredatorSeen(List<GameObject> _predators)
    {
        flee = true;
        predators = _predators;
    }
    public void PredatorLost() { flee = false; predators = null; agent.ResetPath(); }

    public override void RemoveEntityFromManager()
    {
        Ecomanager.prey.Remove(this.gameObject);
        Ecomanager.TotalPreyDeath++;
    }

    public override void AddEntityToManager(GameObject entity)
    {
        Ecomanager.prey.Add(entity);
    }
}
