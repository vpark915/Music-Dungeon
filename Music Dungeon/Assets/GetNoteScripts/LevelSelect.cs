using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>(); 
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,0);
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 120;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectHard(){
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,500f);
        m_Animator.SetBool("LevelHard",true);
    }
    public void SelectEasy(){
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,-771.8f);
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 60; 
        m_Animator.SetBool("LevelEasy",true);
    }
    public void Select1(){
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(500f,-771.8f);
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 60f; 
        m_Animator.SetBool("Level1",true);
    }
    public void Select2(){
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(1000f,-771.8f);
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 60f; 
        m_Animator.SetBool("Level2",true);
    }
    public void Select3(){
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(723.198f,-812.8f);
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 60f; 
        m_Animator.SetBool("Level3",true);
    }

    public void DebugClick(){
        Debug.Log("Click");
    }

    void OnMouseDown(){
        DebugClick();
    }
}
