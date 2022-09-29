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
  
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        movePosition = agent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.velocity.magnitude < 0.15 && !entityBehaviour.Flee && !entityBehaviour.Chase)
        {
            //Debug.Log("setting mouse position");
            movePosition = new Vector3(Random.Range(-100f, 100f), agent.transform.position.y, Random.Range(-100f, 100f));
        }

        if(!entityBehaviour.Flee && !entityBehaviour.Chase)
            agent.destination = movePosition;
        
    }
  
}
