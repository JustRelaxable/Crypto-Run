using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphTriggerIn : GraphTrigger
{
    public CryptoType leftDoor;
    public CryptoType rightDoor;

    private Image upLogo;
    private Image downLogo;

    public CryptoImageSO cryptoImageSO;

    private void Awake()
    {
        base.Awake();
        upLogo = GameObject.FindGameObjectWithTag("GraphUpLogo").GetComponent<Image>();
        downLogo = GameObject.FindGameObjectWithTag("GraphDownLogo").GetComponent<Image>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("MainCoin"))
        {
            upLogo.sprite = GetLogo(leftDoor);
            downLogo.sprite = GetLogo(rightDoor);
        }
    }

    private Sprite GetLogo(CryptoType cryptoType)
    {
        return cryptoImageSO.GetLogo(cryptoType);
    }
}

