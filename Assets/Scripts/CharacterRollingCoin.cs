using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRollingCoin : MonoBehaviour
{
    public Transform coinTop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Vector3 scale = coinTop.transform.localScale;
            coinTop.transform.localScale += new Vector3(0.1f,0.1f,0.1f);
            coinTop.transform.localPosition += new Vector3(0, 0.01f, 0);
            Destroy(other.gameObject);
        }
    }
}
