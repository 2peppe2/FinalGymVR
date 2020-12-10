using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class whenToBreakStuff : MonoBehaviour
{
    bool startTime = false;
    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
    int time;
    int whosTurn = 0;
    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            StartCoroutine(ExecuteAfterTime(time));
        }
        if(delayDone)
        {
            // Lets's fuck up this place
            switch (whosTurn)
            {
                case 0: //pipe
                    break;
                case 1: //skrapan
                    break;
                case 2: //uv
                    break;
            }

        }
    }

    public void startDoomCounter()
    {
        time = Random.Range(20, 300); 
        startTime = true;
        
    }

    public void DoomCleard()
    {

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        delayDone = true;
        isCoroutineExecuting = false;
    }
}
