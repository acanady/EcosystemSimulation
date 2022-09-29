using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SphereCollider))]
public class SensoryRadius : MonoBehaviour
{
    public SphereCollider sensoryRadiusCol;
    public int sensoryRadius;
    public EntityBehaviourController entityBehaviour;
    public int predatorsInRadius = 0;

    // Update is called once per frame
    void Update()
    {
        if (sensoryRadiusCol.radius != sensoryRadius)
            sensoryRadiusCol.radius = sensoryRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, sensoryRadiusCol.radius);
    }


    private void OnTriggerEnter (Collider other)
    {
        
        if(this.gameObject.tag.Equals("PreySensor"))
        {
            if (other.gameObject.tag.Equals("Predator")) 
            {
                entityBehaviour.PredatorSeen(other.gameObject);
                predatorsInRadius++;
            }
        }
        else if (this.gameObject.tag.Equals("PredatorSensor"))
        {
            if (other.gameObject.tag.Equals("Prey")) entityBehaviour.PreySeen(other.gameObject);
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag.Equals("PreySensor"))
        {
            predatorsInRadius--;
            if (predatorsInRadius < 1) entityBehaviour.PredatorLost();
        }
        else if (this.gameObject.tag.Equals("Predator")) entityBehaviour.PreyLost();
            
    }
}