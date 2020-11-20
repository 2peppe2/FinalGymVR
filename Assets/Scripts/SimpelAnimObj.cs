using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpelAnimObj : MonoBehaviour
{


    
    Vector3 currentPos;
    public bool calledFromOtherScript = false;
    public float delay;
    public float movmentX, speedX, movmentY, speedY, movmentZ, speedZ;
    float orgX, orgY, orgZ; //original values
    float moveX = 0,  moveY = 0,  moveZ = 0; //will be moved this update
    int xDirection = 0, yDirection = 0, zDirection = 0; // 0 = not set, 1 positive, 2 = negative
    bool called = false;
    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
    private bool gobackCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 originalPos = transform.position;
        orgX = originalPos.x;
        orgY = originalPos.y;
        orgZ = originalPos.z;


        
    }

    // Update is called once per frame
    void Update()
    {
        if(calledFromOtherScript == true)
        {
            gobackCalled = false;
            if (called)
            {
                StartCoroutine(ExecuteAfterTime(delay));
                if (delayDone == true)
                {
                    moveX = 0;
                    moveY = 0;
                    moveZ = 0;
                    currentPos = transform.position;

                    //X
                    if (currentPos.x < orgX + movmentX)
                    {

                        if (xDirection != 2)
                        {

                            moveX = speedX * Time.deltaTime; //flyttar plus på X axeln
                            xDirection = 1;
                        }

                    }
                    else if (currentPos.x > orgX + movmentX)
                    {

                        if (xDirection != 1)
                        {

                            moveX = -speedX * Time.deltaTime; //flyttar minus på X axeln
                            xDirection = 2;
                        }



                    }
                    //Y
                    if (currentPos.y < orgY + movmentY)
                    {

                        if (yDirection != 2)
                        {

                            moveY = speedY * Time.deltaTime; //flyttar plus på Y axeln
                            yDirection = 1;
                        }

                    }
                    else if (currentPos.y > orgY + movmentY)
                    {

                        if (yDirection != 1)
                        {

                            moveY = -speedY * Time.deltaTime; //flyttar minus på Y axeln
                            yDirection = 2;
                        }



                    }
                    //Z
                    if (currentPos.z < orgZ + movmentZ)
                    {

                        if (zDirection != 2)
                        {

                            moveZ = speedZ * Time.deltaTime; //flyttar plus på Z axeln
                            zDirection = 1;
                        }

                    }
                    else if (currentPos.z > orgZ + movmentZ)
                    {

                        if (zDirection != 1)
                        {

                            moveZ = -speedZ * Time.deltaTime; //flyttar minus på Z axeln
                            zDirection = 2;
                        }



                    }

                    transform.position = new Vector3(currentPos.x + moveX, currentPos.y + moveY, currentPos.z + moveZ);
                }


            }

            if (gobackCalled)
            {
                called = false;
                StartCoroutine(ExecuteAfterTime(delay));
                if (delayDone == true)
                {
                    moveX = 0;
                    moveY = 0;
                    moveZ = 0;
                    currentPos = transform.position;

                    //X
                    if (currentPos.x < orgX)
                    {

                        if (xDirection != 2)
                        {
                            
                            moveX = speedX * Time.deltaTime; //flyttar plus på X axeln
                            xDirection = 1;
                        }

                    }
                    else if (currentPos.x > orgX )
                    {

                        if (xDirection != 1)
                        {
                            
                            moveX = -speedX * Time.deltaTime; //flyttar minus på X axeln
                            xDirection = 2;
                        }



                    }
                    //Y
                    if (currentPos.y < orgY)
                    {

                        if (yDirection != 2)
                        {

                            moveY = speedY * Time.deltaTime; //flyttar plus på Y axeln
                            yDirection = 1;
                        }

                    }
                    else if (currentPos.y > orgY )
                    {

                        if (yDirection != 1)
                        {
                            Debug.Log("hej jag kom git iaf");
                            moveY = -speedY * Time.deltaTime; //flyttar minus på Y axeln
                            yDirection = 2;
                        }



                    }
                    //Z
                    if (currentPos.z < orgZ )
                    {

                        if (zDirection != 2)
                        {

                            moveZ = speedZ * Time.deltaTime; //flyttar plus på Z axeln
                            zDirection = 1;
                        }

                    }
                    else if (currentPos.z > orgZ )
                    {

                        if (zDirection != 1)
                        {

                            moveZ = -speedZ * Time.deltaTime; //flyttar minus på Z axeln
                            zDirection = 2;
                        }



                    }

                    transform.position = new Vector3(currentPos.x + moveX, currentPos.y + moveY, currentPos.z + moveZ);
                }
            }
        }
        else
        {
            moveX = 0;
            moveY = 0;
            moveZ = 0;
            currentPos = transform.position;

            //X
            if (currentPos.x < orgX + movmentX)
            {

                if (xDirection != 2)
                {

                    moveX = speedX * Time.deltaTime; //flyttar plus på X axeln
                    xDirection = 1;
                }

            }
            else if (currentPos.x > orgX + movmentX)
            {

                if (xDirection != 1)
                {

                    moveX = -speedX * Time.deltaTime; //flyttar minus på X axeln
                    xDirection = 2;
                }



            }
            //Y
            if (currentPos.y < orgY + movmentY)
            {

                if (yDirection != 2)
                {

                    moveY = speedY * Time.deltaTime; //flyttar plus på Y axeln
                    yDirection = 1;
                }

            }
            else if (currentPos.y > orgY + movmentY)
            {

                if (yDirection != 1)
                {

                    moveY = -speedY * Time.deltaTime; //flyttar minus på Y axeln
                    yDirection = 2;
                }



            }
            //Z
            if (currentPos.z < orgZ + movmentZ)
            {

                if (zDirection != 2)
                {

                    moveZ = speedZ * Time.deltaTime; //flyttar plus på Z axeln
                    zDirection = 1;
                }

            }
            else if (currentPos.z > orgZ + movmentZ)
            {

                if (zDirection != 1)
                {

                    moveZ = -speedZ * Time.deltaTime; //flyttar minus på Z axeln
                    zDirection = 2;
                }



            }

            transform.position = new Vector3(currentPos.x + moveX, currentPos.y + moveY, currentPos.z + moveZ);

            //Debug.Log(currentPos.ToString());

            //transform.position = new Vector3(currentPos.x +  speed* Time.deltaTime, currentPos.y, currentPos.z);

        }


    }

    public void StartTransform()
    {
        called = true;
        
    }

    public void GoBackToOrgin()
    {
        gobackCalled = true;
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
