using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public Vector3 mousePoints;

    private int Count = 0;

    public GameObject spherePrefab;

    public float spawnDelay;

    private void Start()
    {
        Count = 0;
        spawnDelay = 1f;
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0) 
        {
            spawnDelay = 1f;
            GameObject.Instantiate(spherePrefab,new Vector3(0f,13f, UnityEngine.Random.Range(-13,13)),new Quaternion() );
        }
        mousePoints = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15.0f));
        transform.position = new Vector3(0, transform.position.y, mousePoints.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;
        Destroy(other.gameObject);
    }
}
