using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private const string ATTRIBUTE_SEPERATOR = "#Attribute-VALUE#";
    private const string OBJECT_SEPERATOR = "#Object-VALUE#";
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
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
