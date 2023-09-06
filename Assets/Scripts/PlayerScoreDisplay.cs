using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreDisplay : MonoBehaviour
{
    public RectTransform parentRect;
    float parentHeight;
    bool firstTime = true;
    public GameObject playerScorePrefab;
    public PlayerDatabase newList;

    void Start()
    {
        LoadXML();
        GetCurrentParentHeight();
        Display();
    }
    void GetCurrentParentHeight()
    {
        parentHeight = parentRect.sizeDelta.y;
    }
    public void Display()
    {
        if (XMLManager.instance.PlayerDataBase.list != null) //somehow returning error when nothing is on the list (which it is to start)
        {
            CleanScoreList();
            SortScoreList();
            foreach (PlayerEntry item in XMLManager.instance.PlayerDataBase.list)
            {
                //Instantiate new ScoreBlock
                GameObject newScore = Instantiate(playerScorePrefab);// as PlayerScoreBlock;
                newScore.transform.SetParent(parentRect.transform, false);
                newScore.GetComponent<PlayerScoreBlock>().Display(item);

                //Remember to resize Height of Scroll Panel by +35 1st time, +85 every following time
                if (firstTime)
                {
                    firstTime = false;
                    parentHeight += 35;
                }
                else
                    parentHeight += 85;
                parentRect.sizeDelta = new Vector2(800, parentHeight);
            }
        }
    }
    void LoadXML()
    {
        XMLManager.instance.LoadEntries();
    }
    void CleanScoreList()
    {
        foreach (Transform child in parentRect)
        {
            GameObject.Destroy(child.gameObject);
        }
        parentHeight = 0;
        parentRect.sizeDelta = new Vector2(800, parentHeight);
    }
    void SortScoreList()
    {
        newList = new PlayerDatabase();

        foreach (PlayerEntry item in XMLManager.instance.PlayerDataBase.list)
        {
            newList.list.Add(item);
        }
        SortList();

        XMLManager.instance.PlayerDataBase.list = newList.list;
    }
    void SortList()
    {
        newList.list.Sort(SortFunc);
    }
    int SortFunc(PlayerEntry a, PlayerEntry b)
    {
        //Rank by Highest Score, If tie then lowest time, otherwise pass by value
        if (a.playerScore > b.playerScore)
            return -1;
        else if (a.playerScore == b.playerScore)
        {
            if (a.playerTime < b.playerTime)
                return -1;
        }
        else if (a.playerScore < b.playerScore)
            return 1;
        return 0;
    }
}
