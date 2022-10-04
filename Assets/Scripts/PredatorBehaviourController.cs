using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehaviourController : EntityBehaviourController
{
    [SerializeField]
    private GameObject prey;

    void Update()
    {
        if (chase && prey != null)
        {
            agent.destination = prey.transform.position;
            EatPrey(prey);
        }

        if (chase && prey == null) chase = false;

        DeathIsInevitable();
        if (agent.velocity.magnitude > 0.2) { hunger -= (0.5 * walkingSpeed) * Time.fixedDeltaTime; }
        else { hunger -= (0.5 * Time.fixedDeltaTime); }

        if (hunger < 0)
        {
            RemoveEntityFromManager();
            Destroy(this.gameObject);
        }

    }

    public void PreyLost() { chase = false; prey = null; }

    public void PreySeen(GameObject _prey)
    {
        chase = true;
        prey = _prey;
    }

    public void EatPrey(GameObject food)
    {
        //Debug.Log(Vector3.Distance(this.transform.position, food.transform.position));
        if (Vector3.Distance(this.transform.position, food.transform.position) < 2f)
        {
            Ecomanager.prey.Remove(food);
            chase = false;
            GameObject.Destroy(food);
            hunger += 50;
        }
    }

    public override void RemoveEntityFromManager()
    {
        Ecomanager.predators.Remove(this.gameObject);
        Ecomanager.TotalPredatorDeath++;
    }

    public override void AddEntityToManager(GameObject entity)
    {
        Ecomanager.predators.Add(entity);
    }

}
