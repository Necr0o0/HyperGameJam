
using System.Collections.Generic;
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    public BinManager bin;
    private List<Collider> hitted = new List<Collider>();

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Trash") && !hitted.Contains(collider))
        {
            bin.ChangeColor(collider.GetComponent<Renderer>().material.color);
            hitted.Add(collider);
        }
    }
}
