using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public float shuffleTime = 2;

    Vector3[] startPositions;

    private void Start()
    {
        startPositions = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            startPositions[i] = transform.GetChild(i).position;
        }
    }

    void Update()
    {
        if (isShuffling())
        {
            //Random shuffles
            Transform tile = transform.GetChild(Random.Range(0, transform.childCount));
            tile.GetComponent<Move>().slideIfYouCan();
        }
        else
        {
            //Win check
            bool isWin = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                if (startPositions[i] != transform.GetChild(i).position)
                    isWin = false;
            }
            if (isWin)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).localScale = new Vector3(1, 1, 1);
                }
                Time.timeScale = 0; //stop time (pause game)
            }
        }
    }

    public bool isShuffling()
    {
        if (Time.time < shuffleTime)
            return true;
        else
            return false;
    }

    public bool isEmptySpot(Vector3 pos)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Move>().dest == pos)
                return false;
        }
        return true;
    }
}
