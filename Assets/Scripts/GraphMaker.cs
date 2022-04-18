using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GraphMaker : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] Image iconImage;

    [SerializeField] Sprite up;
    [SerializeField] Sprite down;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawGraph(Color color)
    {
        StartCoroutine(DrawGraphCoroutine(GeneratePositions(color)));
    }

    public Vector3[] GeneratePositions(Color color)
    {
        if (color == Color.green)
            iconImage.sprite = up;
        else
            iconImage.sprite = down;

        lineRenderer.endColor = color;
        lineRenderer.startColor = color;
        float intervalX = (maxX - minX) / lineRenderer.positionCount;
        Vector3[] positionArray = new Vector3[15];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 position = new Vector3(i * intervalX + minX, 0, 0);
            positionArray[i].x = position.x;
        }
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            positionArray[i].y = Random.Range(minY, maxY);
            positionArray[i].z = 0;
        }

        return positionArray;
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
