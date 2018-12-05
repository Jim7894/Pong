using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour {
    //transform.scale.y något sånt för att få paddeln större.
    public GameObject PowerUpPrefab;
   
 
    // Använd denna för att ge värden till de globala värdena(skapa två players, bollen, två goalines och två walls.
    void Start () {

        StartCoroutine(SpawnPowerUp());
	}

    IEnumerator SpawnPowerUp() {

        yield return new WaitForSeconds(30);
        LaunchPowerUp();

       
        StartCoroutine(SpawnPowerUp());
    }

    void LaunchPowerUp()
    {
        GameObject powerUp = Instantiate(PowerUpPrefab);
        Rigidbody2D PU = powerUp.GetComponent<Rigidbody2D>();

    //reset
    transform.position = Vector3.zero;

        //Ball chooses that direction
        //Flies that direction


        int xDirection = 0; //Random.Range(0, 2);
        int yDirection = Random.Range(0, 2);


        Vector3 launchDirection = new Vector3();

        //check result of second coin toss
        if (xDirection == 0)
        {
            launchDirection.x = -16;
        }

        if (xDirection == 1)
        {
            launchDirection.x = 16f;
        }

        if (yDirection == 0)
        {
            launchDirection.y = -2f;
        }

        if (yDirection == 1)
        {
            launchDirection.y = 2f;
        }

        if (yDirection == 2)
        {
            launchDirection.y = 14f;
        }

        //Assign velocity based off of where we launch ball
        PU.velocity = launchDirection;

    }

}
