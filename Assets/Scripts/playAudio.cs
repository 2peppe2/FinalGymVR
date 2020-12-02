using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{

    public int delay;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAudio()
    {
        StartCoroutine(ExecuteAfterTime(delay));
        
        //
    }


    private bool isCoroutineExecuting = false;
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        audioData.Play(0);
        isCoroutineExecuting = false;
    }





}



