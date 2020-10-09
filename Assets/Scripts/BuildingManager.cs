using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    public GameState gameState;
    public Text information;
    private string[] informations;

    private BuildingPlacement buildingPlacement;
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        gameState.currentEvent = 0;
        gameState.tree = 0;
        informations = new string[]{"The Tree is Green", "The Apple Tree is Red", "The Orange Tree is Orange"};
        information.text= informations[0];
    }

    // Update is called once per frame
    void Update()
    {  
        
    }

    public void plantTree(){
        gameState.currentEvent = 1;
        buildingPlacement.SetItem(buildings[gameState.tree]);      
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
        information.text= informations[gameState.tree];
    }
    public void changeView(int camera){
        //0 Top View, 1 Side View, 2 Front View
        switch(camera){
            case 1:
                GameObject.Find("MainCamera").transform.localPosition = new Vector3(-0.6598878f, 7.7f, -11.43f);
                GameObject.Find("MainCamera").transform.localRotation = Quaternion.Euler(24.5f, 0, 0);
                break;
            case 2:
                GameObject.Find("MainCamera").transform.localPosition = new Vector3(12.99f, 7.3f, -0.55f);
                GameObject.Find("MainCamera").transform.localRotation = Quaternion.Euler(42.5f, 270, 0);
                break;
            default:
                GameObject.Find("MainCamera").transform.localPosition = new Vector3(0.01f, 10f, 0.02f);
                GameObject.Find("MainCamera").transform.localRotation = Quaternion.Euler(90f, 0, 0);
                break;
        }
    }
    public GameObject[] getBuildings(){
        return buildings;
    }
}


