using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterTriggerController : MonoBehaviour
{
    public CharacterStackingPoint characterStackingPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.enabled = false;
            Vector3 stackingPosition = characterStackingPoint.GetNextStackingPosition();
            Vector3 stackingRotation = characterStackingPoint.GetStackingRotation();
            characterStackingPoint.AddCoinToStack(other.GetComponent<MeshRenderer>());
            other.transform.parent = characterStackingPoint.transform;
            other.transform.DOLocalMove(stackingPosition, 1f);
            other.transform.DOLocalRotate(stackingRotation, 1f);
        }
    }
}
