using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisionWithHands : MonoBehaviour
{
    private AudioSource audioSource;
    private Renderer _renderer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _renderer = GetComponent<Renderer>();
    }

    public void OnHoverBegin()
    {
        audioSource.Play();
        _renderer.enabled = false;
        StartCoroutine(WaitForAudioEnd());
        
    }

    IEnumerator WaitForAudioEnd()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Destroy(gameObject);
    }
}
