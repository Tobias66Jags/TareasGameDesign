using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerClase : MonoBehaviour
{
    JsonClassSample jsonClassSample;

    Vector3 direction;
    CharacterController _controller;
    [SerializeField] private Transform _cam;

    public Transform handPos;
    public Transform swordPos;
   
    private Animator _animator;

    public bool hasWeapon = false;

    [Header("Physic Values")]

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _gravity = -9.81f;

    private float _currentSpeed = 0;

    [SerializeField] private float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;


    Vector3 velocity;



    private void Start()
    {
        jsonClassSample = GetComponent<JsonClassSample>();
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _currentSpeed = _speed;

        transform.position = jsonClassSample.playerInfo.sceneInfo.position;
        transform.rotation = jsonClassSample.playerInfo.sceneInfo.rotation;
        hasWeapon = jsonClassSample.playerInfo.hasWeapon;   

        if (hasWeapon)
        {
            GameObject sword = GameObject.FindGameObjectWithTag("Sword");
            Equip(sword);
        }
    }

    // Update is called once per frame
    void Update()
    {
      Movement();
        Attack();   
    }

    private void FixedUpdate()
    {
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Vector3.zero;

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _controller.Move(moveDir.normalized * _currentSpeed * Time.deltaTime);

        }
    }
    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        _animator.SetFloat("Speed", direction.magnitude);

        velocity.y += _gravity * Time.deltaTime;
        _controller.Move(velocity * Time.deltaTime);

    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            _animator.SetTrigger("Attack");
        }
    }

    void Equip(GameObject objectToEquip)
    {
        objectToEquip.transform.position = swordPos.position;
        objectToEquip.transform.rotation = swordPos.rotation;
        objectToEquip.transform.SetParent(handPos);
        _animator.SetLayerWeight(2, 1f);
        _animator.SetLayerWeight(3, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Equip(other.gameObject);
            hasWeapon = true;
        }

        if (other.CompareTag("Checkpoint"))
        {
            jsonClassSample.SavePlayerInfo(gameObject.transform.position, gameObject.transform.rotation, hasWeapon);
        }
    }

    void OnStep()
    {
        Debug.Log("Di un paso");
    }

}
