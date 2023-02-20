using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private CharacterController2D characterController;
    public List<RadioStation> radioStations;
    public int currentStation;
    public float waitBeforeOff = 15;
    public bool hasDoubleJumpCassette;
    public bool isDoubleJumpCassettePlaying;
    public bool hasClimbCassette;
    public bool isClimbCassettePlaying;

    // Start is called before the first frame update
    void Start()
    {
        PlayRadio();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && hasDoubleJumpCassette && currentStation != 1)
        {
            currentStation = 1;
            PlayRadio();
            isDoubleJumpCassettePlaying = true;
            isClimbCassettePlaying = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && hasClimbCassette && currentStation != 2)
        {
            currentStation = 2;
            PlayRadio();
            isDoubleJumpCassettePlaying = false;
            isClimbCassettePlaying = true;
        }
    }


    public void AdjustRadioVolume(float value)
    {
        audioMixer.SetFloat("Volume", Mathf.Log10(value) * 20);
    }

    public void PlayRadio()
    {
        for (int i = 0; i < radioStations.Count; i++)
        {
            if (i != currentStation)
            {
                radioStations[i].gameObject.GetComponent<Image>().enabled = false;
                radioStations[i].audioSource.volume = 0;
                radioStations[i].waitTime = waitBeforeOff;
                radioStations[i].isCurrentRadio = false;
            }
        }

        radioStations[currentStation].gameObject.GetComponent<Image>().enabled = true;
        radioStations[currentStation].audioSource.volume = 1;
        radioStations[currentStation].isRadioStopped = false;
        radioStations[currentStation].isCurrentRadio = true;
    }

    public void NavigateStations(bool isForward)
    {
        if (isForward)
        {
            currentStation += 1;
            if (currentStation >= radioStations.Count)
            {
                currentStation = 0;
            }
        }
        else
        {
            currentStation -= 1;
            if (currentStation < 0)
            {
                currentStation = radioStations.Count - 1;
            }
        }

        PlayRadio();
    }
}