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
    
    // private BuildingDelete buildingDelete;
    // private MoveBuilding moveBuilding;
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";

    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        gameState.currentEvent = 0;
        gameState.tree = 0;
        // buildingDelete = GetComponent<BuildingDelete>();    
    }

    // Update is called once per frame
    void Update()
    {

        // if((Input.GetMouseButtonDown(0)) && (Equals(getEvent(),"Create"))){
        //     plantTree();
        // }
       
        
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
    }

    public void changeView(int camera){
        // transform.position = transform.position + new Vector3(1, 0, 3);
        // transform.position = new Vector3(1f, 0f, 3f);
        // transform.eulerAngles = new Vector3 (90f, 1f, 0);
        // transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        // transform.rotate(90,0,0);
        GetComponent<Camera>().transform.position = new Vector3(1f, 0f, 3f);
      
    }


    

    public void save(){
    //   createdbuildings = gameState.createdbuildings;
    //    foreach (GameObject createdbuilding in createdbuildings)
    //    {
    //        Debug.Log(tranform.parent);
    //    }
        //  Debug.Log(transform.parent);
        
        for (int i = 0; i< transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).gameObject);
            // Debug.Log(i);
        }
       
    }
    
    
    
    
    
    
  

    public GameObject findBuilding(string BuildingName){
        switch(BuildingName){
            case ("tree"):
                return buildings[0];
            case ("apple"):
                return buildings[1];
            case ("0"):
                return buildings[0];
            case ("1"):
                return buildings[1];
            default:
                return buildings[2];
            
        }
       
    }

    // public void LoadSaveData(){
    //     // Load Data in string
    //     string saveData = File.ReadAllText(Application.dataPath + "/save.txt");
    //     if(saveData != null && saveData != ""){
    //         string[] dataObjects = saveData.Split(new[]{OBJECT_SEPERATOR},System.StringSplitOptions.None);
    //         string[] dataAttributes;
    //         foreach(string d in dataObjects)
    //         {
    //         dataAttributes = d.Split(new[]{ATTRIBUTE_SEPERATOR},System.StringSplitOptions.None);
    //         buildingPlacement.SetItemWithPosition(findBuilding(dataAttributes[0]),dataAttributes[1],dataAttributes[2]);
    //         }
    //     }

    // }

    public string getEvent(){
        return File.ReadAllText(Application.dataPath + "/event.txt");
    }




}


