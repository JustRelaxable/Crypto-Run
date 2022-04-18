using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupCoinMaterialController : MonoBehaviour
{
    List<CryptoCoinMaterialOffsetController> cryptoCoinMaterialOffsetControllers = new List<CryptoCoinMaterialOffsetController>();
    private void Awake()
    {
        GameObject[] groupCoins = GameObject.FindGameObjectsWithTag("GroupCoin");
        for (int i = 0; i < groupCoins.Length; i++)
        {
            var componentList = groupCoins[i].GetComponentsInChildren<CryptoCoinMaterialOffsetController>();
            foreach (var component in componentList)
            {
                cryptoCoinMaterialOffsetControllers.Add(component);
            }
        }
    }

    public void ChangeMaterial(CryptoType cryptoType)
    {
        foreach (var item in cryptoCoinMaterialOffsetControllers)
        {
            item.cryptoIndex = (int)cryptoType;
        }
    }

    public void RemoveCoin(CryptoCoinMaterialOffsetController cryptoCoinMaterialOffsetController)
    {
        cryptoCoinMaterialOffsetControllers.Remove(cryptoCoinMaterialOffsetController);
    }
}
