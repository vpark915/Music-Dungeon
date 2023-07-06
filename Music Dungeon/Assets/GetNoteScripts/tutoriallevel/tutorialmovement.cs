using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialmovement : MonoBehaviour
{
    Rigidbody2D rb; 
    Animator m_Animator; 
    GetNote m_Note; 
    public double noteTimer;
    public bool startTime;  
    public bool moveright; 
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x < -53.63 && moveright == false){
            moveright = true; 
        }
        if(transform.localPosition.x > 63.25 && moveright == true){
            moveright = false;
        }
        if(moveright == false){
            transform.localScale = new Vector2(-1f,1f);
            rb.velocity = new Vector2(-50f,0);
        }
        if(moveright == true){
            transform.localScale = new Vector2(1f,1f);
            rb.velocity = new Vector2(50f,0);
        }

        /*
        if(m_Note.CurrentNote == "C"){
            m_Animator.Play("fwrdHIT");
        }
        */

        /*
        if(m_Note.CurrentNote == "C"){
            GameObject.Find("hithitbox").transform.localPosition = new Vector2(0.2f,0f);
            m_Animator.Play("fwrdHIT");
            startTime = true; 
        }
        if(startTime == true){
            if(noteTimer < 0.05){
            noteTimer += Time.deltaTime; 
            }
            else{
                GameObject.Find("hithitbox").transform.localPosition = new Vector2(0.0f,10f);
                noteTimer = 0; 
                startTime = false; 
            }
        }
        */
    }

    public void Swing(){
        m_Animator.Play("fwrdHIT");
    }
}

