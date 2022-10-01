using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VectorVisualizer : MonoBehaviour
{
    public LineRenderer LeftPoint;
    public LineRenderer RightPoint;
    private LineRenderer arrow;
    public float ArrowPointLength = 0f;
    public float ArrowLength = 1f;
    public float arrowPointAngle;

    private void Start()
    {
        arrow = this.gameObject.GetComponent<LineRenderer>();
    }

    public void RenderVector()
    {
        arrowSetPosition();

        Vector3 endPoint = arrow.GetPosition(0);
        Vector3 scale = this.transform.root.transform.localScale;
        endPoint = new Vector3(endPoint.x * scale.x, endPoint.y * scale.y, 0f);

        LeftPoint.transform.position = this.transform.position + endPoint;
        RotateLine(ref LeftPoint, arrow.GetPosition(0) - arrow.GetPosition(1), arrowPointAngle);

        RightPoint.transform.position = this.transform.position + endPoint;
        RotateLine(ref RightPoint, arrow.GetPosition(0) - arrow.GetPosition(1), -1 * arrowPointAngle);
    }

    private void RotateLine(ref LineRenderer line, Vector2 direction, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 rotatedVec = q * direction;
        rotatedVec.Normalize();
        rotatedVec *= ArrowPointLength;

        line.SetPosition(1, rotatedVec);
    }

    private void arrowSetPosition()
    {
        Vector3 fleeDirection = Vector3.zero;
        if (NodeManager.nodes.Count > 0)

            foreach(var node in NodeManager.nodes)
            {
                fleeDirection += node.transform.position.normalized;
            }
            arrow.SetPosition(0, fleeDirection.normalized * ArrowLength *-1);
    }

    // Update is called once per frame
    void Update()
    {
        RenderVector();
    }
}
