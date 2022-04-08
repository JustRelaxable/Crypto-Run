using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float DeltaTouch { get => deltaTouch; }
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
            deltaTouch += (Input.mousePosition - touchPosition).x*Time.deltaTime/10;
            touchPosition = Input.mousePosition;
        }
        deltaTouch = Mathf.Clamp(deltaTouch, -1f, 1f);
        //deltaTouch = Mathf.Lerp(deltaTouch, 0, Time.deltaTime);
        //Debug.Log(deltaTouch);
    }
}
