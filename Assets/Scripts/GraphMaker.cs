using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphMaker : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        float intervalX = (maxX - minX)/lineRenderer.positionCount;
        Vector3[] positionArray = new Vector3[15];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 position = new Vector3(i * intervalX + minX, 0, 0);
            positionArray[i].x = position.x;
        }
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            positionArray[i].y = Random.Range(minY,maxY);
            positionArray[i].z = 0;
        }
        lineRenderer.SetPositions(positionArray);
    }
}
