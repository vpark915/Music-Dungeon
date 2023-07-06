using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingFunctions : MonoBehaviour
{
    public bool tutorialstartbool; 

    public bool tutorialstart2bool; 

    public bool tutorialendbool; 
    public bool tutorialend2bool; 

    public bool focusBarbool; 
    public bool defaultCameraTutorialbool; 
    public bool backtoStartbool; 
    public bool backtoStartbool2;
    public bool menubool; 
    

    public bool l1startbool; 
    public bool l1restart1bool; 
    public bool l1restart2bool; 
    public bool l1audiostart; 


    public bool l2startbool; 

    public bool l3startbool; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Booleans to start the tutorial cutscenes 
        if(menubool == true){
            menuend(); 
        }
        if(tutorialstartbool == true){
            tutorialstart(); 
        }
        if(tutorialstart2bool == true){
            tutorialstart2();
        }
        if(focusBarbool == true){
            focusBar(); 
        }
        if(backtoStartbool == true){
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("StartEasy",false);
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("LevelEasy",false);
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("menu",true);
            tutorialstartbool = false; 
            tutorialstart2bool = false; 
            focusBarbool = false; 
            defaultCameraTutorialbool = false; 
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs3",false);
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs2",false);
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs1",false);
            GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,0);
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 120f; 
        }
        if(backtoStartbool2 == true){
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("Level1",false);
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("Start1",false);
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("Level1cs1",false);
            tutorialstartbool = false; 
            tutorialstart2bool = false; 
            focusBarbool = false; 
            defaultCameraTutorialbool = false; 
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("menu",true);
            GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,0);
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 120f; 
            backtoStartbool2 = false;
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("menu",false);
        }
        if(defaultCameraTutorialbool == true){
            defaultCameraTutorial(); 
        }

        //Booleans to end the tutorial cutscenes 
        if(tutorialendbool == true){
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs1",false);
        }

        if(tutorialend2bool == true){
            GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs2",false);
        }
        
        //Level 1 
        if(l1startbool == true){
            level1start(); 
        }

        if(l1restart1bool == true){
            GameObject.Find("Level2").GetComponent<Animator>().SetBool("restart1",true);
            level1restart1(); 
            l1restart1bool = false; 
        }

        if(l1restart2bool == true){
            level1restart2(); 
            l1restart2bool = false; 
        }
        
        //Level 2 
        if(l2startbool == true){
            level2start();
        }

        //Level 3
        if(l3startbool == true){
            level3start();
        }

    }

    public void menuend(){
        GameObject.Find("Level1").GetComponent<Animator>().SetBool("menu",false);
        GameObject.Find("Level2").GetComponent<Animator>().SetBool("menu",false);
    }

    public void tutorialstart(){
        GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs1",true);
        GameObject.Find("Level1").GetComponent<Animator>().SetBool("StartEasy",true);
        //GameObject.Find("player").GetComponent<tutorialmovement>().enabled = false;
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(0f,-500f);
        GameObject.Find("cutscene").SetActive(false);
    }

    public void tutorialstart2(){
        //GameObject.Find("player").GetComponent<tutorialmovement>().enabled = false;
        GameObject.Find("Level1").GetComponent<Animator>().SetBool("tutcs2",true);
        //GameObject.Find("uiimage").SetActive(false);
    }

    public void focusBar(){
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 30f; 
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(-50f, -515f); 
    }

    public void defaultCameraTutorial(){
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 60f; 
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(0,-500f);
    }


    //Level 1 functions 
    public void level1start(){
        GameObject.Find("Level2").GetComponent<Animator>().SetBool("Start1",true);
        //GameObject.Find("player").GetComponent<tutorialmovement>().enabled = false;
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(500f,-500f);
        GameObject.Find("cutscene").SetActive(false);
    }

    //level1
    public void level1restart1(){
        GameObject.Find("Level2").GetComponent<Animator>().SetBool("restart1",true);
        GameObject.Find("Notes").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        GameObject.Find("Notes").transform.localPosition = new Vector2(-63.5f,-14f);
        Destroy(GameObject.Find("PitchDetectionEasy").GetComponent<GetNote1>());
        Destroy(GameObject.Find("PitchDetectionEasy").GetComponent<exampleCODE>());
        Destroy(GameObject.Find("Notes").GetComponent<gymnopedieno1>());
        foreach (Transform child in GameObject.Find("Notes").transform) {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find("PitchDetectionEasy").AddComponent<GetNote1>();
        GameObject.Find("PitchDetectionEasy").AddComponent<exampleCODE>();
        GameObject.Find("Notes").AddComponent<gymnopedieno1>();
        GameObject.Find("score").AddComponent<NoteReq1>().score = 0;
        GameObject.Find("Notes").GetComponent<AudioSource>().Stop(); 
        GameObject.Find("Notes").GetComponent<AudioSource>().Play();
        GameObject.Find("Level2").GetComponent<Animator>().SetBool("restart1",false);
    }

    //level2
    public void level1restart2(){
        GameObject.Find("Level3").GetComponent<Animator>().SetBool("restart2",true);
        GameObject.Find("Notes").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        GameObject.Find("Notes").transform.localPosition = new Vector2(-63.5f,-14f);
        Destroy(GameObject.Find("PitchDetectionEasy").GetComponent<GetNote2>());
        Destroy(GameObject.Find("PitchDetectionEasy").GetComponent<exampleCODE>());
        Destroy(GameObject.Find("Notes").GetComponent<BlueDanube>());
        foreach (Transform child in GameObject.Find("Notes").transform) {
            GameObject.Destroy(child.gameObject);
        }
        GameObject.Find("PitchDetectionEasy").AddComponent<GetNote2>();
        GameObject.Find("PitchDetectionEasy").AddComponent<exampleCODE>();
        GameObject.Find("Notes").AddComponent<BlueDanube>();
        GameObject.Find("Notes").GetComponent<AudioSource>().Stop(); 
        GameObject.Find("Notes").GetComponent<AudioSource>().Play();
        GameObject.Find("Level3").GetComponent<Animator>().SetBool("restart2",false);
    }

    public void level2restart1(){
        GameObject.Find("Level2").GetComponent<Animator>().SetBool("restart1",false);
        GameObject.Find("Notes").AddComponent<AudioSource>();
        GameObject.Find("Notes").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("GPV5");
        GameObject.Find("Notes").AddComponent<AudioSource>().volume = 0.5f;
        GameObject.Find("Notes").GetComponent<AudioSource>().Play();
        GameObject.Find("PitchDetectionEasy").AddComponent<GetNote1>();
        GameObject.Find("PitchDetectionEasy").AddComponent<exampleCODE>();
        GameObject.Find("Notes").AddComponent<gymnopedieno1>();
    }

    //Level 2 functions 
    public void level2start(){
        GameObject.Find("Level3").GetComponent<Animator>().SetBool("Start2",true);
        //GameObject.Find("player").GetComponent<tutorialmovement>().enabled = false;
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(1000f,-500f);
        GameObject.Find("cutscene").SetActive(false);
    }

    //Level 3 functions 
    public void level3start(){
        GameObject.Find("Level4").GetComponent<Animator>().SetBool("Start3",true);
        //GameObject.Find("player").GetComponent<tutorialmovement>().enabled = false;
        GameObject.Find("Main Camera").transform.localPosition = new Vector2(723.198f,-541f);
        GameObject.Find("cutscene").SetActive(false);
    }
}
