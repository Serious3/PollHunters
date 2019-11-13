using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject pauseMenu;
    public GameObject pollUI;

    public void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://poll-hunters.firebaseio.com");
    }

    public void ReturnToGame()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        inGameUI.SetActive(true);
    }

    public void ShowPoll(string stopName)
    {
        print(stopName);
        FirebaseDatabase.DefaultInstance
            .GetReference("poll-hunters/Polls").Child(stopName).LimitToFirst(1)
            .GetValueAsync().ContinueWith(task => {
                pollUI.SetActive(true);
                inGameUI.SetActive(false);
                
                print("Finished task");
                
                if (task.IsFaulted) {
                    print("Task failed");
                }
                else if (task.IsCompleted) {
                    var snapshot = task.Result;
                    print(snapshot.GetValue(true).ToString());
                }
            });
    }

    public void ShowOptions()
    {
        pauseMenu.SetActive(true);
        inGameUI.SetActive(false);
    }
}
