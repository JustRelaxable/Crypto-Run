using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrue : Door
{
    protected override void OnTriggerPlayer(Collider playerCollider)
    {
        base.OnTriggerPlayer(playerCollider);
        Debug.Log("True");
    }
}
