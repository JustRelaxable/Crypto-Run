using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPositionFix : MonoBehaviour
{
    Vector3 globalPosition;
    private void Awake()
    {
        globalPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(globalPosition.x, transform.position.y, transform.position.z);
    }
}
