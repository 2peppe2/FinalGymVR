using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class whenToBreakStuff : MonoBehaviour
{
    bool startTime = false;
    private bool isCoroutineExecuting = false, isCoroutineExecuting2 = false, isCoroutineExecuting3 = false;
    private bool delayDone = false, delayDone2 = false, delayDone3 = false;
    public UnityEvent pipeBreak, skrapanBreak, uvBreak;
    int time;
    //ska starta på 0
    int whosTurn = 0;
    bool doneOnce = false, donetwice = false, donetrice = false;
    // Start is called before the first frame update
    void Start()
    {
        Random random = new Random();
        startDoomCounter();
    }

    // Update is called once per frame
    void Update()
    {
        // Lets's fuck up this place
        if (startTime)
        {
            if(whosTurn == 0)
            {
                StartCoroutine(ExecuteAfterTime(time));
            }
            else if (whosTurn == 1)
            {
                StartCoroutine(ExecuteAfterTime2(time));
            }
            else if (whosTurn == 2)
            {
                StartCoroutine(ExecuteAfterTime3(time));
            }

        }
        if (delayDone)
        {
            if (doneOnce == false)
            {
                pipeBreak.Invoke();
                doneOnce = true;
                whosTurn++;
                startTime = false;
            }

        }else if (delayDone2)
        {
            if( donetwice == false)
            {
                skrapanBreak.Invoke();
                donetwice = true;
                whosTurn++;
                startTime = false;

            }
        }
        else if (delayDone3)
        {
            if(donetrice == false)
            {
                uvBreak.Invoke();
                donetrice = true;
                whosTurn++;
                startTime = false;
            }
        }
            
    }

    public void startDoomCounter()
    {
        //ändra tiden
        time = Random.Range(2, 3); 
        startTime = true;
        
    }

    public void DoomCleard()
    {
        

        startDoomCounter();

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

    IEnumerator ExecuteAfterTime2(float time)
    {
        if (isCoroutineExecuting2)
            yield break;
        isCoroutineExecuting2 = true;
        yield return new WaitForSeconds(time);
        delayDone2 = true;
        isCoroutineExecuting2 = false;
    }

    IEnumerator ExecuteAfterTime3(float time)
    {
        if (isCoroutineExecuting3)
            yield break;
        isCoroutineExecuting3 = true;
        yield return new WaitForSeconds(time);
        delayDone3 = true;
        isCoroutineExecuting3 = false;
    }
}
