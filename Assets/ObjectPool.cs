using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pool;
    private GameObject trash;
    void Start()
    {

        trash = Resources.Load<GameObject>("Prefabs/Trash");
    }
    GameObject  AddToPool()
    {
        GameObject item = (GameObject)Instantiate(trash,transform.GetChild(0));

        item.SetActive(false);
        pool.Add(item);
        return item;
    }
    
    public void TurnOffObject(GameObject gameObject)
    {
       int index = pool.IndexOf(gameObject);
       pool[index].gameObject.SetActive(false);
    }
    public Vector3 getScale()
    {
        return trash.transform.localScale;
    }

    public Transform GetObject()
    {
        Debug.Log(pool.Count);
        for(int i = 0 ;i < pool.Count;i++)
        {                
            Debug.Log("TRY REUSE");

            if (!pool[i].activeInHierarchy)
            {
                Debug.Log("RESUSE");
                pool[i].SetActive(true);
                return pool[i].transform;
            }
        }
        
        var x = AddToPool();
        x.SetActive(true);
        return x.transform;
    }
}
