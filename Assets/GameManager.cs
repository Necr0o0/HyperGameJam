using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public List<Transform> binQueue;
    public GameObject ground;
    public Transform cameraPos;
    public bool readyToPlay = false;
    private Rigidbody trapDoorLeft;
    private Rigidbody trapDoorRight;
    private float cameraHight;
    private int currentBox = 0;
    private int openedDoors = 0;
    private int maxBox = 5;
    private float distanceBetweenBoxes = 3;
    private bool levelCompleted = false;
    private void Awake()
    {
        gameManager = this;
        trapDoorLeft = binQueue[currentBox].Find("Trapdoor/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[currentBox].Find("Trapdoor/BottomRight").GetComponent<Rigidbody>();
        cameraHight = cameraPos.position.y- binQueue[0].transform.position.y;
        ground.transform.position = new Vector3(0,-distanceBetweenBoxes*maxBox+ distanceBetweenBoxes*0.5f,0);
        ground.SetActive(true);
    }

    private void Update()
    {
        if (readyToPlay)
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
      
    }

    public void SetStartCamera()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Camera.main.transform.DOMove(cameraPos.position, 1.5f));
        sequence.Join(  Camera.main.transform.DORotate(cameraPos.rotation.eulerAngles, 1.5f));
        sequence.OnComplete(() => { readyToPlay = true; });
        sequence.Play();

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
        //Camera.main.transform.DOLookAt( binQueue[currentBox+1].Find("Front").position+ new Vector3( 0,2,0),  1.5f);

    }

    void NewMainBox()
    {
        GameObject x = (GameObject)Instantiate(Resources.Load("Prefabs/Bin"),transform.GetChild(1) );
            x.transform.position = binQueue[currentBox+1].position+ new Vector3(0,-distanceBetweenBoxes,0);
            //Material material = new Material(x.GetComponent<Renderer>().material);
           // x.act
            binQueue.Add(x.transform);
            currentBox++;

    }

    void SetNewDoors(int index)
    {
        trapDoorLeft = binQueue[index].Find("Trapdoor/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[index].Find("Trapdoor/BottomRight").GetComponent<Rigidbody>();
        if (openedDoors >= maxBox && !levelCompleted)
        {
            var sequence = DOTween.Sequence();
            sequence.Append(Camera.main.transform.DOLocalMoveZ(-3f,2));
            //sequence.Join(Camera.main.transform.DOLookAt(ground.transform.position, 1f));
            sequence.AppendInterval(2f);
            sequence.OnComplete(() => { SceneManager.LoadScene(0); });
            sequence.Play();
            levelCompleted = true;
        }
    }
}
