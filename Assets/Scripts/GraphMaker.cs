using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        //lineRenderer.SetPositions(positionArray);
        /*
        for (int i = 0; i < positionArray.Length; i++)
        {
            lineRenderer.SetPosition(i, positionArray[i]);
        }
        */
        StartCoroutine(DrawGraphCoroutine(positionArray));
    }

    IEnumerator DrawGraphCoroutine(Vector3[] points)
    {
        for (int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i, points[0]);
        }
        float duration = 0.1f;
        float time = 0f;

        for (int i = 1; i < points.Length; i++)
        {
            while (time<duration)
            {
                for (int j = i; j < points.Length; j++)
                {
                    lineRenderer.SetPosition(j, Vector3.Lerp(points[i - 1], points[i], (time / duration)));
                }
                time += Time.deltaTime;
                yield return null;
            }
            time = 0f;
        }
    }
}
