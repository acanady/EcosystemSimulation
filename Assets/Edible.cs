using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour
{
    
    public float GrowthTime;

    [SerializeField]
    private bool foodEdible = true;
    [SerializeField]
    private float remainingTime;
    private MeshRenderer foodMesh;

    public bool FoodEdible => foodEdible;

    void Start()
    {
        foodMesh = gameObject.GetComponent<MeshRenderer>();
        remainingTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime = remainingTime - Time.fixedDeltaTime;
        }
        else
        {
            remainingTime = 0;
            foodEdible = true;
            foodMesh.enabled = true;
        }
    }

    public void Eaten()
    {
        foodEdible = false;
        remainingTime = GrowthTime;
        foodMesh.enabled = false;
    }
}
