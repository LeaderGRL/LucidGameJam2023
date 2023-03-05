using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ColiderVoiture : MonoBehaviour

{
    [SerializeField] private List<GameObject> spawners;
    public Vector3 move;
    [SerializeField] private GameObject light;   
    [SerializeField] private ColiderVoiture OtherCollider;

    // Start is called before the first frame update
    private void Awake()
    {
        move = new Vector3(5, 0, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        OtherCollider.move = Vector3.zero;
        if (other.tag == "Light")
        {
            int rand = new Random().Next(0, 4);

            if (rand <= 1)
            {
                if (rand == 1)
                {
                    light.transform.rotation = Quaternion.Euler(0,180,0);
                }
                else
                {
                    light.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                light.transform.position = new Vector3(spawners[rand].transform.position.x,1.51f,spawners[rand].transform.position.z);
                move = new Vector3(5, 0, 0) * Time.deltaTime;

            }
            else
            {
                if (rand == 2)
                {
                    light.transform.rotation = Quaternion.Euler(0,180,0);
                }
                else
                {
                    light.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                light.transform.position = new Vector3(spawners[rand].transform.position.x,1.51f,spawners[rand].transform.position.z);
                move = (new Vector3(5, 0, 0) * Time.deltaTime) * -1;

            }
        }
    }

    private void Update()
    {
        light.transform.position += move;
    }
}
