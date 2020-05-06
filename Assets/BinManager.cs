using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class BinManager : MonoBehaviour
{
    public BoxCollider trashDetector;
    public List<Renderer> BinWalls;
    private Color defaultColor;
    private Material _material;

    public float counterInsideBox;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = BinWalls[0].material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trashDetector.isTrigger)
        {
            counterInsideBox++;
            for (int i = 0; i < BinWalls.Count; i++)
            {
                BinWalls[i].material.color = defaultColor * Color.green * counterInsideBox * 0.01f;
            }
        }
    }
    
    
}
