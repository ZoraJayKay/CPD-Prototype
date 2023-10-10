using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource[] tracks;
    //public GameObject[] fxTracks;
    //private AudioSource[] sfxTracks;
    public AudioSource currentSource;
    public AudioSource potionCompleteSound;
    public AudioSource pickupSound;
    public AudioSource buttonPressSound;
    public AudioSource dragCommenceSound;
    public AudioSource dropItemSound;
    public AudioSource openInventorySound; // This sound is from ZapSplat.com


    public int trackSelector;

    public int trackHistory;

    private void Start()
    {
        // Have a default track before anything else is calculated
        currentSource = tracks[Random.Range(0, tracks.Length)];
        currentSource.Play();        
        //fxTracks = GameObject.FindGameObjectsWithTag("FXMusic");
    }

    private void Update()
    {
        if (currentSource.isPlaying == false)
        {
            while (trackSelector == trackHistory)
            {
                trackSelector = Random.Range(0, tracks.Length);
            }

            PickTrack(trackSelector);
        }
    }

    private void PickTrack(int track)
    {
        switch (track)
        {
            case 0:
            tracks[0].Play();
            tracks[0].volume = currentSource.volume;
            currentSource = tracks[0];
            trackHistory = 0;
            break;

            case 1:
            tracks[1].Play();
            tracks[1].volume = currentSource.volume;
            currentSource = tracks[1];
            trackHistory = 1;
            break;

            case 2:
            tracks[2].Play();
            tracks[2].volume = currentSource.volume;
            currentSource = tracks[2];
            trackHistory = 2;
            break;

            case 3:
            tracks[3].Play();
            tracks[3].volume = currentSource.volume;
            currentSource = tracks[3];
            trackHistory = 3;
            break;

            case 4:
            tracks[4].Play();
            tracks[4].volume = currentSource.volume;
            currentSource = tracks[4];
            trackHistory = 4;
            break;
        }
    }
}
