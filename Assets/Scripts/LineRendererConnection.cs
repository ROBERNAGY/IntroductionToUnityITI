using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererConnection : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.positionCount = objectList.Count;
        for(int i = 0; i < objectList.Count; i++)
        {
            lineRenderer.SetPosition(i, objectList[i].transform.position);
        }
    }
}
