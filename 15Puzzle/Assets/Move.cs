using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 dest = new Vector3(1, 0, 0);

    PuzzleManager puzzle;

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        puzzle = GameObject.Find("Grid").GetComponent<PuzzleManager>();
        //slideIfYouCan();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = dest - transform.position;
        Vector3 step = delta.normalized * Time.deltaTime;

        if (step.magnitude < delta.magnitude)
        {
            transform.position += step;
        }
        else
        {
            transform.position = dest;
        }
    }
    private void OnMouseDown()
    {
        if(!puzzle.isShuffling())
        slideIfYouCan();
    }
    public void slideIfYouCan()
    {
        if (transform.position != dest)
            return;
        Vector3 rightDest = transform.position + new Vector3(1, 0, 0);
        Vector3 leftDest = transform.position + new Vector3(-1, 0, 0);
        Vector3 upDest = transform.position + new Vector3(0, 1, 0);
        Vector3 downDest = transform.position + new Vector3(0, -1, 0);

        if (puzzle.isEmptySpot(rightDest) && transform.position.x <= 2)
            dest = rightDest;
        else if (puzzle.isEmptySpot(leftDest) && transform.position.x >= 1)
            dest = leftDest;
        else if (puzzle.isEmptySpot(upDest) && transform.position.y <= 2)
            dest = upDest;
        else if (puzzle.isEmptySpot(downDest) && transform.position.y >= 1)
            dest = downDest;

    }
}
