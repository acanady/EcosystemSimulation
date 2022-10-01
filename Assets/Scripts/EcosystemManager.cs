using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcosystemManager : MonoBehaviour
{
    public GameObject preyPrefab;
    public GameObject predatorPrefab;

    public List<GameObject> prey;
    public List<GameObject> predators;

    public int preyCount;
    public int predatorCount;

    public GameObject preyParentObject;
    public GameObject predatorParentObject;


    private void Start()
    {
        preyParentObject = GameObject.FindGameObjectWithTag("PreyParent");
        predatorParentObject = GameObject.FindGameObjectWithTag("PredatorParent");
        SpawnEntities();
    }

    public void SpawnEntities()
    {
        for (int i = 0; i < predatorCount; i++)
        {
            predators.Add(Instantiate(predatorPrefab, new Vector3(Random.Range(-100f, 100f), predatorPrefab.transform.position.y, Random.Range(20f, 100f)), Quaternion.identity, predatorParentObject.transform));

        }

        for (int i = 0; i < preyCount; i++)
        {
            prey.Add(Instantiate(preyPrefab, new Vector3(Random.Range(-100f, 100f), preyPrefab.transform.position.y, Random.Range(-100f, -20f)), Quaternion.identity, preyParentObject.transform));
        }
    }
}
