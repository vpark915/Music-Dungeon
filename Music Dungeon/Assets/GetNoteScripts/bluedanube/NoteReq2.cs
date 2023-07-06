using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteReq2 : MonoBehaviour
{
    public int score; 
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = new Vector2(52f,49f);
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("Notes").GetComponent<BlueDanube>().score;
        gameObject.GetComponent<Text>().text = "Score:" + score.ToString();
    }
}
