using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Manager;
    public List<Transform> spawners;
    public TextMeshProUGUI BallsLeft;
    public int spawnedTrash=0;

    private void Awake()
    {
        Manager = this;
    }
    
}
