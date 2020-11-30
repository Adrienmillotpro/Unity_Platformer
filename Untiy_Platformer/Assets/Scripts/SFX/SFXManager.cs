using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SFXManager : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float trackTransitionSpeed;
    public AudioSource[] additionalAudioSources;
    // public AnimationCurve curve; // curve for fancy tweening

    public void SortSources(int sfxTriggerID, float desiredVolume){
        // Debug.Log(this.additionalAudioSources.Length);
        for (int i = 0; i < this.additionalAudioSources.Length; i++){
            if (i == sfxTriggerID){
                Debug.Log("this is my Index " + i);
                ManageVolume(additionalAudioSources[i], desiredVolume);
            }
        }
    }

    public void ManageVolume(AudioSource audioSource, float desiredVolume){
        audioSource.DOFade(desiredVolume, trackTransitionSpeed); // there's an error on my side, apparently VSC hates me, but it works just fine
    }

}