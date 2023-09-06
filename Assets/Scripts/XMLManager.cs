using System.Collections;
using System.Collections.Generic;   //lists
using UnityEngine;
using System.Xml;                   //basic xml attributes
using System.Xml.Serialization;     //access xml serializer
using System.IO;                    //file management

//Currently does not actually make an XML file, saves all data to List
public class XMLManager : MonoSingleton<XMLManager>
{
    //Some sort of singleton
    //public static XMLManager xml;

    [SerializeField]
    private PlayerDatabase _playerDB;

    public PlayerDatabase PlayerDataBase
    {
        get { return _playerDB; }
        set { _playerDB = value; }
    }
    public override void Init()
    {
        //_playerDB = new PlayerDatabase();
    }
    public void SaveEntries()
    {
        //Open a new XML file and Overwrite it
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/entry_data.xml", FileMode.Create);

        //Take info from unity class into XML file
        serializer.Serialize(stream, _playerDB);

        //Close stream
        stream.Close();
    }
    public void LoadEntries()
    {
        //Open a new XML file and Open it
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/entry_data.xml", FileMode.Open);

        //Check if file exists

        //Load info from xml into unity class
        _playerDB = serializer.Deserialize(stream) as PlayerDatabase;

        //Close stream
        stream.Close();
    }
}

//We want to make PlayerEntries to save into _playerDB via this Singleton
[System.Serializable]
public class PlayerEntry
{
    public string playerName;
    public float playerTime;
    public int playerScore;
}
[System.Serializable]
public class PlayerDatabase
{
    [XmlArray("PlayerScoreRecords")]
    public List<PlayerEntry> list = new List<PlayerEntry>();
}
