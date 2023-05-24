using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThumbsUpAction : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnDetection()
    { Debug.Log("Thumb Pose detected");
        //Fetch the AudioSource from the GameObject
        audioSource.Play();
    }
}
