using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static rest;

public class rabbitMovement : MonoBehaviour
{
    [SerializeField]
    public float _speed;

    private Vector3 _targetDirection;

    private bool changeDir;

    private float hopTime;

    public GameObject key;

    private void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key");
    }
    private void Awake()
    {
        _speed = 1.0f;
        changeDir = true;
    }

    private void FixedUpdate()
    {
        updateDirection();
        setVelocity();
    }

    private void updateDirection()
    {

        if(key.activeInHierarchy)
        {     
            _targetDirection = key.transform.position;
        }
        else if(transform.position != _targetDirection || !changeDir)
        {
            return;
        }
        else
        {
            _targetDirection = getRandomPosition();
            changeDir = false;
            StartCoroutine(hopTimer());
        }    
    }

    IEnumerator  hopTimer()
    {
        hopTime = Random.Range(1.0f, 5.0f);
        yield return new WaitForSeconds(hopTime);
        changeDir = true;
    }

    private void setVelocity()
    {
        
            transform.position = Vector3.MoveTowards(transform.position, _targetDirection, _speed * Time.fixedDeltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            _targetDirection = Vector3.one;
        }
    }

    private Vector3 getRandomPosition()
    {

        /*
         * Need to add logic for checking objects before spawning.
         */

        float x, y;

        x = Random.Range(-20, 20);
        y = Random.Range(-10, 10);

        return new Vector3(x, y, 0);

    }
}
