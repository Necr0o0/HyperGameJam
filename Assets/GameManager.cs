using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Transform> binQueue;
    public GameObject ground;
    private Rigidbody trapDoorLeft;
    private Rigidbody trapDoorRight;
    private float cameraHight;
    private int currentBox = 0;
    private int openedDoors = 0;
    private int maxBox = 5;
    private float distanceBetweenBoxes = 3;
    private void Awake()
    {
        trapDoorLeft = binQueue[currentBox].Find("Trapdoor/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[currentBox].Find("Trapdoor/BottomRight").GetComponent<Rigidbody>();
        cameraHight = Camera.main.transform.position.y- binQueue[0].transform.position.y;
        ground.transform.position = new Vector3(0,-distanceBetweenBoxes*maxBox+ distanceBetweenBoxes*0.5f,0);
        ground.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
                
           
            OpenDoor();
            SetNewDoors(currentBox+1);

            if(currentBox+1<maxBox)
                MoveCamera();
            if (currentBox+2 < maxBox)
            {
                NewMainBox();
            }
        }
    }

    //method to open the trapdoor
    void OpenDoor()
    {
        openedDoors++;
        trapDoorLeft.isKinematic = false;
        trapDoorRight.isKinematic = false;
    }

    void MoveCamera()
    {
        Camera.main.transform.DOMoveY( binQueue[currentBox+1].position.y + cameraHight, 1.5f);
    }

    void NewMainBox()
    {
        GameObject x = (GameObject)Instantiate(Resources.Load("Prefabs/Bin"),transform.GetChild(1) );
            x.transform.position = binQueue[currentBox+1].position+ new Vector3(0,-distanceBetweenBoxes,0);
            binQueue.Add(x.transform);
            currentBox++;

    }

    void SetNewDoors(int index)
    {
        trapDoorLeft = binQueue[index].Find("Trapdoor/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[index].Find("Trapdoor/BottomRight").GetComponent<Rigidbody>();
        Debug.Log(currentBox.ToString() + "and" + maxBox.ToString());
        if (openedDoors >= maxBox)
        {
            var sequence = DOTween.Sequence();
            sequence.AppendInterval(4f);
            sequence.OnComplete(() => { SceneManager.LoadScene(0); });
            sequence.Play();
        }
    }
}
