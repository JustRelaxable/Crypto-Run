using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
        transform.position = new Vector3(characterController.DeltaTouch, transform.position.y,transform.position.z);
    }
}
