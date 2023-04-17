using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BirdFlight : MonoBehaviour{

    [SerializeField] float speed;
    Rigidbody2D playerRigid;

    float score = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;

    void Start(){
        
        playerRigid = GetComponent<Rigidbody2D>();
    }

    void Update(){

        if (Input.GetMouseButtonDown(0)){

            playerRigid.velocity = Vector2.up * speed;
        }

        scoreText.text = score.ToString();
        finalScoreText.text = scoreText.text;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        GameManager.instance.GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.tag == "ScoreArea"){

            score++;
        }
    }
}