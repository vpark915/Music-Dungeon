using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcontrols : MonoBehaviour
{
    Animator m_Animator; 
    GetNote m_Note; 
    public double noteTimer;
    public bool startTime;  
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
