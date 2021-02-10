using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkrapanHandlerScript : MonoBehaviour
{

    bool broken = false, starttime = false;
    int turn = 0;
    public UnityEvent redOK, yellowOK, greenOK, wrong, done;

    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
    bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starttime)
        {
            StartCoroutine(ExecuteAfterTime(1));
            if (delayDone == true)
            {
                if(played == false)
                {
                    done.Invoke();
                    played = true;
                }
            }
        }
    }

    public void redClicked()
    {
        if (broken)
        {
            if (turn == 1)
            {
                redOK.Invoke();
                turn = 2;
            }
            else
            {
                wrong.Invoke();
                turn = 0;
            }
        }
    }
    public void yellowClicked()
    {
        if (broken)
        {
            if(turn == 0)
            {
                yellowOK.Invoke();
                turn = 1;
            }
            else
            {
                wrong.Invoke();
                turn = 0;
            }
        }
    }
    public void greenClicked()
    {
        if (broken)
        {
            if (turn == 2)
            {
                greenOK.Invoke();
                starttime = true;
            }
            else
            {
                wrong.Invoke();
                turn = 0;
                

            }
        }
    }

    public void doomCalled()
    {
        broken = true;
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
