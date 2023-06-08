using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHideShow : MonoBehaviour
{
    public GameObject waveGameObject;
    private float timeToShowWave = 45.0f;
    private float timeToHideWave = 73.0f;
    // Start is called before the first frame update
    void Start()
    {
        waveGameObject.SetActive(false);
        StartCoroutine(ShowWave());
    }

    // Update is called once per frame
    IEnumerator ShowWave()
    {
        yield return new WaitForSeconds(timeToShowWave);
        waveGameObject.SetActive(true);
        StartCoroutine(HideWave());
    }
    IEnumerator HideWave()
    {
        yield return new WaitForSeconds(timeToHideWave - timeToShowWave);
        waveGameObject.SetActive(false);

    }

}
