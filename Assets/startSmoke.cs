using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSmoke : MonoBehaviour
{

    public ParticleSystem system;
    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
    bool timesOut = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(delayDone == true)
        {
            system.Stop();
        } 
    }


    public void StartTheSmoke(int delay)
    {
        delayDone = false;
        isCoroutineExecuting = false;
        system.Play();
        StartCoroutine(ExecuteAfterTime(delay));
        
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
