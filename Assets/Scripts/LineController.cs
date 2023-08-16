using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LayerMask circleLayerMask;

    private bool isDrawing = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
            CheckIntersections();
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 0;
    }

    private void ContinueDrawing()
    {
        if (isDrawing)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
        }
    }

    private void StopDrawing()
    {
        isDrawing = false;
    }

    private void CheckIntersections()
    {
        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            Vector3 startPoint = lineRenderer.GetPosition(i);
            Vector3 endPoint = lineRenderer.GetPosition(i + 1);

            RaycastHit2D[] hits = Physics2D.CircleCastAll(startPoint, 0.1f, endPoint - startPoint, Vector3.Distance(startPoint, endPoint), circleLayerMask);

            foreach (RaycastHit2D hit in hits)
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}

