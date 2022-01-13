using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovementScript : MonoBehaviour
{
    public float speed;
   
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
    }
}
