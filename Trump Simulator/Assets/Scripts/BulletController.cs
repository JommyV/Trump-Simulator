using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] GameObject[] world;
    //[SerializeField] GameObject world2;
    //[SerializeField] GameObject world3;
    private float bulletTimer = 5f;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (bulletTimer <= 0 )
        {
            world[i].SetActive(true);
            i++;
            bulletTimer = 5f;
        }
    }
}
