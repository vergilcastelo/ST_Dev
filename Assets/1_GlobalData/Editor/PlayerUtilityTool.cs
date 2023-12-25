using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PlayerUtilityTool : EditorWindow
{
    //track scroll position in scrolling window
    private Vector2 scrollPosition;

    //search query string
    private string searchQuery = "";

    //list for filtering player objects
    private List<PlayerObject> filteredPlayers = new List<PlayerObject>();

    //create tool accessible from the top menu under window
    [MenuItem("Window/Player Utility Tool")]

    //show sindow method triggered by menuitem above
    public static void ShowWindow()
    {
        //create editor window of this class 
        GetWindow<PlayerUtilityTool>("Player Utility Tool");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
