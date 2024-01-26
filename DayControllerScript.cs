using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DayControllerScript : MonoBehaviour
{
    int currentActivity;
    [SerializeField] GameObject[] activityTriggers;


    void Start()
    {
        currentActivity = PlayerPrefs.GetInt("CurrentActivity", 0);

        if (currentActivity == activityTriggers.Length)
        {
            LoadNextScene();
        }

        EnableTask();
    }


    public void TaskFinished()
    {
        activityTriggers[currentActivity].SetActive(false);

        currentActivity++;

        if(currentActivity == activityTriggers.Length)
        {
            LoadNextScene();
        }

        PlayerPrefs.SetInt("CurrentActivity", currentActivity);
        EnableTask();
    }


    void EnableTask()
    {
        activityTriggers[currentActivity].SetActive(true);
    }


    void LoadNextScene()
    {
        PlayerPrefs.SetInt("CurrentActivity", 0);
        PlayerPrefs.Save();

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        currentScene++;

        if (currentScene > 5)
        {
            currentScene = 0;
        }

        SceneManager.LoadScene(currentScene);
    }
}
