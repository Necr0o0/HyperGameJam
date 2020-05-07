using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject funnel;
    public List<Transform> binQueue;
    public GameObject ground;
    public Transform cameraPos;
    public bool readyToPlay = false;
    private Rigidbody trapDoorLeft;
    private Rigidbody trapDoorRight;
    private float cameraHight;
    public int currentBox = 0;
    private int openedDoors = 0;
    private int maxBox = 5;
    private float distanceBetweenBoxes = 3;
    private bool levelCompleted = false;
    private List<List<Renderer>> binMaterials;

    private void Awake()
    {
        gameManager = this;
        trapDoorLeft = binQueue[currentBox].Find("Mesh/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[currentBox].Find("Mesh/BottomRight").GetComponent<Rigidbody>();
        cameraHight = cameraPos.position.y - binQueue[0].transform.position.y;

        ground.transform.position = new Vector3(0, -distanceBetweenBoxes * maxBox + distanceBetweenBoxes * 0.5f , 0);
        var fun = Instantiate(funnel,transform.GetChild(1));
        fun.transform.position  = new Vector3(0, ground.transform.position.y + 0.5f, 1f);

        ground.SetActive(true);
    }

    private void Update()
    {
        if (readyToPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {



                OpenDoor();
                SetNewDoors(currentBox + 1);

                if (currentBox + 1 < maxBox)
                    MoveCamera();
                if (currentBox + 2 < maxBox)
                {
                    SetNewMainBox();
                }
            }
        }

    }

    public void SetStartCamera()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Camera.main.transform.DOMove(cameraPos.position, 1.5f));
        sequence.Join(Camera.main.transform.DORotate(cameraPos.rotation.eulerAngles, 1.5f));
        sequence.OnComplete(() =>
        {
            readyToPlay = true;
            Camera.main.transform.position = cameraPos.transform.position;
        });
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
        Camera.main.transform.DOMoveY(binQueue[currentBox + 1].position.y + cameraHight, 1.5f);
        //Camera.main.transform.DOLookAt( binQueue[currentBox+1].Find("Front").position+ new Vector3( 0,2,0),  1.5f);

    }

    void SetNewMainBox()
    {
        Transform x = SpawnerManager.Manager.GetComponent<ObjectPool>().GetBinObject();
        x.position = binQueue[currentBox + 1].position + new Vector3(0, -distanceBetweenBoxes, 0);
        SetNewMeshMaterial(x.GetComponent<BinManager>());
        binQueue.Add(x.transform);
        currentBox++;
    }

    void SetNewMeshMaterial(BinManager mainBox)
    {
        var walls = mainBox.BinWalls;

        Material material = new Material(walls[0].material);
        Color color = material.color;
        for (int i = 0; i < walls.Count; i++)
        {
          // mainBox.BinWalls[i].material.color = material.color+ new Color(1,1,1,0)  * (  Mathf.Pow(2.0f,(currentBox+1f)/maxBox));
        }
    }

    void SetNewDoors(int index)
    {
        trapDoorLeft = binQueue[index].Find("Mesh/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[index].Find("Mesh/BottomRight").GetComponent<Rigidbody>();
        if (openedDoors >= maxBox && !levelCompleted)
        {
            
            var sequence = DOTween.Sequence();
            //sequence.Append(Camera.main.transform.DOLocalMoveZ(-1f,2));
            //sequence.Join(Camera.main.transform.DOLookAt(ground.transform.position, 1f));
            sequence.AppendInterval(2f);
           
            sequence.OnComplete(() =>
            {
                /*
                var x = Instantiate(Resources.Load<Transform>("Prefabs/Trash"),Camera.main.transform);
                x.position = Camera.main.transform.position + new Vector3(0,-0.5f,0.25f);
                x.gameObject.SetActive(true);
                x.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                x.GetComponent<Rigidbody>().isKinematic = true;
                var y = SpawnerManager.Manager.GetComponent<ObjectPool>().GetSplashObject();
                var angle = new Quaternion();
                angle = Quaternion.Euler(30, 0, 0);
                y.transform.localEulerAngles = new Vector3(30,0,0);
                y.GetComponent<SplashManager>().TriggerAnimation(x);
                */
                var sequence2 = DOTween.Sequence();
                sequence2.AppendInterval(2f);
                sequence2.OnComplete(() => { SceneManager.LoadScene(0);});

            });
            sequence.Play();
            levelCompleted = true;
        }
    }
}
