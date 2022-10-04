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

    [SerializeField]
    protected double hunger = 100;

    [SerializeField]
    protected float lifespan = 1000;

    [SerializeField]
    protected float walkingSpeed = 6;

    [SerializeField]
    protected float runningSpeed;

    [SerializeField]
    protected int litterCount;

    [SerializeField]
    protected bool eating;

    protected NavMeshAgent agent;
    public EcosystemManager Ecomanager;
    
    public bool Flee { get { return flee; } set { flee = value; } }
    
    public bool Chase { get { return chase; } set { chase = value; } }

    public double Hunger => hunger;

    public bool Eating => eating;

    public int LitterCount { get { return litterCount; } set { litterCount = value; } }

    private void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        agent.speed = walkingSpeed;
        Ecomanager = GameObject.FindGameObjectWithTag("EcoManager").GetComponent<EcosystemManager>();
    }

    public virtual void RemoveEntityFromManager()
    {
        throw new NotImplementedException();
    }

    public virtual void AddEntityToManager(GameObject entity)
    {
        throw new NotImplementedException();
    }

    public void DeathIsInevitable()
    {
        if (lifespan > 0) lifespan = lifespan - Time.fixedDeltaTime;
        else { RemoveEntityFromManager(); Destroy(this.gameObject); }
    }

}

