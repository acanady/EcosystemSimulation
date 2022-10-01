using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRemove : MonoBehaviour
{
   
    private bool wasHoveredOver;

    // Update is called once per frame
    void Update()
    {
        MoveNode();

    }



    private void OnMouseOver()
    {
        wasHoveredOver = true;
        if (Input.GetKeyDown(KeyCode.D))
        {
            NodeManager.nodes.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void MoveNode()
    {
        if (Input.GetMouseButton(0) && wasHoveredOver)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = mousePosition;
        }
        else
        {
            wasHoveredOver = false;
        }
    }
}
