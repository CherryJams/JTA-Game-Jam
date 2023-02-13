using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RadioStation : MonoBehaviour
{
    public Sprite stationSprite;

    [HideInInspector] public AudioSource audioSource;

    // Start is called before the first frame update
    public List<AudioClip> stationClips;
    List<AudioClip> currentStationClips;
    public AudioClip currentClip;
    public int currentClipNumber;
    public bool isCurrentRadio;
    public bool isRadioStopped;
    [HideInInspector] public float waitTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShuffleRadio();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCurrentRadio && !isRadioStopped)
        {
            waitTime -= 1 * Time.deltaTime;
            if (waitTime <= 0)
            {
                audioSource.Stop();
                ShuffleRadio();
                isRadioStopped = true;
            }
        }

        if (!isRadioStopped)
        {
            if (!audioSource.isPlaying)
            {
                currentClipNumber += 1;
                if (currentClipNumber >= currentStationClips.Count)
                {
                    currentClipNumber = 0;
                }

                currentClip = currentStationClips[currentClipNumber];
                audioSource.clip = currentClip;
                audioSource.Play();
            }
        }
    }

    public void ShuffleRadio()
    {
        currentStationClips = stationClips;
        List<int> numbersTaken = new List<int>();
        for (int i = 0; i < stationClips.Count; i++)
        {
            bool isNext = false;
            while (!isNext)
            {
                int newNumber = Random.Range(0, stationClips.Count);
                if (!numbersTaken.Contains(newNumber))
                {
                    currentStationClips[i] = stationClips[newNumber];
                    isNext = true;
                }
            }

            {
            }
        }
    }
}