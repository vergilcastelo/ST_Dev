using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Origin Shifter class
- references both prefab componets 
- spawns 2nd aircraft on spacebar press
- 2nd aircraft spawns at the same speed as the 1st
- shift between the 2 aircrafts xrOrigin on enter
*/
public class OriginShifter : MonoBehaviour
{
    //reference both aircraft prefabs in editor
    public GameObject planeOnePrefab;
    public GameObject planeTwoPrefab;

    //for instantiation of 2nd aircraft when spawning
    private GameObject planeTwoInstance;

    //for individual rigs 
    private GameObject xrRigOnPlaneOne;
    private GameObject xrRigOnPlaneTwo;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add inputs spacebar and enter

        //maintain speed on spawn
    }

    //space bar spawn method
     void SpawnPlaneTwo()
    {
    
    }

    //origin shift toggle method
    void  ToggleXRRigs()
    {

    }

    //get origin rig 
    void GetXRRig(GameObject plane)
    {

    }
}
