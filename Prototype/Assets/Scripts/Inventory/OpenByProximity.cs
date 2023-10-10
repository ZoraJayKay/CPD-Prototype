using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

public class OpenByProximity : MonoBehaviour
{
    // The target whose distance we care about
    public GameObject player;
    Vector3 playerPos;

    // The things we'll turn on if the target gets close
    public GameObject[] objectsToTurnOn;
    
    // At what distance will we trigger the behaviour?
    public int detectionRange;

    // Is this object currently recognising and responding to proximity triggers?
    bool awakened = false;

    // Has the poroximity trigger been activated?
    bool _enteredProximity = false;

    // Object for proximity sounds
    private BackgroundMusic music;

    private void Start()
    {
        // Don't have this object respond to proximity triggers immediately (I only turn it on once the "Start game" button has been pushed so that other processes have had time to run, otherwise this script mucks up the UIpopulation and positioning of inventory UI elements because it turns them off before they've had a chance to create slots, shopitems, etc)
        awakened = false;

        // Listen out for any change in the boolean (NOT IMPLEMENTED)
        //this.onEnterOrLeaveProximity.AddListener((bool change) => { enteredProximity = change; });
                
        music = GameObject.FindWithTag("Music").GetComponent<BackgroundMusic>();
    }

    // I know that this should be an event but I'm out of time to implement it that way! 
    private void Update()
    {
        if (awakened == true)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < detectionRange)
            {
                if (_enteredProximity == false)
                {
                    print("Player has entered detection range");
                    foreach (GameObject obj in objectsToTurnOn)
                    {
                        _enteredProximity = true;
                        obj.SetActive(true);
                        music.openInventorySound.Play();
                    }
                }
            }

            else
            {
                if (_enteredProximity == false)
                {
                    foreach (GameObject obj in objectsToTurnOn)
                    {
                        _enteredProximity = false;
                        obj.SetActive(false);
                        //music.closeInventorySound.Play();
                    }
                }

                else if (_enteredProximity == true) 
                {
                    foreach (GameObject obj in objectsToTurnOn)
                    {
                        _enteredProximity = false;
                        obj.SetActive(false);
                        music.closeInventorySound.Play();
                    }
                }
            }
        }        
    }

    public void WakeUp()
    {
        awakened = true;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(this.transform.position, detectionRange);
    //}



    //bool enteredProximity
    //{
    //    get { return _enteredProximity; }

    //    set
    //    {
    //        // Conditionally toggle the back-end variable
    //        if (_enteredProximity == true)
    //        {
    //            _enteredProximity = false;
    //        }

    //        else { _enteredProximity = true; }



    //        //// Make sure all the controls are visually consistent
    //        //if (slider)
    //        //{
    //        //    slider.value = value;
    //        //}

    //        //if (input)
    //        //{
    //        //    input.text = value.ToString(formatString);
    //        //}

    //        // Update any client code that has registered with this event
    //        onEnterOrLeaveProximity.Invoke(_enteredProximity);
    //    }
    //}

    //// Make an event for recognising whether the player has entered or left the proximity, and play the appropriate sound (set in the inspector)
    //[System.Serializable]
    //public class BoolEvent : UnityEvent<bool> { }

    //// This creates a customisable Unity event for this script which we can edit in the Inspector
    //public BoolEvent onEnterOrLeaveProximity;
}
