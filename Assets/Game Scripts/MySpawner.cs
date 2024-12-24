using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MySpawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] points;
    public float beat = 2.5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            int RandCube = Random.Range(0, 2);
            int RandPos= Random.Range(0, points.Length);
            int RandPos1 = Random.Range(0, points.Length);
            if(RandPos==RandPos1 && RandPos1!=0 && RandPos1!=points.Length-1)
            {
                if (RandPos1 < points.Length-1 && RandPos1>0)
                {
                    RandPos1++;
                }
                else
                {
                    RandPos1--;
                }
            }
            Instantiate(cubes[0], points[RandPos]);
            Instantiate(cubes[1], points[RandPos1]);
            //GameObject cube = Instantiate(cubes[RandCube], points[RandPos]);
            //cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate(transform.right, 90 * Random.Range(0, 4));

            timer -= beat;

        }
        timer += Time.deltaTime;
    }
}
