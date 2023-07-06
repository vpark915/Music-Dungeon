using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class tutorialsong : MonoBehaviour
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

    public string letter; 

    public bool tutorial2started; 

    public bool pitchdead; 
    // Start is called before the first frame update

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        spawndex = 0; 
        GPnotes = new string[]{
            "E","D","C","D",
            "E","E","E",
            "D","D","D",
            "E","G","G",
            "E","D","C","D",
            "E","E","E","E",
            "D","D","E","D",
            "C"
        };
        GPtimes = new double[]{};
    }
    void Start()
    {
        sumofchain = 0; 
        score = 0; 
        sumreached = false; 
        chainsum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pitchdead == false){
            letter = GameObject.Find("PitchDetectionEasy").GetComponent<GetNoteTutorial>().targetNote; 
            GameObject.Find("LetterText").GetComponent<Text>().text = letter; 
        }
        if(spawndex == 1 && tutorial2started == false){
            GameObject.Find("Level1").GetComponent<StartingFunctions>().tutorialstart2();
            tutorial2started = true; 
        }
        if(spawndex > 3){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar2");
        }
        else if(spawndex > 5){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar3");
        }
        else if(spawndex > 8){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar4");
        }
        else if(spawndex > 11){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar5");
        }
        else if(spawndex > 15){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar6");
        }
        else if(spawndex > 18){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar7");
        }
        else if(spawndex > 20){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar8");
        }
        else if(spawndex >= 23){
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tutorial/prisonbar/prisonbar9");
        }
        if(spawndex == 25){
            pitchdead = true; 
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs3",true);
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if (collider.name == "hithitbox"){
            GameObject.Find("PitchDetectionEasy").GetComponent<GetNoteTutorial>().index += 1; 
            score += 1; 
            spawndex += 1; 
        }
    }
}
