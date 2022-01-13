using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;

    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float minXPos = -10f;
        float maxXPos = 10f;
        float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (transform.position.x + xMovement > minXPos && transform.position.x + xMovement < maxXPos)
        {
            transform.Translate(xMovement, 0f, 0f);
        }
        
        //float horizontalInput = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        if(score>=100)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision with unhealthy food
        if(collision.gameObject.tag == "Unhealthy")
        {
            Destroy(collision.collider.gameObject);
            SceneManager.LoadScene("GameLoseScene");
        }
        //collision with healthy food
        if (collision.gameObject.tag == "Healthy")
        {
            score += 10;
            scoreText.text = "Score: " + score;
            Destroy(collision.collider.gameObject);
        }
    }
}
