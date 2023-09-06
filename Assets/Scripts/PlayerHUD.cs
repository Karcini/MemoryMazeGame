using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHUD : MonoBehaviour
{
    public GameObject player;
    Abilities playerAbilities;

    public Text timerText;
    float timer = 0f;

    public Text spiritFormText;

    public Text pickRemaningText;

    public Text trueSightText;

    public Text openDoorText;

    public Text coinText;

    public Text consoleTutorialText;
    public Button yesButton;
    public Button noButton;


    void Start()
    {
        playerAbilities = player.GetComponent<Abilities>();
        if (FirstLevel())
        {
            Intro();
            ActivateTutorialUI();
        }
    }
    void Update()
    {
        spiritFormText.text = "Spirit Form Uses : " + playerAbilities.spiritFormSight;
        pickRemaningText.text = "Picks Remaining : " + playerAbilities.picks;
        coinText.text = "Coins = " + ScoreManager.instance.PlayerPoints;

        if (playerAbilities.trueSightAvailable)
            trueSightText.gameObject.SetActive(true);
        else
            trueSightText.gameObject.SetActive(false);

        if (playerAbilities.canOpenDoor)
            openDoorText.gameObject.SetActive(true);
        else
            openDoorText.gameObject.SetActive(false);

        if (ScoreManager.instance.TimeActivated)
        {
            timer += Time.deltaTime;
            ScoreManager.instance.LevelTime = Mathf.Round(timer * 100f) / 100f;
            timerText.text = ScoreManager.instance.LevelTime + "s";
        }
    }
    public void ButtonYes()
    {
        Tutorial();
        RemoveTutorialUI();
    }
    public void ButtonNo()
    {
        RemoveTutorialUI();
    }
    void RemoveTutorialUI()
    {
        consoleTutorialText.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }
    void ActivateTutorialUI()
    {
        consoleTutorialText.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }
    void Intro()
    {
        Debug.Log("Hello, Welcome to My Maze MicroGame!");
        Debug.Log("You are a mage who wants to reach the other side of this Dreadful Maze.  " +
            "Feel free to look and walk around, there are objects placed at the start to try.  " +
            "The Maze randomly generates these.");
    }
    void Tutorial()
    {
        Debug.Log("The following explain the game mechanics...");
        Debug.Log("'Q' Allows you to use SpiritForm and get a birds eye view of your environment.  Careful, you're limited to 5 uses.");
        Debug.Log("'E' Allows you to pull down levers to open doors.");
        Debug.Log("Be on the look out of Blue Beams of Light, Red Mist and Pickaxes as they are randomly generated throughout the map!");
        Debug.Log("You automatically use the energy from Blue Beams to fly up and momentarily get an eagle eye's view.");
        Debug.Log("If you find Red Mist, Pressing 'R' temporarily grants you the ability to see through all walls.  Red Mist is quite rare.");
        Debug.Log("'F' Equips your pickaxe which can be used to ram down single wall.  Use them wisely because they are scarce.");
    }
    bool FirstLevel()
    {
        string level = SceneManager.GetActiveScene().name;
        if(level == "Maze1")
            return true;
        return false;
    }
}
