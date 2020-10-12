using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


public class SaveData : MonoBehaviour
{
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";
    private BuildingPlacement buildingPlacement;
    private BuildingManager buildingManager;
    void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
        buildingManager = GetComponent<BuildingManager>();
    }

    public void Save(){
        List<GameObject> createdbuildings = buildingPlacement.getCreatedBuildings();
        // Save Data in string    
        string saveData = null;  
        foreach (GameObject createdbuilding in createdbuildings)
        {
            // string buildingType = createdbuilding.name;
            // str = str.Substring(0, 1);
            string[] contents = new string[]{
            ""+createdbuilding.name,
            ""+createdbuilding.name.Substring(0,1),
            ""+createdbuilding.transform.localPosition.x,
            ""+createdbuilding.transform.localPosition.y,
            ""+createdbuilding.transform.localPosition.z
            };
            string saveAttributes = string.Join(ATTRIBUTE_SEPERATOR,contents);
            if(saveData != null && saveData != ""){
                string[] saveObjects = new string []{saveData,saveAttributes};
                saveData  = string.Join(OBJECT_SEPERATOR,saveObjects);
                
            }else{
               saveData = saveAttributes;
            }

            File.WriteAllText(Application.dataPath + "/save.txt", saveData);
        }
                  
    }
    public void Load(){
        buildingPlacement.clearBuilding();
        string saveData = File.ReadAllText(Application.dataPath + "/save.txt");
        if(saveData != null && saveData != ""){
            string[] saveObjects = saveData.Split(new[]{OBJECT_SEPERATOR},System.StringSplitOptions.None);
            string[] dataObjects;
            foreach(string d in saveObjects)
            {
                dataObjects = d.Split(new[]{ATTRIBUTE_SEPERATOR},System.StringSplitOptions.None);
                buildingPlacement.loadBuildings(dataObjects[0],findBuilding(dataObjects[1]),dataObjects[2],dataObjects[3],dataObjects[4]);
            }
        }
                  
    }

    public GameObject findBuilding(string bt){
        GameObject[] buildings = buildingManager.getBuildings();
         switch(bt){
            case ("t"):
                return buildings[0];
            case ("a"):
                return buildings[1];
            default:
                return buildings[2];
            
        }
    }
}
