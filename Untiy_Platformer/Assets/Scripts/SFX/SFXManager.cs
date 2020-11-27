using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private enum SongPhase{
        Null,
        First,
        Second,
        Third,
    }
    public GameObject[] SFXTrigger;
    public AudioClip[] audioTracks;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ManageTracks(AudioClip audioTrack){
        
    }
}