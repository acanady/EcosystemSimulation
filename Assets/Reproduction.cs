using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    public float reproductionTime = 100f;
    [SerializeField]
    private float remainingTime;
    public EcosystemManager ecoManager;
    public EntityBehaviourController entityBehaviour;
    public MutationController mutationController;

    private void Start()
    {
        ecoManager = GameObject.FindGameObjectWithTag("EcoManager").GetComponent<EcosystemManager>();
        remainingTime = reproductionTime;
    }
    private void Update()
    {
        remainingTime = remainingTime - Time.fixedDeltaTime;

        if(remainingTime < .5f && entityBehaviour.Hunger > 75)
        {
            remainingTime = reproductionTime;

            for(int i = 0; i < entityBehaviour.LitterCount; i++)
            {
                if (this.gameObject.tag.Equals("Prey"))
                {
                    GameObject child = Instantiate(ecoManager.preyPrefab, this.transform.position, Quaternion.identity, ecoManager.preyParentObject.transform);
                    inheritGenes(child, this.transform.gameObject);
                    AttempMutations(child);
                    ecoManager.SensoryRadiusOfEntities.Add(child,child.GetComponent<SensoryReference>().SensoryRadiusObj);
                    entityBehaviour.AddEntityToManager(child);
                    ecoManager.TotalPrey++;
                    
                }
                if (this.gameObject.tag.Equals("Predator"))
                {
                    GameObject child = Instantiate(ecoManager.predatorPrefab, this.transform.position, Quaternion.identity, ecoManager.predatorParentObject.transform);
                    mutationController.AttemptSensoryMutation(child);
                    ecoManager.SensoryRadiusOfEntities.Add(child, child.GetComponent<SensoryReference>().SensoryRadiusObj);
                    entityBehaviour.AddEntityToManager(child);
                    ecoManager.TotalPredators++;
                }
            }

            
  
        }
    }

    private void AttempMutations(GameObject child)
    {
        mutationController.AttemptSensoryMutation(child);
        //mutationController.AttempSpeedMutation(child);
        //mutationController.AttempLitterCountMutation(child);
        //mutationController.AttemptHungerMutation(child);
    }

    private void inheritGenes(GameObject child, GameObject parent)
    {
        //inherit sensory radius gene
        child.GetComponent<SensoryReference>().SensoryRadiusObj.EntitySensoryRadius = ecoManager.SensoryRadiusOfEntities[parent].EntitySensoryRadius;
    }
}
