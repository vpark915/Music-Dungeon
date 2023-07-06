using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class GBprelude : MonoBehaviour
{
    public bool active; 
    public int score; 
    public bool spawned;
    //Rigidbody2D rb;  
    public string letter; 
    public float xcoord; 
    // Start is called before the first frame update
    void Start()
    {
        active = true; 
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
        xcoord = gameObject.transform.position.x; 
        if(active == true){
            IncreaseIndex();
        }
        if(this.transform.position.x < 15f){
            Destroy(gameObject);
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
            GameObject.Find("PitchDetectionEasy").GetComponent<GetNote2>().index += 1; 
            GameObject.Find("Notes").GetComponent<Prelude>().score += 1; 
            Destroy(gameObject);
        }
    }

    void IncreaseIndex(){
        if(gameObject.transform.position.x < 957f){
            GameObject.Find("PitchDetectionEasy").GetComponent<GetNote3>().index += 1; 
            active = false; 
        }
    }
}