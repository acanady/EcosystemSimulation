using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SensoryRadius : MonoBehaviour
{
    public SphereCollider sensoryRadiusCol;
    public int sensoryRadius;

    public int EntitySensoryRadius { get { return sensoryRadius; } set { sensoryRadius = value; } }
    

    // Update is called once per frame
    void Update()
    {
        if (sensoryRadiusCol.radius != sensoryRadius)
            sensoryRadiusCol.radius = sensoryRadius;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, sensoryRadius);
    }

}