﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> poolBalls;
    public List<GameObject> poolSplash;

    private GameObject trash;
    private GameObject splash;

    void Start()
    {
        trash = Resources.Load<GameObject>("Prefabs/Trash");
        splash = Resources.Load<GameObject>("Prefabs/Splash");

    }
    GameObject  AddToPool()
    {
        GameObject item = (GameObject)Instantiate(trash,transform.GetChild(0));
        GameObject itemSplash = (GameObject)Instantiate(splash,transform.GetChild(2));

        item.SetActive(false);
        splash.SetActive(false);
        poolBalls.Add(item);
        poolSplash.Add(itemSplash);
        return item;
    }
    
    public void TurnOffObject(GameObject gameObject)
    {
       int index = poolBalls.IndexOf(gameObject);
       poolBalls[index].gameObject.SetActive(false);
    }
    public Vector3 getScale()
    {
        return trash.transform.localScale;
    }

    public Transform GetObject()
    {
        for(int i = 0 ;i < poolBalls.Count;i++)
        {
            if (!poolBalls[i].activeInHierarchy)
            { 
                poolBalls[i].SetActive(true);
                return poolBalls[i].transform;
            }
        }
        
        var x = AddToPool();
        x.SetActive(true);
        return x.transform;
    }
    
    public Transform GetSplashObject()
    {
        for(int i = 0 ;i < poolSplash.Count;i++)
        {
            if (!poolSplash[i].activeInHierarchy)
            { 
                poolSplash[i].SetActive(true);
                return poolSplash[i].transform;
            }
        }
        
        var x = AddToPool();
        x.SetActive(true);
        return x.transform;
    }
}
