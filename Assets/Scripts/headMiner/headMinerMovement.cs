using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using Debug = UnityEngine.Debug;

public class headMinerMovement : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;
    private Vector3 targetPosition;

    public Animator animator;


    void Start ()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if((Input.GetMouseButtonDown(0) || Input.touchCount == 1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            try
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z;
                animator.SetBool("move_up", true);
            }
            catch
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).phase != TouchPhase.Stationary)
                {
                    targetPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    targetPosition.z = transform.position.z;
                    animator.SetBool("move_up", true);
                }
            }
            
        }
        if(transform.position == targetPosition)
        {
            animator.SetBool("move_up", false);
        }

        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    public void setPosition(Vector2 pos)
    {
        targetPosition = pos;
        transform.position = targetPosition;
    }

}
