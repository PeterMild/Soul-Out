using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class levelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;
    [SerializeField] private Transform levelPart_2;
    [SerializeField] private Transform levelPart_3;
    [SerializeField] private Transform levelPart_4;
    /*[SerializeField] private Transform levelPart_5;
    [SerializeField] private Transform levelPart_6;
    [SerializeField] private Transform levelPart_7;
    [SerializeField] private Transform levelPart_8;
    [SerializeField] private Transform levelPart_9;
    [SerializeField] private Transform levelPart_10;
    [SerializeField] private Transform levelPart_11;*/
    
    //[SerializeField] private Player player;
    public Vector3 GetPosition() { return transform.position; }

    int randomNum;



    private Vector3 lastEndPosition;


    private void Awake()
    {
        
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 7;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            PickRandomNumber();
            if(randomNum == 1)
            {
                SpawnLevelPart();
            }
            else if(randomNum == 2)
            {
                SpawnLevelPart2();
            }
            else if (randomNum == 3)
            {
                SpawnLevelPart3();
            }
            else if (randomNum == 4)
            {
                SpawnLevelPart4();
            }
            /*else if (randomNum == 5)
            {
                SpawnLevelPart5();
            }
            else if (randomNum == 6)
            {
                SpawnLevelPart6();
            }
            else if (randomNum == 7)
            {
                SpawnLevelPart7();
            }
            else if (randomNum == 8)
            {
                SpawnLevelPart8();
            }
            /*else if (randomNum == 9)
            {
                SpawnLevelPart9();
            }
            else if (randomNum == 10)
            {
                SpawnLevelPart10();
            }
            else if (randomNum == 11)
            {
                SpawnLevelPart11();
            }*/


        }

    }
    private void Update()
    {
        if (Vector3.Distance(GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
        if (Vector3.Distance(GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart2();
        }


    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
           Transform LevelPartTransform = Instantiate(levelPart_1, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart2()
    {
        Transform lastLevelPartTransform = SpawnLevelPart2(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart2(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_2, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void PickRandomNumber()
    {
        randomNum = Random.Range(1, 4);
    }

    private void SpawnLevelPart3()
    {
        Transform lastLevelPartTransform = SpawnLevelPart3(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart3(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_3, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart4()
    {
        Transform lastLevelPartTransform = SpawnLevelPart4(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart4(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_4, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    /*private void SpawnLevelPart5()
    {
        Transform lastLevelPartTransform = SpawnLevelPart5(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart5(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_5, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart6()
    {
        Transform lastLevelPartTransform = SpawnLevelPart6(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart6(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_6, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart7()
    {
        Transform lastLevelPartTransform = SpawnLevelPart7(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart7(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_7, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart8()
    {
        Transform lastLevelPartTransform = SpawnLevelPart8(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart8(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_8, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    /*private void SpawnLevelPart9()
    {
        Transform lastLevelPartTransform = SpawnLevelPart9(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart9(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_9, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart10()
    {
        Transform lastLevelPartTransform = SpawnLevelPart10(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart10(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_10, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }

    private void SpawnLevelPart11()
    {
        Transform lastLevelPartTransform = SpawnLevelPart11(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart11(Vector3 spawnPosition)
    {
        Transform LevelPartTransform = Instantiate(levelPart_11, spawnPosition, Quaternion.identity);
        return LevelPartTransform;
    }*/

























}
