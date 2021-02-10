using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitScript : MonoBehaviour
{
    Vector3 currentPos;
    public int distance, speed, timeOpen;
    bool start = false, back = false;
    float orgX, orgY, orgZ; //original values
    int yDirection = 0; // 0 = not set, 1 positive, 2 = negative
    float moveY = 0; //will be moved this update

    private bool isCoroutineExecuting = false;
    private bool delayDone = false;
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

        
        moveY = 0;
        
        currentPos = transform.position;
        if (start)
        {
            if (currentPos.y < orgY + distance)
            {

                if (yDirection != 2)
                {

                    moveY = speed * Time.deltaTime; //flyttar plus på Y axeln
                    yDirection = 1;
                }

            }
            else if (currentPos.y > orgY + distance)
            {

                if (yDirection != 1)
                {

                    moveY = -speed * Time.deltaTime; //flyttar minus på Y axeln
                    yDirection = 2;
                }



            }

            transform.position = new Vector3(currentPos.x , currentPos.y + moveY, currentPos.z);

            StartCoroutine(ExecuteAfterTime(timeOpen));
            if (delayDone == true)
            {
                start = false;
                back = true;
            }
        }



        if (back)
        {
            if (currentPos.y < orgY)
            {

                if (yDirection != 2)
                {

                    moveY = speed * Time.deltaTime; //flyttar plus på Y axeln
                    yDirection = 1;
                }

            }
            else if (currentPos.y > orgY)
            {

                if (yDirection != 1)
                {

                    moveY = -speed * Time.deltaTime; //flyttar minus på Y axeln
                    yDirection = 2;
                }



            }

            transform.position = new Vector3(currentPos.x, currentPos.y + moveY, currentPos.z);
        }

        
    }


    public void exitStart()
    {
        start = true;
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
