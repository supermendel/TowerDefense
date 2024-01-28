using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertManager : MonoBehaviour
{
    public static AlertManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveAlert(string message)
    {
        // Handle the received alert, e.g., display it on the UI
        Debug.Log($"Alert received: {message}");
    }
}
