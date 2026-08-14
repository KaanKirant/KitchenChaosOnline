using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playMultiplayerButton;
    [SerializeField] private Button playSingleplayerButton;
    [SerializeField] private Button quitButton; 

    private void Awake()
    {
        playMultiplayerButton.onClick.AddListener(() =>
        {
            GameManagerMultiplayer.playMultiplayer = true;
            Loader.Load(Loader.Scene.LobbyScene);
        });

        playSingleplayerButton.onClick.AddListener(() =>
        {
            GameManagerMultiplayer.playMultiplayer = false;
            Loader.Load(Loader.Scene.LobbyScene);
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }
}
