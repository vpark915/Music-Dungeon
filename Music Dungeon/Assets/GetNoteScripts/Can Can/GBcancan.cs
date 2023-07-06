using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class GBcancan : MonoBehaviour
{
    public bool active; 
    public int score; 
    public bool spawned;
    //Rigidbody2D rb;  
    public string letter; 
    // Start is called before the first frame update
    void Start()
    {
        active = true; 
        CreateLetter();
        score = 0; 
        spawned = false; 
        //rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        transform.Translate(Vector2.left*297f*Time.deltaTime, Space.World);
        */
        if(active == true){
            IncreaseIndex();
        }
        /*
        if(600-transform.position.x >= (100*(double)GameObject.Find("GoblinLine").GetComponent<cancansong>().times[GameObject.Find("GoblinLine").GetComponent<cancansong>().spawndex]) && spawned == false){
            spawned = true; 
            GameObject.Find("GoblinLine").GetComponent<cancansong>().spawndex += 1; 
            if(GameObject.Find("GoblinLine").GetComponent<cancansong>().sumreached == false){
                GameObject.Find("GoblinLine").GetComponent<cancansong>().CreateGoblin(); 
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "hithitbox"){
            GameObject.Find("PitchDetectionHard").GetComponent<GetNoteHard>().index += 1; 
            GameObject.Find("GoblinLine").GetComponent<cancansong>().score += 1; 
            Destroy(gameObject);
        }
        if(col.name == "FarWall"){
            Destroy(gameObject);
        }
    }

    void IncreaseIndex(){
        if(this.transform.position.x < -175f){
            GameObject.Find("PitchDetectionHard").GetComponent<GetNoteHard>().index += 1; 
            active = false; 
        }
    }

    void CreateLetter(){
        GameObject newNote = new GameObject("newNote");
        Text text = newNote.AddComponent<Text>(); 
        newNote.transform.SetParent(this.transform);
        newNote.transform.localPosition = new Vector2(0f,19f);
        newNote.GetComponent<RectTransform>().sizeDelta = new Vector2(30f,30f);
        //newNote.GetComponent<Text>().text = GameObject.Find("GoblinLine").GetComponent<cancansong>().notes[GameObject.Find("GoblinLine").GetComponent<cancansong>().spawndex];    
        newNote.GetComponent<Text>().text = letter;  
        newNote.GetComponent<Text>().alignment = TextAnchor.MiddleCenter; 
        newNote.GetComponent<Text>().fontSize = 20; 
        newNote.GetComponent<Text>().color = Color.yellow; 
        newNote.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
    }
}
