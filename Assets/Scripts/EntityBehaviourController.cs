using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EntityBehaviourController : MonoBehaviour
{
    [SerializeField]
    protected bool flee;
    
    [SerializeField]
    protected bool chase;

    protected NavMeshAgent agent;
    public EcosystemManager Ecomanager;
    
    public bool Flee { get { return flee; } set { flee = value; } }
    
    public bool Chase { get { return chase; } set { chase = value; } }

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    public void WaterSeen(GameObject water)
    {
        throw new NotImplementedException();
    }

    protected void Eat(GameObject food)
    {
        //Debug.Log(Vector3.Distance(this.transform.position, food.transform.position));
        if (Vector3.Distance(this.transform.position, food.transform.position) < 2f)
        {
            Ecomanager.prey.Remove(food);
            chase = false;
            GameObject.Destroy(food);
        }
    }
}
