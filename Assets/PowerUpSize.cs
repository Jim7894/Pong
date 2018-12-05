using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : MonoBehaviour {
    public float PowerUpSpeed = 2;
    Rigidbody2D PU;
    public float duration = 4f;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
           
            col.gameObject.GetComponent<Player>().ScaleUp();


            Destroy(gameObject);

           

        }
    }






   
    //Kolla upp hur den här metoden funkar: körs den aoutomatisk av Unity med jämna mellanrum? eller måste jag anropa den t.ex. varje sekund?
    // I varje tidssteg (alltså varje gång den körs) kommer den att updatera bollens position och players positioner. Den måste ta hänsyn till att bollen ska stutsa när playerna tar emot bollen och att den studsar på collider väggarna och att när bollen kommer in i mållinjen så vinner den ena spelaren.
    void Update()
    {

    }


}
