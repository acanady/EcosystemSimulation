using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyRadius : SensoryRadius
{
    private Collider[] hitColliders;
    
    public int predatorsInRadius = 0;
    public List<GameObject> predators;
    public PreyBehaviourController entityBehaviour;

    //Every Frame we send out a sphere centered on the prey, if it collides with an object
    //with the predator tag then it adds it to the list and sends it to the behaviour controller
    private void Update()
    {
        predators.Clear();
        hitColliders = Physics.OverlapSphere(this.transform.position, sensoryRadius);
        predatorsInRadius = 0;
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag.Equals("Predator"))
            {
                //Debug.Log("hit something: " + hitCollider.gameObject.name);
                predatorsInRadius++;
                predators.Add(hitCollider.gameObject);
            }

            if (hitCollider.gameObject.tag.Equals("Berry"))
            {
                entityBehaviour.FruitSeen(hitCollider.gameObject);
            }
        }

        if (predatorsInRadius > 0) { entityBehaviour.PredatorSeen(predators); }
        //If there are no predators in the vicinity and we are still fleeing, stop
        else if (entityBehaviour.Flee) entityBehaviour.PredatorLost();
    }
    
}
