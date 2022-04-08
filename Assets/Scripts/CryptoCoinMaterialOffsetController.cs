using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CryptoCoinMaterialOffsetController : MonoBehaviour
{
    [SerializeField]
    [Range(0,43)]
    int cryptoIndex;

    [SerializeField] MeshRenderer meshRenderer;
    

    private void Update()
    {
        UpdateCoinUV();
    }

    private void UpdateCoinUV()
    {
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0.12f*(cryptoIndex%8),-0.16f*(cryptoIndex/8)));
    }
}
