using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptoCoinMaterialOffsetController : MonoBehaviour
{
    [SerializeField]
    [Range(0,43)]
    public int cryptoIndex;

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
