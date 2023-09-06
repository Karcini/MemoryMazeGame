using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    //Player Stats
    [SerializeField]
    private string _playerName;
    [SerializeField]
    private float _playerTime;
    [SerializeField]
    private bool _timeActivated;
    [SerializeField]
    private int _playerPoints;
    [SerializeField]
    private Abilities _player;

    //Player Equipment
    [SerializeField]
    private int _picks;
    [SerializeField]
    private int _spiritForm;


    //Player Stat Accessors
    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }
    public  float PlayerTime
    {
        get { return _playerTime; }
        set { _playerTime = value; }
    }
    public bool TimeActivated
    {
        get { return _timeActivated; }
        set { _timeActivated = value; }
    }
    public int PlayerPoints
    {
        get { return _playerPoints; }
        set { _playerPoints = value; }
    }

    //Player Equipment Accessors
    public int AmountPicks
    {
        get { return _picks; }
        set { _picks = value; }
    }
    public int AmountSpiritForm
    {
        get { return _spiritForm; }
        set { _spiritForm = value; }
    }

    //Other Player Related Stats
    float _levelTimer;
    public float LevelTime
    {
        get { return _levelTimer; }
        set { _levelTimer = value; }
    }

    //Return Abilities of Player
    public Abilities Player
    {
        get
        {
            if (_player == null)
            {
                _player = FindObjectOfType<Abilities>();
            }
            return _player;
        }
    }

    public override void Init()
    {
        //Player Stat Initializers
        _playerName = "";
        _playerTime = 0;
        _playerPoints = 0;
        _player = null;
        //Player Equipment Initializers
        _picks = 1;
        _spiritForm = 5;
        //Other
        _levelTimer = 0;
    }
    public void ResetScore()
    {
        _playerName = "";
        _playerTime = 0;
        _playerPoints = 0;
    }
    public void ResetEquipment()
    {
        _picks = 1;
        _spiritForm = 5;
    }
}
