using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerWp1 : MonoBehaviour
{
    public AudioSource sceneAudio;
    public WaveHideShow waveHideShow;
    private float timeToShowWave;

    private void Start()
    {
        timeToShowWave = waveHideShow.GetTimeToShowWave();
    }

    public void SkipToWaveShow()
    {
        sceneAudio.time = timeToShowWave;
        waveHideShow.SkipToWaveShow();
    }
}
