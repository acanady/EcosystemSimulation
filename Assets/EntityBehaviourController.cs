using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EntityBehaviourController : MonoBehaviour
{
    [SerializeField]
    private bool flee;
    
    [SerializeField]
    private bool chase;
    
    private NavMeshAgent agent;
    public EcosystemManager Ecomanager;

    
    public bool Flee { get { return flee; } set { flee = value; } }
    
    public bool Chase { get { return chase; } set { chase = value; } }

    public GameObject predator;
    public GameObject prey;

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (flee && predator!=null)
        {
            agent.destination = transform.position + (this.transform.position - predator.transform.position);
        }

        if (chase && prey!=null)
        {
            agent.destination = prey.transform.position;
            Eat(prey);
        }

        if (chase && prey == null) chase = false;
    }

    public void PredatorLost() { flee = false; predator = null; }
    public void PreyLost() { chase = false; prey = null; }

    public void PredatorSeen(GameObject _predator) 
    {
        flee = true;
        predator = _predator;
    }
    public void PreySeen(GameObject _prey) 
    {
        chase = true;
        prey = _prey;
    }

    public void FruitSeen(GameObject fruit)
    {
        throw new NotImplementedException();

    }

    public void WaterSeen(GameObject water)
    {
        throw new NotImplementedException();
    }

    private void Eat(GameObject food)
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
