using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public LayerMask layer;
    private Vector3 previousPos;
    
    public static int Destroycount;
    public GameObject particle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.transform.position, endSlicePoint.transform.position, out RaycastHit hit, layer);
        if (hasHit)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            FindObjectOfType<GameManager>().ScoreCount();

            Destroy(hit.transform.gameObject);
            Instantiate(particle);
        }
        
        //        RaycastHit hit;
        //        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.2f, layer))
        //        {
        //            AudioSource audio = GetComponent<AudioSource>();
        //            audio.Play();
        //            //Destroy(hit.transform.gameObject);
        //            /*if(Vector3.Angle(transform.position -previousPos,hit.transform.up) >130)
        //            {

        //;                Destroy(hit.transform.gameObject);
        //            }*/

        //        }
        //        previousPos= transform.position;

    }
    

}
