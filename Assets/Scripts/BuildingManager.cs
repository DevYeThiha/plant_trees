using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    public GameState gameState;
    public List<GameObject> createdbuildings;
    private BuildingPlacement buildingPlacement;
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        createdbuildings = new List<GameObject>();
        gameState.currentEvent = 0;
        gameState.tree = 0;
    }

    // Update is called once per frame
    void Update()
    {  
        
    }

  

    public void plantTree(){
        gameState.currentEvent = 1;
        createdbuildings.Add(buildingPlacement.SetItem(buildings[gameState.tree]));      
    }
    public void DeleteTree(){
        gameState.currentEvent = 2;
        buildingPlacement.SetItem(buildings[gameState.tree]);       
    }
    public void MoveTree(){
        gameState.currentEvent = 3;
        buildingPlacement.SetItem(buildings[gameState.tree]);       
    }

    public void changeTree(int tree){
        gameState.tree = tree;
        if(gameState.currentEvent == 1){
            buildingPlacement.SetItem(buildings[gameState.tree]);      
        }
    }

    public void changeView(int camera){
        //0 Top View, 1 Side View, 2 Front View
        switch(camera){
            case 1:
                transform.localPosition = new Vector3(-0.6598878f, -1.215429f, -11.43f);
                transform.localRotation = Quaternion.Euler(24.5f, 0, 0);
                break;
            case 2:
                transform.localPosition = new Vector3(10.4f, -1.215429f, -0.55f);
                transform.localRotation = Quaternion.Euler(42.5f, 270, 0);
                break;
            default:
                transform.localPosition = new Vector3(-0.6598878f, -1.215429f, -0.302834f);
                transform.localRotation = Quaternion.Euler(90f, 0, 0);
                break;
        }
    }


    

    public void save(){
       foreach (GameObject createdbuilding in createdbuildings)
       {
           Debug.Log(createdbuilding);
       }
        //  Debug.Log(transform.parent);
        
        // for (int i = 0; i< transform.childCount; i++)
        // {
        //     Debug.Log(transform.GetChild(i).gameObject);
        //     // Debug.Log(i);
        // }
       
    }

}


