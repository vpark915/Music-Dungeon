using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Prelude : MonoBehaviour
{
    Rigidbody2D rb; 
    public string[] PLnotes;
    public double[] PLtimes;  
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

    public bool clipplayed; 

    // Start is called before the first frame update

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spawndex = 0; 
        PLnotes = new string[]{
            //measures 1-8
            "C","E","G",
            "G","G",
            "G","E",
            "E","C",
            "C","E","G",
            "F","F",
            "F","B",
            "B","B",
            //measures 9-16
            "B","D","A",
            "A","A",
            "A","F",
            "F","B",
            "B","D","A",
            "A","A",
            "A","E",
            "E","C"
        };
        PLtimes = new double[]{
            //measures 1-8 
            1,1,1,
            2,1,
            2,1,
            2,1,
            1,1,1,
            2,1,
            2,1,
            2,1,
            //9-16
            1,1,1,
            2,1,
            2,1,
            2,1,
            1,1,1,
            2,1,
            2,1,
            2,1,
        };
    }
    void Start()
    {
        sumofchain = 0; 
        score = 0; 
        sumreached = false; 
        chainsum = 0;
        Debug.Log(PLnotes.Length);
        Debug.Log(PLtimes.Length); 
        CreateLetter(PLnotes[0],(float)(sumofchain));
        for (int i = 1; i < PLnotes.Length; i++){
            sumofchain += PLtimes[i-1]*100; 
            CreateLetter(PLnotes[i],(float)(sumofchain));
        }
        this.transform.localPosition = new Vector2(390f,-26.84412f);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 4){
            timer += Time.deltaTime; 
        }
        if(timer >= 1.55){
            rb.velocity = new Vector2(-125f,0);
        }
        if(score > 30){
            GameObject.Find("Level4").GetComponent<Animator>().SetBool("Level2cs1",true);
        }
    }

    public void CreateLetter(string note, float xcoord){
        chainsum += PLtimes[spawndex]; 
        GameObject letter = new GameObject("letter");
        letter.transform.parent = GameObject.Find("Notes").transform;
        /*
        letter.AddComponent<Rigidbody2D>(); 
        letter.GetComponent<Rigidbody2D>().isKinematic = true; 
        */
        letter.AddComponent<Canvas>();
        letter.AddComponent<SpriteRenderer>(); 
        letter.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("fish");
        letter.GetComponent<SpriteRenderer>().sortingOrder = 105; 
        letter.transform.localPosition = new Vector2(xcoord,-20f);
        letter.AddComponent<BoxCollider2D>();
        letter.AddComponent<GBprelude>(); 
        letter.GetComponent<BoxCollider2D>().isTrigger = true; 
        letter.GetComponent<BoxCollider2D>().size = new Vector2(28.62451f,20f);
        letter.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        letter.GetComponent<RectTransform>().sizeDelta = new Vector2(63.7f,38.8f);
        letter.AddComponent<Text>();
        letter.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        letter.GetComponent<Text>().text = note; 
        letter.GetComponent<Text>().alignment = TextAnchor.UpperCenter;

    }
}