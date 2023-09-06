using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishLine : MonoBehaviour
{
    bool finished = false;
    [SerializeField]
    Text winTextUI;
    enum Levels
    {
        Maze1,
        Maze2,
        EndScreen
    }
    [SerializeField]
    Levels level;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!finished)
            {
                finished = true;
                SwitchTimer();
                SaveLevelTime();
                YouWin();
                Reset();

                //Save Data IF we are entering EndScreen Scene
                if (CheckIfFinalMaze())
                    TabulateScores();

                LoadNextScene();  //Might be extraneous code
            }
        }
    }
    void SaveLevelTime()
    {
        ScoreManager.instance.PlayerTime += ScoreManager.instance.LevelTime;
    }
    void SwitchTimer()
    {
        if (ScoreManager.instance.TimeActivated)
            ScoreManager.instance.TimeActivated = false;
        else
            ScoreManager.instance.TimeActivated = true;
    }
    void YouWin()
    {
        //UI to prompt player winning
        winTextUI.gameObject.SetActive(true);
        StartCoroutine("LoadNextScene");
    }
    bool CheckIfFinalMaze()
    {
        if(level == Levels.EndScreen)
            return true;
        return false;
    }
    void TabulateScores() //Adds the CURRENT Scoremanager Data onto a NEW player entry "Save File"
    {
        Debug.Log("Scores were tabulated");
        PlayerEntry newEntry = new PlayerEntry();
        newEntry.playerName = ScoreManager.instance.PlayerName;
        newEntry.playerTime = ScoreManager.instance.PlayerTime;
        newEntry.playerScore = ScoreManager.instance.PlayerPoints;

        //Check if Database is null
        if (XMLManager.instance.PlayerDataBase == null)
            XMLManager.instance.PlayerDataBase = new PlayerDatabase();
        //Add Entry to XMLmanager and Save to XML file
        XMLManager.instance.PlayerDataBase.list.Add(newEntry); //
        XMLManager.instance.SaveEntries();

        //Restart Player info in ScoreManager
        //ScoreManager.instance.ResetScore();
        //ScoreManager.instance.ResetEquipment();
    }
    void Reset()
    {
        SpawnObjectStatics.ResetSpawnObjects();
    }

    IEnumerator LoadNextScene()
    {
        float timer = 0f;
        float timerWait = 3f;
        while(timer < timerWait)
        {
            timer += Time.deltaTime;
            yield return 0;
        }
        //Remove win text
        winTextUI.gameObject.SetActive(false);
        //Turn off BGMusic
        SoundManager.instance.BGMusicStop();
        //Load Next Scene
        PickScene();
    }

    void PickScene()
    {
        switch ((int)level)
        {
            case (int)Levels.Maze1:
                SceneManager.LoadScene(sceneName: "Maze1");
                break;
            case (int)Levels.Maze2:
                SceneManager.LoadScene(sceneName: "Maze2");
                break;
            case (int)Levels.EndScreen:
                SceneManager.LoadScene(sceneName: "EndScreen");
                break;
        }
    }
}
