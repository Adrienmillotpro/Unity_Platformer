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
    [SerializeField] [Range(0f, 1f)] private float desiredlowVolume;
    private float desiredVolume;

    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Player"){
            switch(currentMode){
                case TuningMode.TurningUp:
                    desiredVolume = desiredHighVolume;
                    currentMode = TuningMode.TurningDown;
                break;

                case TuningMode.TurningDown:
                    desiredVolume = desiredlowVolume;
                    currentMode = TuningMode.TurningUp;
                break;

                case TuningMode.Null:
                break;
        }
            SendInfoToManager(triggerID, desiredVolume);
        }
    }

    private void SendInfoToManager(int ID, float desiredVolume){
        SFXManager manager = GetComponent<SFXManager>();
        manager.SortSources(ID, desiredVolume);
    }

}
