using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Radio : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public List<RadioStation> radioStations;
    public int currentStation;
    public float waitBeforeOff = 15;

    // Start is called before the first frame update
    void Start()
    {
        PlayRadio();
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
                radioStations[i].audioSource.volume = 0;
                radioStations[i].waitTime = waitBeforeOff;
                radioStations[i].isCurrentRadio = false;
            }
        }

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