using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WhichDoorSluss : MonoBehaviour
{

    //Hej o välkommen till vilken dörr ska öppnas
    private int vartKomJagIfrån = 0; //0 = oklar 1= utifrån och in 2 = inifrån och ut 4= boi vad håller du på med
    // Start is called before the first frame update
    public UnityEvent öppna1;
    public UnityEvent stäng1;
    public UnityEvent öppna2;
    public UnityEvent stäng2;
    public UnityEvent playSmoke;
    private bool isCoroutineExecuting = false; private bool isCoroutineExecuting2 = false; private bool isCoroutineExecuting3 = false;
    private bool delayDone = false; private bool delayDone2 = false; private bool delayDone3 = false;
    private bool gobackCalled = false;
    public AudioSource audioSource;
    public int timeUntilAirPuff;
    bool middelMan = false;
    bool Spelad = false;
    bool[] moved = new bool[4];
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        moved[0] = false; moved[1] = false; moved[2] = false; moved[3] = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(middelMan == true)
        {
            if (vartKomJagIfrån == 1)
            {
                if (moved[1] == false)
                {
                    
                    stäng1.Invoke();
                    moved[1] = true;
                }
                

                StartCoroutine(ExecuteAfterTime(4));
                if (delayDone == true)
                {

                    if(Spelad == false)
                    {
                        audioSource.Play(0);
                        playSmoke.Invoke();
                        Spelad = true;
                    }
                    StartCoroutine(ExecuteAfterTime2(5));
                    if(delayDone2 == true)
                    {

                        if(moved[2] == false)
                        {
                            öppna2.Invoke();
                            moved[2] = true;
                        }
                        
                        StartCoroutine(ExecuteAfterTime3(10));
                        if(delayDone3 == true)
                        {
                            if(moved[3]== false)
                            {
                                stäng2.Invoke();
                                moved[3] = true;
                                middelMan = false;
                            }
                            
                        }
                    }
                }


            }
            else if (vartKomJagIfrån == 2)
            {
                if (moved[3] == false)
                {
                    stäng2.Invoke();
                    moved[3] = true;
                }


                StartCoroutine(ExecuteAfterTime(4));
                if (delayDone == true)
                {

                    if (Spelad == false)
                    {
                        audioSource.Play(0);
                        playSmoke.Invoke();
                        Spelad = true;
                    }
                    StartCoroutine(ExecuteAfterTime2(5));
                    if (delayDone2 == true)
                    {

                        if (moved[0] == false)
                        {
                            öppna1.Invoke();
                            moved[0] = true;
                        }

                        StartCoroutine(ExecuteAfterTime3(10));
                        if (delayDone3 == true)
                        {
                            if (moved[1] == false)
                            {
                                stäng1.Invoke();
                                moved[1] = true;
                                middelMan = false;
                            }

                        }
                    }
                }
            }
        }
        
    }

    public void KnappUte()
    {
        //du har klickat på knappen utanför dörr ett
        vartKomJagIfrån = 1;
        öppna1.Invoke();
    }

    public void knappMitten()
    {
        moved[0] = false; moved[1] = false; moved[2] = false; moved[3] = false;
        isCoroutineExecuting = false; isCoroutineExecuting2 = false; isCoroutineExecuting3 = false;
        delayDone = false; delayDone2 = false; delayDone3 = false;
        middelMan = true;
    }

    public void KnappInne()
    {
        vartKomJagIfrån = 2;
        
        öppna2.Invoke();
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
