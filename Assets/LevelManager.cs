using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int ballsInside;
    public int levelID = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Trash"))
            ballsInside++;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Trash")){
        
            ballsInside--;

            if (ballsInside <= 0)
            {
                Debug.Log("MOVE CAM");
                GameManager.gameManager.MoveCamera(levelID);

            }
        
        }
    }
}
