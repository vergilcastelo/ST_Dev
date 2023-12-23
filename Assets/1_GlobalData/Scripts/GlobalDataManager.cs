using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Global Data Manager
Singlegton for one instace at any time.
Manager for modification of data lists.
Serialized lists for access in inspector.
Corresponding public lists for runtime access. 
*/ 
public class GlobalDataManager : MonoBehaviour
{
    //Singleton instance, access lists via instance
    public static GlobalDataManager Instance;
    //internal private lists
    [SerializeField, Tooltip("List of adjectives.")]
    private List<string> adjectives = new List<string>();

    [SerializeField, Tooltip("List of item names.")]
    private List<string> itemNames = new List<string>();
    
    [SerializeField, Tooltip("List of colors.")]
    private List<string> colors = new List<string>();

    //external public lists with getters and setters
    public static List<string> AdjectivesList { get; set; } = new List<string>();
    public static List<string> ItemNamesList { get; set; } = new List<string>();
    public static List<string> ColorsList { get; set; } = new List<string>();

    //Awake called to init variables before application starts 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeList(AdjectivesList, adjectives);
            InitializeList(ItemNamesList, itemNames);
            InitializeList(ColorsList, colors);
        }else
        {
            Destroy(gameObject);
        }
    }

    //Generic method to initialize any list
    private void InitializeList(List<string> targetList, List<string> sourceList)
    {
        targetList.Clear();
        for (int i = 0; i < sourceList.Count; i++)
        {
            targetList.Add(sourceList[i]);
        }
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
