using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPmovement : MonoBehaviour
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
    }

    public void Swing(){
        m_Animator.Play("fwrdHIT");
    }
}