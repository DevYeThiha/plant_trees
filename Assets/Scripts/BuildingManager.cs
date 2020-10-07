using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;
    private BuildingPlacement buildingPlacement;
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";

    // Start is called before the first frame update
    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        LoadSaveData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void plantTree(){
        buildingPlacement.SetItem(buildings[0]);
    }
    public void plantAppleTree(){
        buildingPlacement.SetItem(buildings[1]);
    }
    public void plantOrangeTree(){
        buildingPlacement.SetItem(buildings[2]);
    }

    public GameObject findBuilding(string BuildingName){
        switch(BuildingName){
            case ("tree"):
                return buildings[0];
            case ("apple"):
                return buildings[1];
            default:
                return buildings[2];
            
        }
       
    }

    public void LoadSaveData(){
        // Load Data in string
        string saveData = File.ReadAllText(Application.dataPath + "/save.txt");
        if(saveData != null && saveData != ""){
            string[] dataObjects = saveData.Split(new[]{OBJECT_SEPERATOR},System.StringSplitOptions.None);
            string[] dataAttributes;
            foreach(string d in dataObjects)
            {
            dataAttributes = d.Split(new[]{ATTRIBUTE_SEPERATOR},System.StringSplitOptions.None);
            buildingPlacement.SetItemWithPosition(findBuilding(dataAttributes[0]),dataAttributes[1],dataAttributes[2]);
            }
        }

    }

    




}
