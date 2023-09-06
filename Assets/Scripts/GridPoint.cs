using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gets a reference to all its feeler Children
    //Creates a roof if they are all true
    //May be further used to implement enemy path finding in future
public class GridPoint : MonoBehaviour
{
    //feelers made public to show in Inspector, initialized within script
    public GameObject[] feelers = new GameObject[4];
    public GameObject roof;
    public GameObject eaglePads;
    public GameObject trueSightMist;
    public GameObject picks;
    public GameObject coins;

    public bool generated = false;
    public bool FourWallsDetected; //public for debugging purposes
    //For Reference: SpawnObjectStatics  {amountEaglePads = 3, amountTrueSightMist = 2, amountPicks = 1}
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        DetectRoof();
        StartCoroutine(GenerateObjects());
    }
    //ROOF CLOSED GRIDS ================
    void DetectRoof()
    {
        //Create a roof if all feelers detect a wall
        FourWallsDetected = true;

        for (int x = 0; x < feelers.Length; x++)
        {
            FourWallsDetected = CheckCollision(feelers[x]);

            if (FourWallsDetected == false)
                x = feelers.Length;
        }

        if (FourWallsDetected)
        {
            //Enclosed Room: Create a Roof, Get rid of GridPoint
            CreateRoof();
            Destroy(this.gameObject);
        }
    }
    void CreateRoof()
    {
        float distToRoof = 1.75f;
        Vector3 roofPosition = transform.position + new Vector3(0, distToRoof, 0);

        Instantiate(roof, roofPosition, Quaternion.identity);
    }
    bool CheckCollision(GameObject feel)
    {
        if(feel.GetComponent<Feeler>().collided)
            return true;

        else
            return false;
    }

    //GENERATE RANDOM OBJECTS ================
    IEnumerator GenerateObjects()
    {
        yield return new WaitForSeconds(2f);
        GenerateRandomPad();
        GenerateRandomMist();
        GenerateRandomPick();
        GenerateRandomCoin();
    }
    void GenerateRandomPad()
    {
        if (SpawnObjectStatics.amountEaglePads > 0 && generated == false)
        {
            if (Randomizer(1))
            {
                SpawnObjectStatics.amountEaglePads -= 1;
                Instantiate(eaglePads, transform.position + new Vector3(0f, 18f, 0f), Quaternion.identity);
                generated = true;
            }
        }
    }
    void GenerateRandomMist()
    {
        if (SpawnObjectStatics.amountTrueSightMist > 0 && generated == false)
        {
            if (Randomizer(1))
            {
                SpawnObjectStatics.amountTrueSightMist -= 1;
                Instantiate(trueSightMist, transform.position + new Vector3(0f, -1.75f, 0f), Quaternion.identity);
                generated = true;
            }
        }
    }
    void GenerateRandomPick()
    {
        if (SpawnObjectStatics.amountPicks > 0 && generated == false)
        {
            if (Randomizer(1))
            {
                SpawnObjectStatics.amountPicks -= 1;
                Instantiate(picks, transform.position + new Vector3(0f, -2f, 0f), Quaternion.identity);
                generated = true;
            }
        }
    }

    void GenerateRandomCoin()
    {
        if (SpawnObjectStatics.amountCoins > 0 && generated == false)
        {
            if (Randomizer(7))
            {
                SpawnObjectStatics.amountCoins -= 1;
                Instantiate(coins, transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
                generated = true;
            }
        }
    }
    bool Randomizer(int chance)
    {
        int result = (int)Random.Range(0, 101);
        if (result < chance)
            return true;
        return false;
    }
}
