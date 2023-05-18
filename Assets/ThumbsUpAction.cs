using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbsUpAction : MonoBehaviour
{
    public AudioSource audioSource;
    public void OnDetection()
    { Debug.Log("Thumb Pose detected");
        //Fetch the AudioSource from the GameObject
        audioSource.Play();
    }
}
