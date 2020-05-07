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

    // Start is called before the first frame update
    void Start()
    {
        Manager = this;
    }

    // Update is called once per frame
    
}
