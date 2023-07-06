using UnityEngine;
using System; 


public class exampleCODE : MonoBehaviour
{
    AudioSource audioSource;
    public float[] spectrum;
    public float frequency;  
    public float[] debug; 
    public float[] FINALspectrum; 
    public float bigNUM; 
    public int fftindex;  
    public int upperlimit; 
    public float deprecatingFACTOR; 
    public float[] emptySpectrum;
    public double spectrumTimer;  
    public bool startTimer; 
    public bool isListening; 

    void Start()
    {
        debug = new float[8192];
        audioSource = GetComponent<AudioSource>(); 
        frequency = 0; 
        for (int i = 1; i < 8192; i++){
            debug[i] = Mathf.Log(i - 1);
        }
        emptySpectrum = new float[8192];
        StartMicListener();
    }
    void Update()
    { 
        Deprecation(); 
        //Base();
    }

    public void StartMicListener() {
        GetComponent<AudioSource>().clip = Microphone.Start(Microphone.devices[0], true, 10, AudioSettings.outputSampleRate);
        //GetComponent<AudioSource>().clip = Microphone.Start("Built-in Microphone", true, 10, AudioSettings.outputSampleRate);
        // HACK - Forces the function to wait until the microphone has started, before moving onto the play function.
        audioSource.loop = true; 
        while (!(Microphone.GetPosition(null) > 0)) {
            GetComponent<AudioSource>().Play();
        }
        /*
        while (!(Microphone.GetPosition(Microphone.devices[0]) > 0)) {
            GetComponent<AudioSource>().Play();
        }
        */
    }

    private void Deprecation(){
        FINALspectrum = new float[8192];
        spectrum = new float[8192];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        for (int a = 0; a < deprecatingFACTOR; a++){
            for (int i = 0; i < 8191; i++){
                if(a > 0){
                    FINALspectrum[i] = (FINALspectrum[i])*(1000f*spectrum[(int)(Mathf.Round((float)i/(float)a))]); 
                }
                else{
                    FINALspectrum[i] = 1000f*(spectrum[i]); 
                }
            }
        }
        
        for (int i = 0; i < 8191; i++){
            if(10f*FINALspectrum[i] < 1f){
                FINALspectrum[i] = 0; 
            }
        }
    
    
        for (int i = 90; i < 624; i++)
        {
            Debug.DrawLine(new Vector3(debug[i], 10f*FINALspectrum[i], 1), new Vector3(debug[i+1], 10f*FINALspectrum[i+1], 1), Color.green);
        } 
        bigNUM = 0;
        fftindex = 0; 
        frequency = 0f; 
        for (int i = 90; i < 624; i++){
            if(FINALspectrum[i] > bigNUM){ 
                bigNUM = FINALspectrum[i]; 
                fftindex = i; 
            }
        } 
        frequency = 1.47570235134f*Mathf.Pow(2.7182818284590452353602874713527f,(debug[fftindex]));
    }

    private void Base(){
        spectrum = new float[8192];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        for (int i = 0; i < 8192; i++){
            if(1000f*spectrum[i] < 0.6f){
                spectrum[i] = 0; 
            }
        }
        for (int i = 1; i < 8191; i++)
        {
            Debug.DrawLine(new Vector3((Mathf.Log(i - 1)), 1000*spectrum[i - 1], 1), new Vector3((Mathf.Log(i)), 1000*spectrum[i], 1), Color.green);
        }       
        bigNUM = 0;
        for (int i = 16; i < 4273; i++){
            if(1000f*spectrum[i] > bigNUM){ 
                bigNUM = 1000f*spectrum[i]; 
                fftindex = i; 
            }
        } 
        frequency = 6f*Mathf.Pow(2.7182818284590452353602874713527f,(debug[fftindex]));
    }
}

