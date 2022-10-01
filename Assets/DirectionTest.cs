using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTest : MonoBehaviour
{
    Collider[] hitColliders;
    public float SphereRadius;
    public Vector3 fleeDirection;
    public Vector3 fleeDirectionBefore;
    public int predatorsInRadius;
    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics.OverlapSphere(this.transform.position, SphereRadius);
        fleeDirection = Vector3.zero;
        fleeDirectionBefore = fleeDirection;
        predatorsInRadius = 0;
        foreach(var hitCollider in hitColliders)
        { 
            if (hitCollider.gameObject.tag.Equals("Predator"))
            {
                Debug.Log("hit something: " + hitCollider.gameObject.name);
                predatorsInRadius++;
                //Debug.Log("predator Found");
                fleeDirection += hitCollider.gameObject.transform.position;
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(new Vector3(0,0,0), fleeDirection*-1);
    }
}
