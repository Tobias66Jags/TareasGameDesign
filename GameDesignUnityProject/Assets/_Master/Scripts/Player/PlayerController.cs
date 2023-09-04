using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] private Transform _cam;

    [SerializeField] private Animator _animator;

    [Header("Physic Values")]

    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3f;

    private float _currentSpeed = 0;   

    [SerializeField] private float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

   

    Vector3 velocity;

   


    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _currentSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (_controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        velocity.y += _gravity * Time.deltaTime;

        _controller.Move(velocity * Time.deltaTime);

        if (Input.GetButton("Jump") && _controller.isGrounded)
        {
           // _anim.Play(_jumpAnim);
            velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
           
        }
        

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir=Vector3.zero;

               moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
                _controller.Move(moveDir.normalized * _currentSpeed * Time.deltaTime);
            
        }
    }


  public void TransportPLayer(Transform ToTransport)
    {
        _controller.enabled = false;
        this.gameObject.transform.position= ToTransport.position;
        _controller.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ice"))
        {
            StartCoroutine(iceBreak(other.gameObject));
        }
    }

    public IEnumerator iceBreak(GameObject IceBlock)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        IceBlock.SetActive(false);
    }

}
