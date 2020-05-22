﻿using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> poolBalls;
    public List<GameObject> poolBins;
    public List<GameObject> poolSplash;

    private GameObject trash;
    private GameObject splash;
    private GameObject bin;


    void Awake()
    {
        trash = Resources.Load<GameObject>("Prefabs/Trash");
        splash = Resources.Load<GameObject>("Prefabs/Splash");
        bin = Resources.Load<GameObject>("Prefabs/Bin");

        splash.SetActive(false);

    }
    GameObject  AddToPool()
    {
        GameObject item = (GameObject)Instantiate(trash,transform.GetChild(0));
        GameObject itemSplash = (GameObject)Instantiate(splash,transform.GetChild(2));

        item.SetActive(false);
        splash.transform.localEulerAngles = new Vector3(90,Random.Range(0f,360f),0);
        splash.SetActive(false);
        poolBalls.Add(item);
        poolSplash.Add(itemSplash);
        return item;
    }
    
    public Vector3 getScale()
    {
        return trash.transform.localScale;
    }

    public Transform GetBallObject()
    {
        for(int i = 0 ;i < poolBalls.Count;i++)
        {
            if (!poolBalls[i].activeInHierarchy)
            { 
                poolBalls[i].SetActive(true);
                return poolBalls[i].transform;
            }
        }
        
        var x = Instantiate(trash, transform.GetChild(0));
        x.SetActive(true);
        return x.transform;
    }
    
    public Transform GetBinObject()
    {
        for(int i = 0 ;i < poolBins.Count;i++)
        {
            if (!poolBins[i].activeInHierarchy)
            { 
                poolBins[i].SetActive(true);
                return poolBins[i].transform;
            }
        }

        var x = Instantiate(bin, transform.GetChild(1));
        poolBins.Add(x);
        x.SetActive(true);
        return x.transform;
    }
    
    public Transform GetSplashObject()
    {
        Debug.Log(poolSplash.Count);
        for(int i = 0;i < poolSplash.Count;i++)
        {
            if (!poolSplash[i].activeInHierarchy)
            { 
                poolSplash[i].SetActive(true);
                return poolSplash[i].transform;
            }
        }
        
        var x = Instantiate(splash, transform.GetChild(2));
        x.SetActive(false);
        poolSplash.Add(x);
        return x.transform;
    }
}