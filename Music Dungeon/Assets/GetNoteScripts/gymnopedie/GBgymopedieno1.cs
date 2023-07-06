using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class GBgymnopedieno1 : MonoBehaviour
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
        xcoord = this.transform.position.x;
        if(active == true){
            IncreaseIndex();
        }
        if(this.transform.position.x < -120){
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
            GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>().index += 1; 
            GameObject.Find("Notes").GetComponent<gymnopedieno1>().score += 50; 
            hit(); 
            Destroy(gameObject);
        }
    }

    void IncreaseIndex(){
        if(this.transform.position.x < 420f){
            GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>().index += 1; 
            miss(); 
            active = false; 
        }
    }

    void hit(){
        GameObject ind = new GameObject("indicator");
        ind.transform.parent = GameObject.Find("Level").transform;
        ind.transform.localPosition = new Vector2(-75f,-20f);
        ind.AddComponent<SpriteRenderer>(); 
        ind.GetComponent<SpriteRenderer>().sortingOrder = 200; 
        ind.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("nicehit");
        ind.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        ind.AddComponent<Rigidbody2D>(); 
        ind.GetComponent<Rigidbody2D>().gravityScale = 4f; 
        ind.GetComponent<Rigidbody2D>().velocity = new Vector2(0,40); 
        ind.AddComponent<hitormiss>(); 
    }

    void miss(){
        GameObject ind = new GameObject("indicator");
        ind.transform.parent = GameObject.Find("Level").transform;
        ind.transform.localPosition = new Vector2(-75f,-20f);
        ind.AddComponent<SpriteRenderer>(); 
        ind.GetComponent<SpriteRenderer>().sortingOrder = 200; 
        ind.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("miss");
        ind.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        ind.AddComponent<Rigidbody2D>(); 
        ind.GetComponent<Rigidbody2D>().gravityScale = 4f; 
        ind.GetComponent<Rigidbody2D>().velocity = new Vector2(0,40); 
        ind.AddComponent<hitormiss>(); 
    }
}
