using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="GameState", menuName="States/GameState")]
public class GameState : ScriptableObject
{
    
    public int currentEvent = 0;  // 0 Default, 1 Create, 2 Delete, 3 Create

    
    public int tree = 0; // 0 Tree, 1 Apple Tree, 2 Orange Tree
     
    

}
