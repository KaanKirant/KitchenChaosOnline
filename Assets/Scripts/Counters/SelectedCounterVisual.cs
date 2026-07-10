using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArray;

    private void Start()
    {
        if(Player.LocalInstance != null)
        {
            Player.LocalInstance.OnSelectCounterChanged += Player_OnSelectCounterChanged;
        }
        else
        {
            Player.OnAnyPlayerSpawn += Player_OnAnyPlayerSpawn;
        }
    }

    private void Player_OnAnyPlayerSpawn(object sender, System.EventArgs e)
    {
        if (Player.LocalInstance != null)
        {
            Player.LocalInstance.OnSelectCounterChanged -= Player_OnSelectCounterChanged;

            Player.LocalInstance.OnSelectCounterChanged += Player_OnSelectCounterChanged;
        }
    }

    private void Player_OnSelectCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.selectedCounter == baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
