using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Vector3 targetPosition;
    Vector3 startPosition;
    Vector3 velocity;
    public float duration;
    public float jumpStrength;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3(0, 1.25f, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && transform.position.x < 1) 
        {
            targetPosition += transform.right * 3;
        }

        if (Input.GetKeyDown("left") && transform.position.x > -1) 
        {
            targetPosition -= transform.right* 3;
        }

        if (Input.GetKeyDown("space") && canJump == true) 
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            canJump = false;
        }

        if (Input.GetKeyDown("d") && transform.position.x < 1) 
        {
            targetPosition += transform.right * 3;
        }

        if (Input.GetKeyDown("a") && transform.position.x > -1) 
        {
            targetPosition -= transform.right* 3;
        }
        
        if (Input.GetKeyDown("r")) 
        {
            transform.position = startPosition;
        }

        targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, duration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
