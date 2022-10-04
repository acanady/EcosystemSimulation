using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemManager : MonoBehaviour
{
    public GameObject preyPrefab;
    public GameObject predatorPrefab;
    public GameObject berryPrefab;

    public List<GameObject> prey;
    public List<GameObject> predators;
    public List<GameObject> berries;

    public int preyCount;
    public int predatorCount;
    public int berryCount;

    public int TotalPrey;
    public int TotalPredators;
    public int TotalPreyDeath;
    public int TotalPredatorDeath;

    public int SimulationSpeed;


    [Header("GameObjects that hold predator and prey instances")]
    //GameObject where prey instances are stored
    public GameObject preyParentObject;

    //GameObject where predator instances are stored
    public GameObject predatorParentObject;

    public GameObject Ground;

    public Dictionary<GameObject, Edible> berriesEdibility;
    public Dictionary<GameObject, SensoryRadius> SensoryRadiusOfEntities;
    
    private void Start()
    {
        berriesEdibility = new Dictionary<GameObject, Edible>();
        SensoryRadiusOfEntities = new Dictionary<GameObject, SensoryRadius>();
        SpawnEntities();
        TotalPrey = preyCount;
        TotalPredators = predatorCount;
    }

    private void Update()
    {
        Time.timeScale = SimulationSpeed;
    }

    public void SpawnEntities()
    {
        //Spawns predator and prey on opposite sides of the watering hole.
        for (int i = 0; i < predatorCount; i++)
        {
            GameObject instantiatedObject;
            instantiatedObject = Instantiate(predatorPrefab, new Vector3(Random.Range(-100f, 100f), predatorPrefab.transform.position.y, Random.Range(20f, 100f)), Quaternion.identity, predatorParentObject.transform);
            //SensoryRadiusOfEntities.Add(instantiatedObject, instantiatedObject.GetComponent<SensoryReference>().SensoryRadiusObj);
            predators.Add(instantiatedObject);
        }

        for (int i = 0; i < preyCount; i++)
        {
            GameObject instantiatedObject;
            instantiatedObject = Instantiate(preyPrefab, new Vector3(Random.Range(-100f, 100f), preyPrefab.transform.position.y, Random.Range(-100f, -20f)), Quaternion.identity, preyParentObject.transform);
            SensoryRadiusOfEntities.Add(instantiatedObject, instantiatedObject.GetComponent<SensoryReference>().SensoryRadiusObj);
            prey.Add(instantiatedObject);
        }

        for (int i = 0; i < berryCount; i++)
        {
            GameObject instantiatedBerry;
            if (i % 2 == 0)
            {
                instantiatedBerry = Instantiate(berryPrefab, new Vector3(Random.Range(-100f, 100f), berryPrefab.transform.position.y, Random.Range(20f, 100f)), Quaternion.identity, Ground.transform);
                berriesEdibility.Add(instantiatedBerry, instantiatedBerry.GetComponent<Edible>());
            }
            else
            {
                instantiatedBerry = Instantiate(berryPrefab, new Vector3(Random.Range(-100f, 100f), berryPrefab.transform.position.y, Random.Range(-100f, -20f)), Quaternion.identity, Ground.transform);
                berriesEdibility.Add(instantiatedBerry, instantiatedBerry.GetComponent<Edible>());
            }
        }

        Debug.Log("Berry dictionary size: " + berriesEdibility.Count);
    }
}
