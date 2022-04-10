using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CryptoImageDictionary",menuName = "Crypto-Run/CryptoImageDictionary")]
public class CryptoImageSO : ScriptableObject
{
    public CryptoImageDictionary[] cryptoImageDictionary;
    private Dictionary<CryptoType, Sprite> keyPair;
    private void Awake()
    {
    }

    public Sprite GetLogo(CryptoType cryptoType)
    {
        foreach (var item in cryptoImageDictionary)
        {
            if(item.cryptoType == cryptoType)
            {
                return item.cryptoImage;
            }
        }
        return null;
    }
}

[System.Serializable]
public class CryptoImageDictionary
{
    public Sprite cryptoImage;
    public CryptoType cryptoType;
}
