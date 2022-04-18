using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFalse : Door
{
    protected override void OnTriggerPlayer(Collider playerCollider)
    {
        base.OnTriggerPlayer(playerCollider);
        Debug.Log("False");
        CharacterStackingPoint characterStackingPoint = playerCollider.GetComponentInChildren<CharacterStackingPoint>();
        characterStackingPoint.DestroyCoins(Random.RandomRange(4,10));
    }
}
