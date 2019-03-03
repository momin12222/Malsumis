using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeholder : MonoBehaviour
{
    public GameObject topLeft;
    public GameObject bottomRight;

    public GameObject unit;
    Vector3 newVector;
    bool state;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (unit.transform.position.x < topLeft.transform.position.x)
        {
            if (unit.transform.position != newVector)
            {
                newVector = new Vector3(unit.transform.position.x + 1, unit.transform.position.y, unit.transform.position.z);
                unit.transform.position = Vector3.MoveTowards(unit.transform.position, newVector, 1f);
            }
           
        }

        else if (unit.transform.position.x > bottomRight.transform.position.x)
        {

        }

        else if (unit.transform.position.y > topLeft.transform.position.x)
        {

        }

        else if (unit.transform.position.x < bottomRight.transform.position.x)
        {

        }
    }

    IEnumerator forceBounce()
    {
        while (true)
        {
            newVector = new Vector3(unit.transform.position.x + 1, unit.transform.position.y, unit.transform.position.z);
            unit.transform.position = Vector3.MoveTowards(unit.transform.position, newVector, 1f);
            if(unit.transform.position == newVector)
            {
                yield break;
            }
        }
    }
}
