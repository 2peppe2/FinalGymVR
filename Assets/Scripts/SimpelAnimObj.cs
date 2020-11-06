using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpelAnimObj : MonoBehaviour
{

    

    Vector3 currentPos;
    public float movmentX, movmentY, movmentZ;
    float orgX, orgY, orgZ; //original values
    float moveX = 0, moveY = 0, moveZ = 0; //will be moved this update


    public float speed;
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
        currentPos = transform.position;
        if (currentPos.x < orgX + movmentX)
        {
            moveX = speed * Time.deltaTime;
        }else if(currentPos.x > orgX + movmentX)
        {
            moveX = -speed * Time.deltaTime;
        }else if(currentPos.x == orgX + movmentX)
        {
            //marginaler
            Debug.Log("X animation done");
        }

        transform.position = new Vector3(currentPos.x + moveX, currentPos.y + moveY, currentPos.z + moveZ);

        Debug.Log(currentPos.ToString());
        
        //transform.position = new Vector3(currentPos.x +  speed* Time.deltaTime, currentPos.y, currentPos.z);

    }
}
