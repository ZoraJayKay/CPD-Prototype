//using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// A UI to display the member variables of a Settings object (may be a MonoBehaviour or a ScriptableObject) to the player as sliders

public class SettingsUI : MonoBehaviour
{
    // +++++++++ IMPLEMENTATION WITH FloatEditor OBJECTS +++++++++
    public FloatEditor musicVolume;
    public FloatEditor fxVolume;
    private GameObject musicObject;
    private BackgroundMusic music;
    private AudioSource backgroundMusic;

    // ********* IMPLEMENTATION WITH SLIDER OBJECTS ********* 
    //public Slider musicVolumeSlider;
    //public Slider soundFxVolumeSlider;



    // A settings object from which to obtain back-end music and FX values
    public Settings settings;


    private void Start()
    {
        musicObject = GameObject.FindWithTag("Music");
        music = GameObject.FindWithTag("Music").GetComponent<BackgroundMusic>();
        // Get the track that's currently playing

        //backgroundMusic.volume = settings.musicVolume;
        //music.potionCompleteSound.volume = settings.soundFxVolume;
        //music.pickupSound.volume = settings.soundFxVolume;
        //music.buttonPressSound.volume = settings.soundFxVolume;
        //music.dragCommenceSound.volume = settings.soundFxVolume;
        //music.dropItemSound.volume = settings.soundFxVolume;
        //music.openInventorySound.volume = settings.soundFxVolume;


        if (musicVolume)
        {
            // Inherit the sound volume set by the Inspector
            musicVolume.floatValue = settings.musicVolume;
            

            // Listen out for any changes to the value of the slider bar in the Settings menu
            musicVolume.onValueChanged.AddListener((float value) =>
            {
                // And when the slider bar value changes...
                backgroundMusic = music.currentSource;
                settings.musicVolume = value;
                backgroundMusic.volume = value / 100;
            });
        }

        if (fxVolume)
        {
            // Inherit the sound volume set by the Inspector
            fxVolume.floatValue = settings.soundFxVolume;
            

            // Listen out for any changes to the value of the slider bar in the Settings menu
            fxVolume.onValueChanged.AddListener((float value) =>
            {
                // And when the slider bar value changes...
                settings.soundFxVolume = value;
                music.potionCompleteSound.volume = value / 100;
                music.pickupSound.volume = value / 100;
                music.buttonPressSound.volume = value / 100;
                music.dragCommenceSound.volume = value / 100;
                music.dropItemSound.volume = value / 100;
                music.openInventorySound.volume = value / 100;
            });
        }

        // ********* IMPLEMENTATION WITH SLIDER OBJECTS ********* 
        // Add an event listener that listens for the OnMusicVolumeChanged function
        //musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        //soundFxVolumeSlider.onValueChanged.AddListener(OnFxVolumeChanged);

        //// Alternatively, add a C# lambda function for the same effect
        //musicVolumeSlider.onValueChanged.AddListener(
        //    (float value) => { settings.musicVolume = value; });
    }

    // Any time the music volume gets changed, pass the change back to the Settings object
    //public void OnMusicVolumeChanged(float volume)
    //{
    //    // Make the float value of the Settings object equal to any passed in value
    //    settings.musicVolume = volume;

    //    backgroundMusic = music.currentSource;
    //    //print(backgroundMusic.name);

    //    backgroundMusic.volume = settings.musicVolume;
    //}

    //// Any time the fx volume gets changed, pass the change back to the Settings object
    //public void OnFxVolumeChanged(float volume)
    //{
    //    // Make the float value of the Settings object equal to any passed in value
    //    settings.soundFxVolume = volume;

    //    music.potionCompleteSound.volume = settings.soundFxVolume / 100;
    //    music.pickupSound.volume = settings.soundFxVolume / 100;
    //    music.buttonPressSound.volume = settings.soundFxVolume / 100;
    //    music.dragCommenceSound.volume = settings.soundFxVolume / 100;
    //    music.dropItemSound.volume = settings.soundFxVolume / 100;
    //}
}
