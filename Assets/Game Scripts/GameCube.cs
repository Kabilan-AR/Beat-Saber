using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCube : MonoBehaviour
{
    
    public  float speed;

   
    void Start()
    { 
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * -transform.forward * speed;
       if(transform.position.x >=8)
        {
            FindObjectOfType<GameManager>().ReduceScoreCount();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //dunno why it isnt working
        if (collision.gameObject.tag == "EndBox")
        {
            Destroy(gameObject);
        }
    }
}
