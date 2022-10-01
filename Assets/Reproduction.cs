using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    public float reproductionTestTimer = 10f;
    public EcosystemManager ecoManager;

    private void Update()
    {
        reproductionTestTimer = reproductionTestTimer - Time.deltaTime;

        if(reproductionTestTimer < .5f)
        {
            reproductionTestTimer = 10f;
            if (this.gameObject.tag.Equals("Prey")) {
                GameObject child = Instantiate(ecoManager.preyPrefab, this.transform.position, Quaternion.identity, ecoManager.preyParentObject.transform);
                ecoManager.prey.Add(child);
            }

            
        }
    }
}
