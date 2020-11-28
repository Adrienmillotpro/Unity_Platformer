using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    private enum TuningMode{
        Null,
        TurningUp,
        TurningDown,
    }
    [SerializeField] private int triggerID;
    [SerializeField] private TuningMode currentMode;
    [SerializeField] [Range (0f, 1f)] private float desiredHighVolume;
    [SerializeField] [Range(0f, 1f)] private float desiredLowVolume;
    private float desiredVolume;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player"){
            // Debug.Log("Found ya!");
            switch(this.currentMode){
                case TuningMode.TurningUp:
                    desiredVolume = desiredHighVolume;
                    currentMode = TuningMode.TurningDown;
                break;

                case TuningMode.TurningDown:
                    desiredVolume = desiredLowVolume;
                    currentMode = TuningMode.TurningUp;
                break;

                case TuningMode.Null:
                break;
            }
            SendInfoToManager(triggerID, desiredVolume);
        }
    }

    private void SendInfoToManager(int ID, float desiredVolume){
        // Debug.Log("Here's the ID I'm sending" + triggerID.ToString());
        SFXManager manager = FindObjectOfType<SFXManager>();
        manager.SortSources(ID, desiredVolume);
    }

}
