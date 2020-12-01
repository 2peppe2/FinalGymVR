using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float speedZ;
    private float moveZ;
    public float HowMuchItMove;
    private float minZ, maxZ;
    int zDirection = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        minZ = transform.position.z;
        maxZ = minZ + HowMuchItMove;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        if (currentPos.z < maxZ)
        {

            if (zDirection != 2)
            {

                moveZ = speedZ * Time.deltaTime; 
                zDirection = 1;
            }

        }
        else if (currentPos.x > maxZ)
        {

            if (zDirection != 1)
            {

                moveZ = -speedZ * Time.deltaTime; //flyttar minus på X axeln
                zDirection = 2;
            }



        }
    }

    void Knappklickad (int which)   //0 = grön, 1 = gul, 2 = röd;
    {

    }
}
