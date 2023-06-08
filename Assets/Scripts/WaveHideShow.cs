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
        StartCoroutine(WaitForShowWave());
    }

    // Update is called once per frame
    IEnumerator WaitForShowWave()
    {
        yield return new WaitForSeconds(timeToShowWave);
        ShowWave();
    }
    IEnumerator WaitForHideWave()
    {
        yield return new WaitForSeconds(timeToHideWave - timeToShowWave);
        waveGameObject.SetActive(false);

    }

    private void ShowWave()
    {
        waveGameObject.SetActive(true);
        StartCoroutine(WaitForHideWave());
    }

    public void SkipToWaveShow()
    {
        StopAllCoroutines();
        ShowWave();
    }

    public float GetTimeToShowWave()
    {
        return timeToShowWave;
    }

}
