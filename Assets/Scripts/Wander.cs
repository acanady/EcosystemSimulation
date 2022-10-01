using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Wander : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 movePosition;
    public EntityBehaviourController entityBehaviour;
    public bool calculatingPath;
    public float lowerBound;
    public float upperBound;
  
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        movePosition = agent.transform.position;
        calculatingPath = agent.pathPending;
    }

    // Update is called once per frame
    void Update()
    {
        calculatingPath = agent.pathPending;
        
        if (agent.velocity.magnitude < 0.15f && !entityBehaviour.Flee && !entityBehaviour.Chase && !agent.pathPending)
        {
            //Debug.Log("setting mouse position");
            movePosition = RandomLocNearMe(Random.Range(lowerBound, upperBound));
            agent.SetDestination(movePosition);
        }   
    }

    public Vector3 RandomLocNearMe(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection + this.transform.position, out navHit, radius, -1);
        return navHit.position;
    }


  
}
