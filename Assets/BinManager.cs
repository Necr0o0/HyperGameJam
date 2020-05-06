using System;
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
        _material = new Material(BinWalls[0].material);
    }

    // Update is called once per frame
    public void ChangeColor()
    {
  
            counterInsideBox++;
            for (int i = 0; i < BinWalls.Count; i++)
            {
                BinWalls[i].material.color = _material.color + new Color(0,1,0,0) * counterInsideBox * 0.005f;
            }

            if (counterInsideBox > 70)
            {
                
            }
    }
}
