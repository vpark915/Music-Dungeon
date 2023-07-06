using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteReqTut : MonoBehaviour
{
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("FarWall").GetComponent<tutorialsong>().score;
        gameObject.GetComponent<Text>().text = "Keys Hit:" + score.ToString() + "/25";
    }
}
