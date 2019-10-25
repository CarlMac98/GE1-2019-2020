using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    //int numtanks = 0;
    private int maxTanks = 5, rng = 10;
    public GameObject enemy;
    bool spawning = true;
    void Start()
    {
        IEnumerator spwn = Spawner();
        StartCoroutine(spwn);
    }

    // Update is called once per frame
    void Update()
    {
        int tanks = GameObject.FindGameObjectsWithTag("Tank").Length;
        if (tanks < maxTanks && spawning == false)
        {
            StartCoroutine(Spawner());
            spawning = false;
        }

        if (tanks >= maxTanks && spawning == true)
        {
            StopCoroutine(Spawner());
            spawning = false;
        }
    }


    IEnumerator Spawner()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Tank").Length < maxTanks)
            {
                Vector3 pos = transform.TransformPoint(new Vector3(Random.Range(-rng, rng), 10, Random.Range(-rng, rng)));
                Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);

                GameObject enemy = GameObject.Instantiate(this.enemy, pos, rot);
                enemy.AddComponent<Rigidbody>();
                enemy.AddComponent<OnHit>();
            }
            
            yield return new WaitForSeconds(1.0f);
        }
    }
}
