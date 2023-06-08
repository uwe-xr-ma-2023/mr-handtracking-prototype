using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{


    public void ChooseScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   
}
