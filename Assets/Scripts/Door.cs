using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public CryptoType cryptoType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerPlayer(other);
        }
    }
    protected virtual void OnTriggerPlayer(Collider playerCollider)
    {

    }
}
