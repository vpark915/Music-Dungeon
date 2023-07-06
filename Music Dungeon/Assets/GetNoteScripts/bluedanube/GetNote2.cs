using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class GetNote2 : MonoBehaviour
{
    public string CurrentNote; 
    public float frequency;
    public float expectedFREQ; 
    public float[] noteFREQ; 
    public string[] notes; 
    public float smallDIFF;  
    public int predictINDEX; 
    public int i; 
    public string closest_note; 
    public double noteTimer;
    public bool startTime;  
    exampleCODE pitchdetection; 
    public int index; 
    public string targetNote; 
    // Start is called before the first frame update
    void Start()
    {
        notes = new string[]{"C","C#","D","D#","E","F","F#","G","G#","A","A#","B"};
        smallDIFF = 100;
        pitchdetection = GetComponent<exampleCODE>();  
        index = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs1",false);
        //GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs2",false);
        GenerateNote(); 
        NoteandSwing(); 
    }

    void NoteandSwing(){
        frequency = pitchdetection.frequency; 
        /*
        if(Input.GetKeyDown("space")){
            GameObject.Find("player").GetComponent<BDmovement>().Swing(); 
        }
        */
        
        if(frequency == 1.47570235134f || frequency == 0f){
            CurrentNote = "None";
        }
        else{
            i = (int)Math.Round(12*Math.Log(frequency/(440*Math.Pow(2,-4.75)),2));
            predictINDEX = i % 12; 
            CurrentNote = notes[predictINDEX];
            if(CurrentNote == targetNote){
                GameObject.Find("player").GetComponent<BDmovement>().Swing(); 
            }
        }
    }
    void GenerateNote(){
        targetNote = GameObject.Find("Notes").GetComponent<BlueDanube>().BDnotes[index];
    }
    
}