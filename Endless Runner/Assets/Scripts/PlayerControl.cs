using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && transform.position.x < 3) 
        {
            transform.position += transform.right * 3;
        }

        if (Input.GetKeyDown("left") && transform.position.x > -3) 
        {
            transform.position -= transform.right* 3;
        }
        
        if (Input.GetKeyDown("r")) 
        {
            transform.position = startPosition;
        }
    }

}
