using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
