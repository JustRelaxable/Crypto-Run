using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform character;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - character.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 t = character.transform.position;
        t.x = 0;
        transform.position = t + offset;
    }
}
