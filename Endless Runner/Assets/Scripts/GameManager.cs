using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float speedUpTimer;
    public float speedUpAmount;
    public float timer;
    public GameObject Restart;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale += speedUpAmount;
            Debug.Log("Time scale: " + Time.timeScale);
            timer = speedUpTimer;
        }
    }
    public bool CheckPlayer() 
    {
        if (FindObjectOfType<PlayerControl>().CheckDead())
        {
            return true;
        }

        return false;
    }
}