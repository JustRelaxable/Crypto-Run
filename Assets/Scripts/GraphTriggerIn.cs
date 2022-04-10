using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphTriggerIn : GraphTrigger
{
    public Door trueDoor;
    public Door falseDoor;

    private Image upLogo;
    private Image downLogo;
    private GraphMaker upGraphMaker;
    private GraphMaker downGraphMaker;

    public CryptoImageSO cryptoImageSO;

    private void Awake()
    {
        base.Awake();
        upLogo = GameObject.FindGameObjectWithTag("GraphUpLogo").GetComponent<Image>();
        downLogo = GameObject.FindGameObjectWithTag("GraphDownLogo").GetComponent<Image>();
        upGraphMaker = GameObject.FindGameObjectWithTag("UpLineRenderer").GetComponent<GraphMaker>();
        downGraphMaker = GameObject.FindGameObjectWithTag("DownLineRenderer").GetComponent<GraphMaker>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    upLogo.sprite = GetLogo(trueDoor.cryptoType);
                    upGraphMaker.DrawGraph(Color.green);
                    downLogo.sprite = GetLogo(falseDoor.cryptoType);
                    downGraphMaker.DrawGraph(Color.red);
                    break;
                case 1:
                    upLogo.sprite = GetLogo(falseDoor.cryptoType);
                    upGraphMaker.DrawGraph(Color.red);
                    downLogo.sprite = GetLogo(trueDoor.cryptoType);
                    downGraphMaker.DrawGraph(Color.green);
                    break;
                default:
                    break;
            }
           
        }
    }

    private Sprite GetLogo(CryptoType cryptoType)
    {
        return cryptoImageSO.GetLogo(cryptoType);
    }
}

