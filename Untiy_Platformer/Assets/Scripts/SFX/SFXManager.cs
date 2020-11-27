using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float trackTransitionSpeed;
    public AudioSource[] additionalAudioSources;

    public void SortSources(int sfxTriggerID, float desiredVolume){
        for(int i = 0; i < additionalAudioSources.Length; i++){
            if(i == sfxTriggerID){
                ManageVolume(additionalAudioSources[i], desiredVolume);
            }
        }
    }
    public void ManageVolume(AudioSource audioSource, float desiredVolume){
        audioSource.volume = Mathf.Lerp(audioSource.volume, desiredVolume, trackTransitionSpeed * Time.deltaTime);
    }
}