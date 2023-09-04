using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStates;

public class Enemy : MonoBehaviour
{
    public SphereCollider sC;

    Rigidbody _rb;

    Animator _anim;

    Transform _player;

    Vector3 _directionToPlayer;

    public bool isLookPlayer; 

    public float timer = 1;
    public float attackTime = 1;
    public float runSpeed = 1;
    public float idleSpeed = 0;

    public float distanceToPursuit = 1;
    public float distanceToUnfollow = 1;

    private float currentSpeed = 0;
    [Header("Animations")]

    // [SerializeField] private Animator _anim;
    [SerializeField] private string _idleAnim, _runAnim, _attackAnim, _dieAnim;

    public enum EnemyState
    {
        Idle, Pursuit, Attack, Die,
    }

    public EnemyState currentState;

   

    


    private void Start()
    {
        currentState = EnemyState.Idle;

        currentSpeed = idleSpeed;

        isLookPlayer = false;

        _rb = GetComponent<Rigidbody>(); 
        _anim = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("PlayerPos").transform;
    }
    private void Update()
    {
       _directionToPlayer = _player.position - transform.position;

        if (isLookPlayer)
        {
            transform.LookAt(new Vector3(_player.position.x, transform.position.y, _player.position.z));

        }
     
        switch (currentState)
        {
            case EnemyState.Idle:
                OnIdle();
                break;

            case EnemyState.Attack:
                OnAttack();
                break;

            case EnemyState.Pursuit:
                OnPursuit();
                break;

            case EnemyState.Die:
                OnDie();
                break;
            default:
                break;
        }
    }

    public void OnIdle()
    {
        _anim.Play(_idleAnim);
        isLookPlayer = false;
        currentSpeed = idleSpeed;

        Debug.Log(Vector3.Distance(_rb.transform.position, _player.position));

        if (Vector3.Distance(_rb.transform.position,_player.position)<=distanceToPursuit)
        {
            currentState = EnemyState.Pursuit;
        }
    }

    public void OnPursuit()
    {
        currentSpeed = runSpeed;
        _anim.Play(_runAnim);

        isLookPlayer = true;
        // Calcula la dirección hacia el objetivo
        Vector3 direction = (_player.position - transform.position).normalized;

        // Calcula la posición objetivo usando la dirección y la velocidad
        Vector3 posicionObjetivo = transform.position + direction * currentSpeed * Time.deltaTime;

        // Mueve el objeto hacia la posición objetivo usando MovePosition
        _rb.MovePosition(posicionObjetivo);

        StartCoroutine(WaitToState(EnemyState.Attack, timer));
    }

    public void OnAttack()
    {
        _anim.Play(_attackAnim);
        isLookPlayer = false;
        StartCoroutine(WaitToState(EnemyState.Idle, attackTime));
    }  
    public void OnDie()
    {
        StopAllCoroutines();
        isLookPlayer= false;
        _anim.Play(_dieAnim);
        sC.enabled = false;

    }


    public IEnumerator WaitToState(EnemyState state, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        currentState = state;
        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword")|| other.CompareTag("DeadZone"))
        {
            currentState = EnemyState.Die;
        }
    }
}
