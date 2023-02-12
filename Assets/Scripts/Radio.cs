using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public List<RadioStation> radioStations;

    public int currentStation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayRadio()
    {
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
    }
}