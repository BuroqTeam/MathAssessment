using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManagerPattern7 : MonoBehaviour
{
    public static GameManagerPattern7 Instance;
    
    public int width;
    public int height;
    public GameObject PenTool;
    public List<GameObject> Button;
    public GameObject LineParent;
    public GameObject DotParent;
    public GameObject Cell;
    public Transform Camera;
    float percentage;
    public List<CellPattern7> CellGroup = new List<CellPattern7>();
    bool Yoqish = false;

    private void Awake()
    {
        Instance = this;
        percentage = Cell.transform.localScale.x;
    }

    void Start()
    {
        SquareLocation();
    }
    public void TurnOnTurnOf()
    {
        if (Yoqish == false)
        {
            Yoqish = true;
            PenTool.SetActive(false);
        }
        else
        {
            Yoqish = false;
            PenTool.SetActive(true);
        }
    }

    public void LineParentTurnOn()
    {
        LineParent.transform.GetChild(0).gameObject.SetActive(true);
        LineParent.transform.GetChild(0).transform.GetComponent<LineRenderer>().loop = true;
    }

    public void False()
    {
        if (LineParent.transform.childCount == 1)
        {
            _isTrueOneTime = false;
            LineParent.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        Destroy(LineParent.transform.GetChild(0).gameObject);
       

        for (int i = 0; i < DotParent.transform.childCount; i++)
        {
            Destroy(DotParent.transform.GetChild(i).gameObject);
        }    
             

    }
    public void SquareLocation()
    {
        for (float i = 0; i < width; i += percentage)
        {
            for (float j = 0; j < height; j += percentage)
            {
                var SpawnedCell = Instantiate(Cell, new Vector3(i, j), Quaternion.identity);
                //SpawnedCell.name = $"Cell {i}, {j}";
                CellGroup.Add(SpawnedCell.GetComponent<CellPattern7>());
            }
        }
        Camera.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, transform.position.z - 200);
    }


    bool _isTrueOneTime = true;

    void Update()
    {
        if (_isTrueOneTime)
        {
           
        }
    }

  
}

