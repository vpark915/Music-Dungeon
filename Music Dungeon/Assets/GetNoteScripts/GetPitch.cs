using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class GetPitch : MonoBehaviour
{
    public List<float> altsamples; 
    public float[] samples;
    public float[] newsamples; 
    public double sampleTIMER; 
    public int peaks; 
    public float sampleRATE; 
    public int debugCounter;
    public float frequency;  
    // Start is called before the first frame update
    void Start()
    {
        samples = new float[16384];
        sampleTIMER = 0;
        peaks = 1; 
        StartMicListener(); 
        //GetComponent<AudioSource>().clip = Microphone.Start(Microphone.devices[0], true, 10, 48000);
    }

    // Update is called once per frame
    void Update()
    {
        if(sampleTIMER < sampleRATE){
            sampleTIMER += Time.deltaTime; 
        }
        else{
            peaks = 0;  
            debugCounter = 0; 
            sampleTIMER = 0;
            GetComponent<AudioSource>().GetOutputData(samples, 0);
            if(Math.Abs(samples[0]) > 0){
                EliminateBack(); 
                DrawDots();
                RecordPeaks(); 
            }
        }
    }
    
    void EliminateBack(){
        altsamples = new List<float>();
        for(int i = 0; i < 16383; i++){
            if(Math.Abs(1000*samples[i]) > 0){
                altsamples.Add(samples[i]);
            }
        }
        newsamples = altsamples.ToArray(); 
    }
    
    void DrawDots(){
        for(int i = 0; i < newsamples.Length - 1; i++){
            Debug.DrawLine(new Vector2(i/10,(1000*newsamples[i])), new Vector2((i+1)/10,(1000*newsamples[i+1])), Color.white, sampleRATE);
        }
    }

    void RecordPeaks(){
        for(int i = 0; i < newsamples.Length - 1; i++){
            debugCounter += 1;
            if((1000*newsamples[i]) > 0f && (1000*newsamples[i+1]) < 0f){
                peaks += 1; 
            }
            else if((1000*newsamples[i]) < 0f && (1000*newsamples[i+1]) > 0f){
                peaks += 1; 
            }
        }
        if((float)peaks > 0){
            frequency = (1/((16384f/48000f)/((float)(peaks))));
        }
    }

    private void StartMicListener() {
        GetComponent<AudioSource>().clip = Microphone.Start(Microphone.devices[0], true, 999, 48000);
        // HACK - Forces the function to wait until the microphone has started, before moving onto the play function.
        while (!(Microphone.GetPosition(Microphone.devices[0]) > 0)) {
            GetComponent<AudioSource>().Play();
        }
    }
}

