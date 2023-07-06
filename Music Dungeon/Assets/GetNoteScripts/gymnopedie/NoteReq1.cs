using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteReq1 : MonoBehaviour
{
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Notes").GetComponent<gymnopedieno1>().score;
        gameObject.GetComponent<Text>().text = "Score:" + score.ToString();
    }
}

