using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicsManager : MonoBehaviour
{
    void Start()
    {
        for (int j = 0; j <  transform.childCount; j++)
        {
            for (int i = 0; i < transform.GetChild(j).childCount; i++)
            {
                var z = transform.GetChild(j);
                var pos2 = z.position;

                
                var x = transform.GetChild(j).GetChild(i);
                var pos = x.position;
                pos.z = GameManager.gameManager.binQueue[0].position.z;
                pos2.z = GameManager.gameManager.binQueue[0].position.z;

                x.position =  pos ;
                z.position = pos2;
            }
        }
      
    }


}
