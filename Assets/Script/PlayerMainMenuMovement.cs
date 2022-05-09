using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenuMovement : MonoBehaviour
{

    private Animator animator;
    private float randomTime, timeCounter;
    private bool timeIsRunning = false;

    // Start is called before the first frame update    
    void Start()
    {
        animator = GetComponent<Animator>();
        randomTime = Random.Range(1f, 5f);
        Debug.Log("Time: " + randomTime);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeIsRunning)
        {
            if (timeCounter > 0)
            {
                
                timeCounter -= Time.deltaTime;
            }
            else
            {
                timeCounter = 0;
                timeIsRunning = false;
                animator.SetBool("isIdle", true);
            }
        }
        else
        {
            StartCoroutine(StartCooldown(randomTime));
            animator.SetBool("isIdle", false);
        }
    }

    public IEnumerator StartCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        
        timeCounter = time;
        timeIsRunning = true;
        //randomTime = Random.Range(10f, 200f);
        //animator.SetBool("isIdle", false);
    }
}
