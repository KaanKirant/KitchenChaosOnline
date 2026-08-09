using System;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{
    private void Start()
    {
        GameManagerMultiplayer.Instance.OnTryingToJoinGame += GameManagerMultiplayer_OnTryingToJoinGame;
        GameManagerMultiplayer.Instance.OnFailedToJoinGame += GameManagerMultiplayer_OnFailedToJoinGame;
        Hide();
    }

    private void GameManagerMultiplayer_OnFailedToJoinGame(object sender, EventArgs e)
    {
        Hide();
    }

    private void GameManagerMultiplayer_OnTryingToJoinGame(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManagerMultiplayer.Instance.OnTryingToJoinGame -= GameManagerMultiplayer_OnTryingToJoinGame;
        GameManagerMultiplayer.Instance.OnFailedToJoinGame -= GameManagerMultiplayer_OnFailedToJoinGame;
    }
}