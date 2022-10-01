using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotate : MonoBehaviour
{
    public int speed;
    //public int rotationAmount;
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime*speed);
    }
}
