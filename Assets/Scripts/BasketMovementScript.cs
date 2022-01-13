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

    public AudioClip[] audioClipArr;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            SceneManager.LoadScene("GamePlay_Level 2");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //collision with unhealthy food
        if(collision.gameObject.tag == "Unhealthy")
        {
            Destroy(collision.collider.gameObject);
            audioSource.PlayOneShot(audioClipArr[1]);
            SceneManager.LoadScene("GameLoseScene");
        }
        //collision with healthy food
        if (collision.gameObject.tag == "Healthy")
        {
            score += 10;
            scoreText.text = "Score: " + score;
            audioSource.PlayOneShot(audioClipArr[0]);
            Destroy(collision.collider.gameObject);
        }
    }
}
