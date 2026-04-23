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
    public int health;
    public ParticleSystem playerDie;
    float move = 3.4f;
    public AudioSource JumpSound;
    public AudioSource MoveSound;
    public AudioSource DeathSound;
    public AudioSource DamageSound;
    public GameObject Restart;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        startPosition = new Vector3(0, 1.25f, -1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right") && transform.position.x < 1) 
        {
            MoveSound.Play();
            targetPosition += transform.right * move;
        }

        if (Input.GetKeyDown("left") && transform.position.x > -1) 
        {
            MoveSound.Play();
            targetPosition -= transform.right* move;
        }

        if (Input.GetKeyDown("space") && canJump == true) 
        {
            JumpSound.Play();
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            canJump = false;
        }

        if (Input.GetKeyDown("d") && transform.position.x < 1) 
        {
            MoveSound.Play();
            targetPosition += transform.right * move;
        }

        if (Input.GetKeyDown("a") && transform.position.x > -1) 
        {
            MoveSound.Play();
            targetPosition -= transform.right* move;
        }

        targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, duration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        DamageSound.Play();
        health -= 1;
        Debug.Log("e");

        if(!gameObject.CompareTag("Ground"))
        {        
            Dead();
        }
    }
    void Dead() 
    {
        if (health <= 0)
            {
                dead = true;
                DeathSound.Play();
                playerDie.Play();
                Destroy(this.gameObject);
                Time.timeScale = 0.5f;
                RestartButton();
            }
    }

    public bool CheckDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    }

    void RestartButton()
    {
        if(FindObjectOfType<GameManager>().CheckPlayer())
        {
            Restart.SetActive(true);
        }
    }
}
