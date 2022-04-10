using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphTrigger : MonoBehaviour
{
    public bool graphIn;
    protected Animator graphAnimator;

    protected void Awake()
    {
        graphAnimator = GameObject.FindGameObjectWithTag("Graph").GetComponent<Animator>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (graphIn)
                graphAnimator.SetTrigger("GraphIn");
            else
                graphAnimator.SetTrigger("GraphOut");
        }
    }
}
