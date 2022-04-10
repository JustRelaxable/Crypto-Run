using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    public float DeltaTouch { get => deltaTouch; }
    public float sensitivity = 0.2f;
    private float deltaTouch = 0f;
    private Vector3 touchPosition;
    private Vector3 initialTouchPosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Input.mousePosition;
            touchPosition = initialTouchPosition;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaTouch += (Input.mousePosition - touchPosition).x*Time.deltaTime * sensitivity;
            touchPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //deltaTouch = 0;
        }
        deltaTouch = Mathf.Clamp(deltaTouch, -1f, 1f);
    }
}
