using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class gymnopedieno1 : MonoBehaviour
{
    Rigidbody2D rb; 
    public string[] GPnotes;
    public double[] GPtimes;  
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
        GPnotes = new string[]{
            "F#","A",
            "G","F#","C#",
            "B","C#","D",
            "A",
            "F#",
            "F#",
            "F#",
            "F#",
            "F#","A",
            "G","F#","C#",
            "B","C#","D",
            "A",
            "C#",
            "F#",
            //
            "E",
            "E",
            "E",
            "A","B","C",
            "E","D","B",
            "D","C","B",
            "D",
            "D","D",
            "E","F","G",
            "A","C","D",
            "E","D","B",
            "D",
            "D","D",
            "G",
            "F#",
            "B","A","B",
            "C#","D","E",
            "C#","D","E",
            "F#","D","G",
            "C",
            "D",
            //RECAP
            "F#","A",
            "G","F#","C#",
            "B","C#","D",
            "A",
            "F#",
            "F#",
            "F#",
            "F#",
            "F#","A",
            "G","F#","C#",
            "B","C#","D",
            "A",
            "C#",
            "F#",
            "E",
            "E",
            "E",
            //
            "A","B","C",
            "E","D","B",
            "D","C","B",
            "D",
            "D","D",
            "E","F","G",
            "A","C","D",
            "E","D","B",
            "D",
            "D","D",
            "G",
            "F",
            "B","C","F",
            "E","D","C",
            "E","D","C",
            "F","D","G",
            "E",
            "F"
        };
        GPtimes = new double[]{
            1,1,
            1,1,1,
            1,1,1,
            3.5,
            3,
            3,
            3,
            4,
            1,1,
            1,1,1,
            1,1,1,
            3.5,
            3,
            3,
            //
            3,
            3,
            3,
            1,1,1,
            1,1,1,
            1,1,1,
            //
            3.5,
            2,1,
            1,1,1,
            1,1,1,
            1,1,1,
            //
            3.5,
            2,1,
            3,
            3,
            1,1,1,
            1,1,1,
            1,1,1,
            1,1,1,
            //
            3.5,
            16,
            //
            1,1,
            1,1,1,
            1,1,1,
            3.5,
            3,
            3,
            3,
            4,
            //
            1,1,
            1,1,1,
            1,1,1,
            3.5,
            3,
            3,
            //
            3,3,3,
            //
            1,1,1,
            1,1,1,
            1,1,1,
            3.5,
            2,1,
            1,1,1,
            1,1,1,
            1,1,1,
            //
            3.5,
            2,1,
            3,
            3,
            1,1,1,
            1,1,1,
            1,1,1,
            1,1,1,
            3.5,3
        };
    }
    void Start()
    {
        sumofchain = 0; 
        score = 0; 
        sumreached = false; 
        chainsum = 0;
        Debug.Log(GPnotes.Length);
        Debug.Log(GPtimes.Length); 
        CreateLetter(GPnotes[0],(float)(sumofchain));
        for (int i = 1; i < GPnotes.Length; i++){
            sumofchain += GPtimes[i-1]*100; 
            CreateLetter(GPnotes[i],(float)(sumofchain));
        }
        this.transform.localPosition = new Vector2(400f,-26.84412f);
        timer = 0; 
        rb.velocity = new Vector2(0,0);
        GameObject.Find("Notes").GetComponent<AudioSource>().volume = 0.5f;
        GameObject.Find("Notes").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("GPV5");
        GameObject.Find("Notes").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 25){
            timer += Time.deltaTime; 
        }
        if(timer >= 10.6){
            rb.velocity = new Vector2(-85f,0);
        }
        if(timer >= 282){
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("Level1cs1",true);
        }
        /*
        if(timer >= 62.2 && GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>().index == 12){
            rb.velocity = new Vector2(-83.333333333f,0);
        }
        if(GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>().index == 107){
            rb.velocity = new Vector2(-131.66666666f,0);
        }
        if(GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>().index == 130){
            rb.velocity = new Vector2(-83.333333333f,0);
        }
        if(score > 50){
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("Level1cs1",true);
        }
        */
    }

    public void CreateLetter(string note, float xcoord){
        chainsum += GPtimes[spawndex]; 
        GameObject letter = new GameObject("letter");
        letter.transform.parent = GameObject.Find("Notes").transform;
        /*
        letter.AddComponent<Rigidbody2D>(); 
        letter.GetComponent<Rigidbody2D>().isKinematic = true; 
        */
        letter.AddComponent<Canvas>();
        letter.transform.localPosition = new Vector2(xcoord,0f);
        letter.AddComponent<BoxCollider2D>();
        letter.AddComponent<GBgymnopedieno1>(); 
        letter.GetComponent<BoxCollider2D>().isTrigger = true; 
        letter.GetComponent<BoxCollider2D>().size = new Vector2(20f,20f);
        letter.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        letter.AddComponent<Text>();
        letter.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        letter.GetComponent<Text>().text = note; 
        letter.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
}
