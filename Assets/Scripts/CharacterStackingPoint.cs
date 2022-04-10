using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterStackingPoint : MonoBehaviour
{
    public Vector3 coinOffset;
    public Vector3 coinRotation;
    List<MeshRenderer> coinsMeshRenderers = new List<MeshRenderer>();
    List<CryptoCoinMaterialOffsetController> cryptoCoinMaterialOffsetControllers = new List<CryptoCoinMaterialOffsetController>();

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
        cryptoCoinMaterialOffsetControllers.Add(meshRenderer.gameObject.GetComponent<CryptoCoinMaterialOffsetController>());
    }

    public void ChangeCoins(CryptoType cryptoType)
    {
        StartCoroutine(ChangeCoinsCoroutine(cryptoType));
    }

    IEnumerator ChangeCoinsCoroutine(CryptoType cryptoType)
    {
        for (int i = 0; i < cryptoCoinMaterialOffsetControllers.Count; i++)
        {
            Sequence sequence = DOTween.Sequence();
            cryptoCoinMaterialOffsetControllers[i].cryptoIndex = (int)cryptoType;
            sequence.Append(cryptoCoinMaterialOffsetControllers[i].transform.DOScale(1.5f, 0.5f));
            sequence.Append(cryptoCoinMaterialOffsetControllers[i].transform.DOScale(1f, 0.5f));
            sequence.Play();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
