using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class whenToBreakStuff : MonoBehaviour
{
    bool startTime = false;
    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
    public UnityEvent pipeBreak, skrapanBreak, uvBreak;
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
                    pipeBreak.Invoke();
                    whosTurn++;
                    delayDone = false;
                    break;
                case 1: //skrapan
                    skrapanBreak.Invoke();
                    whosTurn++;
                    delayDone = false;
                    break;
                case 2: //uv
                    uvBreak.Invoke();
                    whosTurn = 0;
                    delayDone = false;
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
        startTime = false;
        

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
