using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitormiss2 : MonoBehaviour
{
    public float timer; 
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if(timer > 0.2){
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,(float)(GetComponent<SpriteRenderer>().color.a - 0.08));
            timer = 0; 
        }
        if(this.transform.localPosition.y < -20){
            Destroy(gameObject);
        }
    }
}
