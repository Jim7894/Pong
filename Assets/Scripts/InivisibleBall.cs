using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InivisibleBall : MonoBehaviour
{

    public Rigidbody2D iball;

    // Use this for initialization
    void Start()
    {

        iball = GetComponent<Rigidbody2D>();

        StartCoroutine(Pause());
    }


    void LaunchBall()
    {

        transform.position = Vector3.zero;

        int xDirection = Random.Range(0, 2);
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
        iball.velocity = launchDirection;
    }

    IEnumerator Pause()
    {
        //Wait for 2.5 seconds
        yield return new WaitForSeconds(2.5f);

        //Call function that launches the ball
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {
        //if the ball goes too far left
        if (transform.position.x < -25f)
        {
            StartCoroutine(Pause());
        }

        //if the ball goes too far right
        if (transform.position.x > 25f)
        {
            StartCoroutine(Pause());
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        //if it was top or bottom of the screen...
        Debug.Log(hit.gameObject.name);

        if (hit.gameObject.name == "TopBounds")
        {

            float speedInXDirection = 0f;

            if (iball.velocity.x > 0f)
                speedInXDirection = 8f;

            if (iball.velocity.x < 0f)
                speedInXDirection = -8f;

            iball.velocity = new Vector3(speedInXDirection, -8f, 0f);
        }

        if (hit.gameObject.name == "BottomBounds")
        {
            float speedInXDirection = 0f;

            if (iball.velocity.x > 0f)
                speedInXDirection = 8f;

            if (iball.velocity.x < 0f)
                speedInXDirection = -8f;

            iball.velocity = new Vector3(speedInXDirection, 8f, 0f);

        }
        if (hit.gameObject.name == "Player")
        {

            iball.velocity = new Vector3(13f, 0f, 0f);

            //cheak if we hit lower half of the bat
            if (transform.position.y - hit.gameObject.transform.position.y < -1)
            {

                iball.velocity = new Vector3(8f, -8f, 0f);
            }

            if (transform.position.y - hit.gameObject.transform.position.y > 1)
            {

                iball.velocity = new Vector3(8f, 8f, 0f);
            }
        }
    }
}