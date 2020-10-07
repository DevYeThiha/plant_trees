using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class RecordEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setChangeEvent(){
        File.WriteAllText(Application.dataPath + "/event.txt", "Change");
    }

    public void setCreateEvent(){
        File.WriteAllText(Application.dataPath + "/event.txt", "Create");
    }
    public void setDeleteEvent(){
        File.WriteAllText(Application.dataPath + "/event.txt", "Delete");
    }

    public string getEvent(){
        return File.ReadAllText(Application.dataPath + "/event.txt");
    }
}
