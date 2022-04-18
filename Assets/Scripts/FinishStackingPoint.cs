using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishStackingPoint : MonoBehaviour
{
    public Vector3 coinOffset;
    public GameObject coinPrefab;

    private int coinNumber;
    private int currentCoin = 0;
    public void SetCoinCount(int number)
    {
        this.coinNumber = number;
    }

    public Vector3 GetStackingPosition(int index)
    {
        return (index * coinOffset);
    }

    public void StartAnimation()
    {
        StartCoroutine(StackCoins());
    }

    IEnumerator StackCoins()
    {
        Camera mainCamera = Camera.main;
        mainCamera.GetComponent<CameraController>().enabled = false;
        Vector3 lastPosition = GetStackingPosition(coinNumber-1);
        lastPosition = transform.TransformPoint(lastPosition);
        lastPosition = new Vector3(mainCamera.transform.position.x, lastPosition.y, mainCamera.transform.position.z);
        mainCamera.transform.DOMove(lastPosition, 10f);

        for (int i = 0; i < coinNumber; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform);
            coin.GetComponentInChildren<CryptoCoinMaterialOffsetController>().cryptoIndex = (int)CryptoType.Bitcoin;
            coin.transform.localPosition = GetStackingPosition(i);
            coin.transform.DOScale(8f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
