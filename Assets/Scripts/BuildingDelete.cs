using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDelete : MonoBehaviour
{
    // private PlaceableBuilding placeableBuilding;
    // private Transform currentBuilding;
    private bool hasPlaced;
    // Start is called before the first frame update
    public LayerMask buildingsMask;
    // private PlaceableBuilding placeableBuildingOld;


    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Delete Process Started");
        // Vector3 m = Input.mousePosition;
        // m = new Vector3(m.x,m.y,transform.position.y);
        // Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);
        // if(Input.GetMouseButtonDown(0)){
        //     RaycastHit hit = new RaycastHit();
        //     Ray ray = new Ray(new Vector3(p.x,8,p.z), Vector3.down);
        //     if(Physics.Raycast(ray, out hit, Mathf.Infinity, buildingsMask)){
        //         Debug.Log(hit.collider.gameObject);
        //         Destroy(hit.collider.gameObject);
        //     }
        // }
    }



    public void DeleteItem(GameObject b){
        hasPlaced = false;
    }
}
