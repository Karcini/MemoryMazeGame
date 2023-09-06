using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public InputField playerName;

    void Start()
    {
        FreshGame();
        XMLManager.instance.LoadEntries();
    }
    public void StartGameButton()
    {
        ScoreManager.instance.PlayerName = playerName.text;
        SceneManager.LoadScene(sceneName: "Maze1");
    }
    void FreshGame()
    {
        ScoreManager.instance.ResetScore();
        ScoreManager.instance.ResetEquipment();
    }
}
