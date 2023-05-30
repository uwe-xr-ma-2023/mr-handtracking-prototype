using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPoseAction : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnPoseStart()
    { 
        Debug.Log("Point Pose started");
        audioSource.Play();
    }

    public void OnPoseEnd()
    {
        Debug.Log("Point Pose ended");
        audioSource.Play();
    }
}
