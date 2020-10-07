using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;
    public GameObject cameraThree;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThreeAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
        cameraThreeAudioLis = cameraThree.GetComponent<AudioListener>();

        //Camera Position Set
        // cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
        cameraPositionChange(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    public void cameraPositionChange(int camPosition)
    {
        Debug.Log(camPosition);
        if (camPosition > 3)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        switch(camPosition){
            case 0:
                cameraOne.SetActive(true);
                cameraOneAudioLis.enabled = true;

                cameraTwoAudioLis.enabled = false;
                cameraTwo.SetActive(false);

                cameraThreeAudioLis.enabled = false;
                cameraThree.SetActive(false);
                break;
            case 1:
                cameraTwo.SetActive(true);
                cameraTwoAudioLis.enabled = true;

                cameraOneAudioLis.enabled = false;
                cameraOne.SetActive(false);

                cameraThreeAudioLis.enabled = false;
                cameraThree.SetActive(false);
                break;
            case 2:
                cameraThreeAudioLis.enabled = true;
                cameraThree.SetActive(true);

                cameraOneAudioLis.enabled = false;
                cameraOne.SetActive(false);

                cameraTwoAudioLis.enabled = false;
                cameraTwo.SetActive(false);
                break;
            default:
                break;
            

        }

    }
}
