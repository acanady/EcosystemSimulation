using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreator : MonoBehaviour
{
    public GameObject entityPrefab;
    private Vector3 offset = new Vector3(0, 0, 205);

    private void Update()
    {
        SpawnNode();
       
    }
    private void SpawnNode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, new Vector2(0, 0), 0.01f);

            if (hits.Length == 0)
            {
                GameObject node = Instantiate(entityPrefab, mousePosition, Quaternion.identity);
                node.transform.parent = this.gameObject.transform;
                NodeManager.nodes.Add(node);
            }
        }
    }
}
