using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Player : MonoBehaviour {

   

    //public float buttonMargin = 2;
    Vector3 pos;
    public GameObject invisibleBallPrefab;
    public GameObject bot;
    public float invisibleBallSpeed = 3;


    // Use this for initialization
    void Start () {

        //verticalSpeed =  5.0f;


        //Ball chooses that direction
        //Flies that direction

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball") {
            GameObject ball = collision.gameObject;

            //skapar en boll kopia
            GameObject newBall = Instantiate(ball);
            newBall.tag = "InvisibleBall";
            newBall.GetComponent<Ball>().enabled = false;

            //gör bollen osynlig
            newBall.GetComponent<SpriteRenderer>().enabled = false;

            newBall.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity * invisibleBallSpeed;

            //boten försöker fånga onsynliga bollen
            bot.GetComponent<Bot>().ball = newBall;

        }
    }



    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            //Fixar position 
            pos.x = transform.position.x;
            //Placerar position där vi klickar
            transform.position = pos;

        }

#else
        foreach(Touch touch in Input.touches ) {
            if (touch.phase == TouchPhase.Began) {

            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = 0;
           
            pos.x = transform.position.x;
           
            transform.position = pos;

        }
        }
#endif
    }
        public void ScaleUp() {

        transform.localScale += new Vector3(1f, 0, 0);
        StartCoroutine(ScaleDown());
    }


    IEnumerator ScaleDown() {
        yield return new WaitForSeconds(5);

        transform.localScale -= new Vector3(1f, 0, 0);

    }


}
