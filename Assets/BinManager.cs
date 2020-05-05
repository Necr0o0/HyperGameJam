using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class BinManager : MonoBehaviour
{
    public BoxCollider trashDetector;

    private float counterInsideBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trashDetector.isTrigger)
        {
            counterInsideBox++;
            UnityEngine.Debug.Log(counterInsideBox);
        }
    }
    
    
}
