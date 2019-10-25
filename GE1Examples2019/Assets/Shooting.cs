using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    float ellapsed = float.MaxValue;
    public int fireRate = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float toPass = 1.0f / fireRate;
        ellapsed += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl) && ellapsed > toPass)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            ellapsed = 0;
        }
    }
}
