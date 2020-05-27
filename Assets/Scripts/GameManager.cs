using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager;
    public GameObject funnel;
    public List<Transform> binQueue;
    public List<GameObject> Levels;

    public GameObject ground;
    public GameObject sky;

    public Transform cameraPos;
    public bool readyToPlay = false;
    private Rigidbody trapDoorLeft;
    private Rigidbody trapDoorRight;
    private float cameraHight;
    public int currentBox = 0;
    private int openedDoors = 0;
    private int maxBox = 5;
    [SerializeField]
    private float distanceBetweenBoxes = 5;

    [SerializeField] private float moveCameraSpeed = 1.0f;
    private bool levelCompleted;
    private List<List<Renderer>> binMaterials;
    private ParticleSystem _particleSystem;

    private int _paletteNumber;

    public List<Palette> palettes;
    private Camera _mainCamera;
    

    private void Awake()
    {
        gameManager = this;
        trapDoorLeft = binQueue[currentBox].Find("Mesh/BottomLeft").GetComponent<Rigidbody>();
        trapDoorRight = binQueue[currentBox].Find("Mesh/BottomRight").GetComponent<Rigidbody>();
        cameraHight = cameraPos.position.y - binQueue[0].transform.position.y;
       
        
        ground.SetActive(true);
        _mainCamera=Camera.main;

        SetColors();

        _particleSystem = binQueue[1].Find("ParticleSystem/Sparks").GetComponent<ParticleSystem>();
        var main = _particleSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(palettes[_paletteNumber].ball1Color, palettes[_paletteNumber].ball2Color);
        ground.transform.position = new Vector3(0, -distanceBetweenBoxes * maxBox + distanceBetweenBoxes * 0.5f - 1.5f , 0);
        var fun = Instantiate(funnel,transform);
        fun.transform.position  = new Vector3(0, ground.transform.position.y + 1.4f, binQueue[0].position.z);

        for (int i = 0; i < Levels.Count; i++)
        {
            Levels[i].GetComponent<LevelManager>().levelID = i+1;
            if (i < maxBox - 1)
            {
                Levels[i].SetActive(true);
                Levels[i].transform.position =  new Vector3(0, binQueue[1].position.y - distanceBetweenBoxes * i +1.0f, binQueue[1].position.z) ;
            }
       
        }
    }

    private void Update()
    {
        if (readyToPlay)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                
                OpenDoor();
                SetNewDoors(currentBox + 1);

                if (openedDoors  < maxBox)
                   // MoveCamera(currentBox);
                    MoveLevelCamera();
                if (currentBox + 2 < maxBox)
                {
                    SetNewMainBox();
                }
            }
        }

    }

    public void SetColors()
    {
        int paletteNumber = Random.Range(0,4);
        _paletteNumber = paletteNumber;
        Debug.Log("paletteNumber:" + paletteNumber);
        
        var ball1Material = Resources.Load<Material>("Materials/Trash/TrashMaterial0");
        var ball1Material2 = Resources.Load<Material>("Materials/Trash/TrashMaterial1");

        var ball1TraceMaterial = Resources.Load<Material>("MaterialsNoShader/Trash/TrashMaterial0");
        var ball2TraceMaterial = Resources.Load<Material>("MaterialsNoShader/Trash/TrashMaterial1");

        var boxMaterial = Resources.Load<Material>("Materials/Box");
        
        

        
        ground.GetComponent<Renderer>().sharedMaterial.color = palettes[paletteNumber].groundColor;
        funnel.GetComponent<Renderer>().sharedMaterial.color = palettes[paletteNumber].funnelColor;
        sky.GetComponent<Renderer>().sharedMaterial.color = palettes[paletteNumber].backgroundColor;
        boxMaterial.color = palettes[paletteNumber].boxColor;
        
        ball1Material.color = palettes[paletteNumber].ball1Color;
        ball1TraceMaterial.color = palettes[paletteNumber].ball1Color;
        
        ball1Material2.color = palettes[paletteNumber].ball2Color; 
        ball2TraceMaterial.color = palettes[paletteNumber].ball2Color;

        
    }

    
    
    public void SetStartCamera()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(_mainCamera.transform.DOMove(cameraPos.position, 1.5f));
        sequence.Join(_mainCamera.transform.DORotate(cameraPos.rotation.eulerAngles, 1.5f));
        sequence.OnComplete(() =>
        {
            readyToPlay = true;
            _mainCamera.transform.position = cameraPos.transform.position;
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

    public void EndMoveCamera()
    {
        _mainCamera.transform.DOMoveY(funnel.transform.position.y , moveCameraSpeed);
        //Camera.main.transform.DOLookAt( binQueue[currentBox+1].Find("Front").position+ new Vector3( 0,2,0),  1.5f);
    }
    public void MoveCamera(int levelID)
    {
        if(levelID == openedDoors && openedDoors < maxBox)
            _mainCamera.transform.DOMoveY(binQueue[openedDoors].position.y + cameraHight, moveCameraSpeed);
        //Camera.main.transform.DOLookAt( binQueue[currentBox+1].Find("Front").position+ new Vector3( 0,2,0),  1.5f);
    }
    void MoveLevelCamera()
    {
            _mainCamera.transform.DOMoveY(binQueue[openedDoors].transform.position.y + cameraHight +distanceBetweenBoxes -1.5f, moveCameraSpeed);
        //Camera.main.transform.DOLookAt( binQueue[currentBox+1].Find("Front").position+ new Vector3( 0,2,0),  1.5f);
    }

    void SetNewMainBox()
    {
        Transform x = ObjectPool.Instance.GetBinObject();
        x.position = binQueue[currentBox + 1].position + new Vector3(0, -distanceBetweenBoxes, 0);
        SetNewMeshMaterial(x.GetComponent<BinManager>());
        
        
        _particleSystem = x.Find("ParticleSystem/Sparks").GetComponent<ParticleSystem>();
        var main = _particleSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(palettes[_paletteNumber].ball1Color, palettes[_paletteNumber].ball2Color);
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
            //EndMoveCamera();
            
            var sequence = DOTween.Sequence();
            //sequence.Append(Camera.main.transform.DOLocalMoveZ(-1f,2));
            //sequence.Join(Camera.main.transform.DOLookAt(ground.transform.position, 1f));
            sequence.AppendInterval(2f);
           
            sequence.OnComplete(() =>
            {
                /*  SPLASH ON MIDDLE
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
                sequence2.AppendInterval(4f);
                sequence2.OnComplete(() => { SceneManager.LoadScene(0);});

            });
            sequence.Play();
            levelCompleted = true;
        }
    }
}
