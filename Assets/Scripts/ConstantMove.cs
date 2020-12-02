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
    bool tillbaka = false;
    

    // Start is called before the first frame update
    void Start()
    {
        minZ = transform.position.z;
        maxZ = minZ + HowMuchItMove;
    }

    // Update is called once per frame
    void Update()
    {

        moveZ = 0;
        Vector3 currentPos = transform.position;

        if (tillbaka == false)
        {
            if (currentPos.z < maxZ)
            {

                if (zDirection != 2)
                {

                    moveZ = speedZ * Time.deltaTime;
                    zDirection = 1;
                }
                else
                {
                    tillbaka = true;
                }

            }
            else if (currentPos.z > maxZ)
            {

                if (zDirection != 1)
                {

                    moveZ = -speedZ * Time.deltaTime; //flyttar minus på X axeln
                    zDirection = 2;
                }
                else
                {
                    tillbaka = true;
                }



            }
        }
        else
        {
            if (currentPos.z < minZ)
            {

                if (zDirection != 2)
                {

                    moveZ = speedZ * Time.deltaTime;
                    zDirection = 1;
                }
                else
                {
                    tillbaka = false;
                }

            }
            else if (currentPos.z > minZ)
            {

                if (zDirection != 1)
                {

                    moveZ = -speedZ * Time.deltaTime; //flyttar minus på X axeln
                    zDirection = 2;
                }
                else
                {
                    tillbaka = false;
                }



            }
        }
        transform.position = new Vector3(currentPos.x, currentPos.y , currentPos.z + moveZ);
    }

    void Knappklickad (int which)   //0 = grön, 1 = gul, 2 = röd;
    {

    }
}
