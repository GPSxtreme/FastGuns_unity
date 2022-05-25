using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager instance ;
    public AudioSource[] soundEffects;
    public AudioSource bgm;
    public void Awake (){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void stopBgm(){
        bgm.Stop();
    }
    public void playSfx(int sfxNo){
        soundEffects[sfxNo].Stop();
        soundEffects[sfxNo].Play();
    }
    public void stopSfx(int sfxNo){
        soundEffects[sfxNo].Stop();
    }
}
