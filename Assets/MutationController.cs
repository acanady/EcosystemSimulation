using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using System;

public class MutationController : MonoBehaviour
{
    public float mutationAmount;
    public float mutationChance;

    static readonly System.Random rng = new System.Random();


    public int TryMutateGene(int gene)
    {
        int _gene = gene;
        if (rng.NextDouble() < mutationChance)
        {
            Debug.Log("Gene getting mutated");
            double mutationval = RandomGaussian() * mutationAmount;
            if (_gene < (_gene + mutationval)) return ++_gene;
            else { return --_gene; }
        }
        return _gene;
    }

    /*
    public float TryMutateGene(float gene)
    {
        if (rng.NextDouble() < mutationChance)
        {
            double mutationval = RandomGaussian() * mutationAmount;
            gene += (float)mutationval;
        }
        return gene;
    }*/

    static float RandomGaussian()
    {
        double u1 = 1 - rng.NextDouble();
        double u2 = 1 - rng.NextDouble();
        double randStdNormal = Sqrt(-2 * Log(u1)) * Sin(2 * Mathf.PI * u2);
        //Debug.Log("randomGaussian generated: " + randStdNormal);
        return (float)randStdNormal;
        
    }

    //Mutates the sensory radius value of a given entity
   public void AttemptSensoryMutation(GameObject entity)
    {
        SensoryRadius sr = entity.GetComponent<SensoryReference>().SensoryRadiusObj;
        int mutatedGeneNewVal = TryMutateGene(sr.EntitySensoryRadius);
        sr.EntitySensoryRadius = mutatedGeneNewVal;
        Debug.Log("NEW SENSORY RADIUS: " + mutatedGeneNewVal);
    }

    
    
}
