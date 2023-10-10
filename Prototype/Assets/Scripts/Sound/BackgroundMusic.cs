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
    public AudioSource closeInventorySound; // This sound is from ZapSplat.com
    public AudioSource potionGivenToVillagerSound; 
    public AudioSource rejectionSound;


    public int trackSelector;

    public int trackHistory;

    private void Start()
    {
        // Have a default track before anything else is calculated
        currentSource = tracks[Random.Range(0, tracks.Length)];
        currentSource.Play();
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
        tracks[track].Play();
        tracks[track].volume = currentSource.volume;
        currentSource = tracks[track];
        trackHistory = track;
    }

    public void OpenOrCloseInventory(bool isOpening)
    {
        if (isOpening)
        {
            openInventorySound.Play();
        }
        else
        {
            closeInventorySound.Play();
        }
    }
}
