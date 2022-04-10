using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStackingPoint : MonoBehaviour
{
    public Vector3 coinOffset;
    public Vector3 coinRotation;
    List<MeshRenderer> coinsMeshRenderers = new List<MeshRenderer>();

    public Vector3 GetNextStackingPosition()
    {
        return transform.localPosition+(coinsMeshRenderers.Count * coinOffset);
    }

    public Vector3 GetStackingRotation()
    {
        return coinRotation;
    }

    public void AddCoinToStack(MeshRenderer meshRenderer)
    {
        coinsMeshRenderers.Add(meshRenderer);
    }
}
