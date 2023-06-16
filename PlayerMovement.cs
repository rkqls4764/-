using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody;

    public float maxPower = 20.0f; //최대 파워
    public float powerIncreaseRate = 3.0f; //파워 증가 속도
    public float speed = 10.0f; //이동 속도

    bool isDown = false; //클릭 여부
    bool isJump = false; //점프 여부
    Vector3 startPos; //시작 위치
    float power = 0.0f; //파워

    float minX, maxX; //이동 제한 범위

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        minX = -Camera.main.orthographicSize * Camera.main.aspect;
        maxX = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        if (!isJump)
        {
            CheckMouseState();
        }
    }

    void LateUpdate()
    {
        LimitToMove();
    }

    void CheckMouseState()
    {
        //마우스 왼쪽 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
            startPos = transform.position;
            power = 0.0f;
        }

        //마우스 왼쪽 버튼을 누르고 있을 때
        if (Input.GetMouseButton(0) && isDown)
        {
            power += powerIncreaseRate * Time.deltaTime; //시간에 따라 파워 증가
            power = Mathf.Clamp(power, 0.0f, maxPower); //최대 파워 제한
        }

        //마우스 왼쪽 버튼을 놓았을 때
        if (Input.GetMouseButtonUp(0) && isDown)
        {
            isDown = false;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = (mousePos - startPos).normalized;
            Vector3 targetPos = startPos + dir * power;

            Shoot(targetPos);
        }
    }

    //targetPos로 플레이어를 발사하는 함수
    void Shoot(Vector3 targetPos)
    {
        isJump = true;
        animator.SetBool("isJumping", true);

        Vector3 dir = (targetPos - transform.position).normalized;
        Vector3 velocity = dir * power;

        rigidbody.velocity = velocity;
        rigidbody.velocity *= speed;
    }

    //플레이어가 땅과 접촉하면 점프 가능 상태로 변경하는 함수
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile") || collision.gameObject.CompareTag("StartTile"))
        {
            isJump = false;
            animator.SetBool("isJumping", false);
        }
    }

    //이동 제한 함수
    void LimitToMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
    }
}