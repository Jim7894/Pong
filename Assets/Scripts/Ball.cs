using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ball;
    //get a reference to rigitbody attached to the object
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        //Get shortcut to rigidbody component
        rb = GetComponent<Rigidbody2D>();
        //Pause ball logic for 2.5 seconds, delay launch
        StartCoroutine(Pause());

    }

    // Update is called once per frame
    void Update()
    {



        //if the ball goes too far left

       

        if (transform.position.x < -25f) {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            //Give Bot point
            Scoreboard_Controller.instance.GiveBotAPoint();

            StartCoroutine(Pause());
        }

        //if the ball goes too far right

        //Give bot point


        if (transform.position.x > 25f) {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            Scoreboard_Controller.instance.GivePlayerAPoint();
            StartCoroutine(Pause());
        }

    }

    IEnumerator Pause()
    {
        //Wait for 2.5 seconds
        yield return new WaitForSeconds(2.5f);

        //Call function that launches the ball
        LaunchBall();
    }

    void LaunchBall() {

        //reset
        transform.position = Vector3.zero;

        //Ball chooses that direction
        //Flies that direction


        int xDirection = 0; //Random.Range(0, 2);
        int yDirection = Random.Range(0, 3);


        Vector3 launchDirection = new Vector3();

        //check result of second coin toss
        if (xDirection == 0)
        {
            launchDirection.x = -8f;
        }

        if (xDirection == 1)
        {
            launchDirection.x = 8f;
        }

        if (yDirection == 0)
        {
            launchDirection.y = -8f;
        }

        if (yDirection == 1)
        {
            launchDirection.y = 8f;
        }

        if (yDirection == 2)
        {
            launchDirection.y = 0f;
        }

        //Assign velocity based off of where we launch ball
        rb.velocity = launchDirection;

    }

  

    //When we hit something else
    void OnCollisionEnter(Collision hit)
    {
        //if it was top or bottom of the screen...
        Debug.Log(hit.gameObject.name);

        //If it was one of the bats
        if (hit.gameObject.name == "TopBounds")
        {

            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection, -8f, 0f);
        }

        if (hit.gameObject.name == "BottomBounds")
        {
            float speedInXDirection = 0f;

            if (rb.velocity.x > 0f)
                speedInXDirection = 8f;

            if (rb.velocity.x < 0f)
                speedInXDirection = -8f;

            rb.velocity = new Vector3(speedInXDirection, 8f, 0f);

        }
        if (hit.gameObject.name == "Player") {

            rb.velocity = new Vector3(13f, 0f, 0f);

            //cheak if we hit lower half of the bat
            if (transform.position.y - hit.gameObject.transform.position.y < -1)
            {

                rb.velocity = new Vector3(8f, -8f, 0f);
            }

            if (transform.position.y - hit.gameObject.transform.position.y > 1)
            {

                rb.velocity = new Vector3(8f, 8f, 0f);
            }
        }

        if (hit.gameObject.name == "Bot") {

            rb.velocity = new Vector3(-13f, 0f, 0f);

            //cheak if we hit lower half of the bat
            if (transform.position.y - hit.gameObject.transform.position.y < -1)
            {

                rb.velocity = new Vector3(-8f, -8f, 0f);
            }

            if (transform.position.y - hit.gameObject.transform.position.y > 1)
            {

                rb.velocity = new Vector3(-8f, 8f, 0f);
            }
        }
    }

}
            





