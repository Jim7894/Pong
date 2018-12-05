using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour {

    //private Ball ball;
    public GameObject ball;

    public float speed = 3f;
    Vector2 target;


    // Use this for initialization
    void Start () {

        target = transform.position;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "InvisibleBall") {
            Destroy(collision.gameObject);

        }
    }



    // Update is called once per frame
    void Update () {

        if (ball != null && ball.transform.position.x > transform.position.x)
        {
            target.y = ball.transform.position.y;
            Destroy(ball);
        }

  
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
   
    }
}
