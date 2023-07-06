using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class cancansong : MonoBehaviour
{
    Rigidbody2D rb; 
    public string[] CANCANnotes;
    public double[] CANCANtimes;  
    public string[] notes;
    public double[] times;
    public string songname; 
    public int score; 
    public int spawndex; 
    public double timer; 
    public bool timerdone; 

    public double chaintimer; 
    public double chainsum; 
    public bool sumreached; 

    public bool gamestarted; 


    public double sumofchain; 
    public double initialcoord;  

    // Start is called before the first frame update

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spawndex = 0; 
        CANCANnotes = new string[]{
        //beginning 
        "A","E","E","F#",
        "E","D","D","F#",
        "G","B","D","B",
        "B","A","A",

        "B","C#","C#","B",
        "A","D","D","F#",
        "F#","E","F#","E",
        "F#","E","F#","E",

        "A","E","E","F#",
        "E","D","D","F#",
        "G","B","D","B",
        "B","A","A",
        
        "B","C#","C#","B",
        "A","D","D","F#",
        "F#","E","F#","E",
        "E","D","D",
        //development 
        "F#","D",
        "B","A",
        "A","E","F#","G",
        "F#","E","D",
        
        "F#","D",
        "B","A",
        "G#","A","B","C#",
        "E","D","D",
        
        "F#","D",
        "B","A",
        "A","E","F#","G",
        "F#","E","D",
        
        "F#","D",
        "B","A",
        "G#","A","B","C#",
        "D","A","C#","A",
        
        "D","A","C#","A",
        "D","A","C#","A",
        "D","A","C#","A",
        
        "D","D",
        "D","D",
        "D","D",
        "D","D",

        //melody
        "G","G",
        "A","C#","B","A",
        "D","D",
        "D","E","B","C#",

        "A","A",
        "A","C#","B","A",
        "G","G","F#","E",
        "D","C#","B","A",
        
        "G",
        "A","C#","B","A",
        "D","D",
        "D","E","B","C#",
        
        "A","A",
        "A","C#","B","A",
        "G","D","A","B",
        "G","D",
        //repeat melody
        "G",
        "A","C#","B","A",
        "D","D",
        "D","E","B","C#",

        "A","A",
        "A","C#","B","A",
        "G","G","F#","E",
        "D","C#","B","A",
        
        "G",
        "A","C#","B","A",
        "D","D",
        "D","E","B","C#",
        
        "A","A",
        "A","C#","B","A",
        "G","D","A","B",
        "G","G",
        
        //back to beginning        
        "A","E","E","F#",
        "E","D","D","F#",
        "G","B","D","B",
        "B","A","A",

        "B","C#","C#","B",
        "A","D","D","F#",
        "F#","E","F#","E",
        "F#","E","F#","E",

        "A","E","E","F#",
        "E","D","D","F#",
        "G","B","D","B",
        "B","A","A",
        
        "B","A","A",
        "B","A","A",
        "B","A","A",
        "B","A","A",

        "B","A","A",
        "B","A","A",
        "B","A","A",
        
        "B","A","B","A",
        "B","A","B","A",
        "B","A","A",
        
        //main theme repeat 
        "D",
        "E","G","F#","E",
        "A","A",
        "A","B","F#","G",
        
        "E","E",
        "E","G","F#","E",
        "D","D","C#","B",
        "A","G","F#","E",
        
        "D",
        "E","G","F#","E",
        "A","A",
        "A","B","F#","G",

        "E","E",
        "E","G","F#","E",
        "D","A","E","F#",
        "D","A",
        
        "D",
        "E","G","F#","E",
        "A","A",
        "A","B","F#","G",
        
        "E","E",
        "E","G","F#","E",
        "D","D","C#","B",
        "A","G","F#","E",
        
        "D",
        "E","G","F#","E",
        "A","A",
        "A","B","F#","G",

        "E","E",
        "E","G","F#","E",
        "D","D",
        
        "E","F#",
        "A","G","F#","E",
        "C#","G","F#","E",
        "D","D",
        
        "E","F#",
        "A","G","F#","E",
        "C#","G","F#","E",
        
        "D","C#",
        "D","C#",
        "D","C#",
        "D","C#",

        "D","C#",
        "D","C#",
        "D","C#",
        "D","C#",
        
        "D","D",
        "C#","B",
        "A","G",
        "F#","E",
        
        "D","D",
        "C#","B",
        "A","G",
        "F#","E",
        
        "D","D",
        "D","D",
        "F#",
        "D",
        "A",
        "F#",
        "D"};

        CANCANtimes = new double[]{
        //beginning
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,    
        //big development
        1,1, 
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,  

        1,1, 
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,   

        1,1, 
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,  

        1,1, 
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,  

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5, 

        1,1,
        1,1,
        1,1,
        1,1,
        
        //MELODY
        1,1,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,
        
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,

        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        1,1,
        //repeat melody
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,
        
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,

        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        1,1,
        
        //repeat beginning
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,

        0.5,0.5,1,
        0.5,0.5,1,
        0.5,0.5,1,
        0.5,0.5,1,

        0.5,0.5,1,
        0.5,0.5,1,
        0.5,0.5,1,

        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,1,
        
        //Repeat melody
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,
        
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,

        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        1,1,
        //repeat again
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,
        
        1,1,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        0.5,0.5,0.5,0.5,
        
        2,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,

        1,1,
        0.5,0.5,0.5,0.5,
        1,1,
        0.5,0.5,0.5,0.5,

        0.5,0.5,0.5,0.5,
        1,1,
        1,1,
        0.5,0.5,0.5,0.5,

        0.5,0.5,0.5,0.5,
        0.5,0.5,
        1,1,
        1,1,
        1,1,
        1,1,

        1,1,
        1,1,
        1,1,
        1,1,

        1,1,
        1,1,
        1,1,
        1,1,

        1,1,
        1,1,
        1,1,
        1,1,

        1,1,
        1,1,

        2,
        2,
        2,
        2,

        1};
    }
    void Start()
    {
        sumofchain = 0; 
        score = 0; 
        sumreached = false; 
        chainsum = 0;
        Debug.Log(CANCANnotes.Length);
        Debug.Log(CANCANtimes.Length); 
        CreateGoblin(CANCANnotes[0],(float)(sumofchain));
        for (int i = 1; i < CANCANnotes.Length; i++){
            sumofchain += CANCANtimes[i-1]*100; 
            CreateGoblin(CANCANnotes[i],(float)(sumofchain));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 10){
            timer += Time.deltaTime; 
        }
        if(timer >= 8.1){
            rb.velocity = new Vector2(-280f,0);
        }
    }

    public void CreateGoblin(string letter, float xcoord){
        chainsum += CANCANtimes[spawndex]; 
        GameObject goblin = new GameObject("goblin");
        goblin.transform.parent = GameObject.Find("GoblinLine").transform;
        goblin.AddComponent<SpriteRenderer>(); 
        /*
        goblin.AddComponent<Rigidbody2D>(); 
        goblin.GetComponent<Rigidbody2D>().isKinematic = true; 
        */
        goblin.AddComponent<Canvas>();
        goblin.transform.localPosition = new Vector2(xcoord,0f);
        goblin.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("goblinv1");
        goblin.GetComponent<SpriteRenderer>().sortingOrder = 2; 
        goblin.AddComponent<BoxCollider2D>();
        goblin.GetComponent<BoxCollider2D>().isTrigger = true; 
        goblin.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        goblin.AddComponent<GBcancan>();
        goblin.GetComponent<GBcancan>().letter = letter; 
    }
}
