using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";
    private PlaceableBuilding placeableBuilding;
    private Transform currentBuilding;
    private bool hasPlaced;
    public LayerMask buildingsMask;
    private PlaceableBuilding placeableBuildingOld;
    private string objectName;
    private RecordEvent recordEvent;

    void Start(){
        recordEvent = GetComponent<RecordEvent>();
    }
    void Update(){
        Vector3 m = Input.mousePosition;
        m = new Vector3(m.x,m.y,transform.position.y);
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);
        if(currentBuilding != null && !hasPlaced){
           
            currentBuilding.position = new Vector3(p.x,(float)0.5,p.z);
            if(Input.GetMouseButtonDown(0)){
                if(IsLegalPosition()){
                    hasPlaced = true;
                    // SaveData(objectName,currentBuilding.position);
                   
                }       
            } 
        }else {
           
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x,8,p.z), Vector3.down);
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask) ){
                    if(placeableBuildingOld != null){
                        placeableBuildingOld.SetSelected(false);
                    }
                    // Debug.Log(recordEvent.getEvent);
                    if(Equals(recordEvent.getEvent(),"Change")){
                        MoveItem(hit.collider.gameObject); 
                    }else if(Equals(recordEvent.getEvent(),"Delete")){
                        DeleteItem(hit.collider.gameObject);
                    }
                    
                    hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
                    placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
                    
                }else {
                    if(placeableBuildingOld != null){
                        placeableBuildingOld.SetSelected(false);
                    }
                    
                }
            }
        }
        
    }

    bool IsLegalPosition(){
        if(placeableBuilding.colliders.Count > 0){
            return false;
        }
        return true;
    }

    public void SetItem(GameObject b){
        hasPlaced = false;
        objectName = b.name;
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
    }
    public void MoveItem(GameObject b){
        objectName = b.name.Remove(b.name.Length - 7);
        currentBuilding = ((GameObject)Instantiate(b)).transform;
        currentBuilding.name = objectName+"(Clone)"; 
        Destroy(b);
        recordEvent.setCreateEvent();
        hasPlaced = false;
        
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
    }

    public void DeleteItem(GameObject b){
        Destroy(b);
        recordEvent.setCreateEvent();
    }
    public void SetItemWithPosition(GameObject b,string px,string pz){
        hasPlaced = false;
        objectName = b.name;
        Instantiate(b, new Vector3(float.Parse(px),(float)0.5,float.Parse(pz)), Quaternion.identity);
        // currentBuilding = ((GameObject)Instantiate(b)).trasnform.position(float. Parse(px),(float)0.5,float. Parse(pz));
    }

     public void SaveData(string objectName, Vector3 p){
        // Save Data in string         
        string[] contents = new string[]{
            ""+objectName,
            ""+p.x,
            ""+p.z
        };
        string saveAttributes = string.Join(ATTRIBUTE_SEPERATOR,contents);
        string saveData = GetSaveData();
        if(saveData != null && saveData != ""){
            string[] saveObjects = new string []{saveData,saveAttributes};
            string saveObject = string.Join(OBJECT_SEPERATOR,saveObjects);
            File.WriteAllText(Application.dataPath + "/save.txt", saveObject);
        }else{
            File.WriteAllText(Application.dataPath + "/save.txt", saveAttributes);
        }
                  
    }
    

    public string GetSaveData(){
        // Load Data in string
        return File.ReadAllText(Application.dataPath + "/save.txt");
    }


}
