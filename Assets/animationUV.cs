using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationUV : MonoBehaviour
{
    public float speed;
    bool start = false;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            scaleChange = new Vector3(speed, 0f, 0f);


            this.transform.localScale += scaleChange* Time.deltaTime;
        }


    }

    public void CalledAnim()
    {
        start = true;
    }
}
