using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorBehaviourController : EntityBehaviourController
{

    public GameObject prey;

    void Update()
    {
        if (chase && prey != null)
        {
            agent.destination = prey.transform.position;
            Eat(prey);
        }

        if (chase && prey == null) chase = false;
    }

    public void PreyLost() { chase = false; prey = null; }

    public void PreySeen(GameObject _prey)
    {
        chase = true;
        prey = _prey;
    }

}
