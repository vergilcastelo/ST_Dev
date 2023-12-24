using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Player Object
generates it own public data Name and Color
data based upon lists in GlobalDataManager
renames itself to lowercase Name data
*/
public class PlayerObject : MonoBehaviour
{
    //Name var proper case, unique string from AdjectivesList and ItemNamesList
    public string Name;

    //Color var chosen from ColorsList 
    public Color Color;

    //Generate method used to populate our player data in editor only    
     public void Generate()
    {
        //local vars taken from AdjectivesList and ItemNamesList randomly
        string adjective = GlobalDataManager.AdjectivesList[Random.Range(0, GlobalDataManager.AdjectivesList.Count)];
        string itemName = GlobalDataManager.ItemNamesList[Random.Range(0, GlobalDataManager.ItemNamesList.Count)];
        
        //Set Name to combination of local vars
        Name = adjective + " " + itemName;

        //log it to check 
        Debug.Log(Name);

        //Set Color from ColorsList randomly
        Color = GlobalManager.ColorsList[Random.Range(0, GlobalManager.ColorsList.Count)];

        //log Color to check
        Debug.Log(Color)
       
    }

}
