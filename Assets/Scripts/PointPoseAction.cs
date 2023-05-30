using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPoseAction : MonoBehaviour
{
    private AudioSource audioSource;
    public TrailRenderer trailRenderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        trailRenderer.enabled = false;
    }
    public void OnPoseStart()
    { 
        Debug.Log("Point Pose started");
        audioSource.Play();
        trailRenderer.enabled = true;
    }

    public void OnPoseEnd()
    {
        Debug.Log("Point Pose ended");
        audioSource.Play();
        trailRenderer.enabled = false;
        trailRenderer.Clear();
    }
}
