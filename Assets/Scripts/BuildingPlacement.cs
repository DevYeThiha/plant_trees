using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private PlaceableBuilding placeableBuilding;
    private Transform currentBuilding;
    private bool hasPlaced;
    public LayerMask buildingsMask;
    private PlaceableBuilding placeableBuildingOld;
    public List<GameObject> createdbuildings;
    private  GameObject newBuilding;
    private GameObject building;
    public GameState gameState;

    void Update(){
         Vector3 m = Input.mousePosition;
        m = new Vector3(m.x,m.y,transform.position.y);
        Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);
        if(currentBuilding != null && !hasPlaced){
            PlantTree(p);
        }else{
            if(Input.GetMouseButtonDown(0)){
                
                RaycastHit hit = new RaycastHit();
                Ray ray = new Ray(new Vector3(p.x,8,p.z), Vector3.down);
                buildingsMask = LayerMask.GetMask("Building");
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask)){
                    if(placeableBuildingOld != null){
                        placeableBuildingOld.SetSelected(false);
                    }
                    if(gameState.currentEvent == 2){
                        createdbuildings.Remove(hit.collider.gameObject);
                        Destroy(hit.collider.gameObject);
                    }else if(gameState.currentEvent == 3){
                        Debug.Log(createdbuildings.Find(x => x == hit.collider.gameObject));
                        hasPlaced = false;
                        currentBuilding = hit.collider.gameObject.transform;
                    }
                    placeableBuildingOld = null;
                    // hit.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
                    // placeableBuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding>();
                }else {
                  
                    
                }
            }
        }
      
        
    }

    public void hide(){
        if(newBuilding){
            hasPlaced = true;
            Destroy(newBuilding);
        }
    }
    public void show(){
         if(!newBuilding && (gameState.currentEvent == 1) && building){
             hasPlaced = false;
            SetItem(building);
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
        building = b;
        newBuilding = (GameObject)Instantiate(building);
        newBuilding.name  = newBuilding.name.Remove(newBuilding.name.Length - 7) + transform.childCount;
        newBuilding.transform.parent = gameObject.transform;
        currentBuilding = (newBuilding).transform;
        placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();
    }

    public void PlantTree(Vector3 p){
        currentBuilding.position = new Vector3(p.x,(float)0.5,p.z);
            // if(Input.GetKeyDown(KeyCode.Escape)){
            //     Destroy(newBuilding);
            // }
            if((Input.GetMouseButtonDown(0)) && (!hasPlaced)){
                if(IsLegalPosition()){
                    hasPlaced = true;
                    
                    if(gameState.currentEvent == 1){
                        createdbuildings.Add(newBuilding);
                        SetItem(building);
                    }
                   
                   
                    // Debug.Log(currentBuilding.position);
                    // SaveData(objectName,currentBuilding.position);
                   
                }       
            }
    }

    public List<GameObject> getCreatedBuildings(){
         return createdbuildings; 
    }
    
    public void loadBuildings(string name, GameObject building, string px, string pz){
        GameObject loadBuilding = (GameObject)Instantiate(building);
        loadBuilding.name  = name;
        loadBuilding.transform.parent = gameObject.transform;
        loadBuilding.transform.localPosition = new Vector3(float.Parse(px),(float)0.5, float.Parse(pz));
        hasPlaced = true;
    }


}
