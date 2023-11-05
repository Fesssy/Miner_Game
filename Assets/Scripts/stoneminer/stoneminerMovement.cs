using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static rest;

public class stoneminerMovement : MonoBehaviour
{
    [SerializeField]
    public float _speed;

    public Animator animator;

    private Vector3 _targetDirection;

    private Rigidbody2D _rigidbody;

    private stonemineralAwarenessController _mineralAwarenessController;

    private depositStoneMineral _depositMineral;

    private rest _rest;

    private gameState gs;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mineralAwarenessController = GetComponent<stonemineralAwarenessController>();
        _depositMineral = GetComponent<depositStoneMineral>();
        _rest = GetComponent<rest>();
        gs = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
        _speed = gs.stoneminerSpeed;
    }

    private void FixedUpdate()
    {
        _speed = gs.stoneminerSpeed;
        updateDirection();
        if (_rest.state != currentState.resting)
            setVelocity();
    }

    private void updateDirection()
    {
        if (_rest.state == currentState.wantRest)
        {
            try
            {
                _targetDirection = gameObject.GetComponent<rest>().getHomePosition();
                Debug.Log("Moving Towards: " + _targetDirection);
            }
            catch
            {
                Debug.Log("Miner is tired, needs to rest");
                _targetDirection = Vector3.zero;
            }
        }

        else if (_depositMineral.depositmineral)
        {
            try
            {
                _targetDirection = GameObject.FindGameObjectWithTag("MineralCollector").GetComponent<Transform>().position;
                Debug.Log(_targetDirection);
                //_targetDirection = Vector3.one;
                Debug.Log("Got the mineralCollector");
            }
            catch (System.NullReferenceException)
            {
                _targetDirection = Vector3.zero;
                _rigidbody.velocity = Vector3.zero;
                Debug.Log("No mineral Collector to collect minerals!!!!");
            }

        }
        else if (_mineralAwarenessController.awareOfMineral)
        {
            //_targetDirection = new Vector3(_mineralAwarenessController.directionToMineral.x, _mineralAwarenessController.directionToMineral.y, 0.0f);
            _targetDirection = (Vector3)_mineralAwarenessController.directionToMineral;
        }
        else
        {
            _targetDirection = Vector3.zero;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void setVelocity()
    {
        if (_targetDirection == Vector3.zero)
        {
            return;
        }
        else
        {
            if (!_depositMineral.depositmineral)
                _targetDirection.x -= 0.5f;

            transform.position = Vector3.MoveTowards(transform.position, _targetDirection, _speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            _targetDirection = Vector3.one;
        }
    }
}
