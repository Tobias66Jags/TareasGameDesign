using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    public PlayerHealth playerHealth;


    public Animator animator;

    public float attackTime=1;
    public float jumpTime=1;

    [Header("Animations")]

    // [SerializeField] private Animator _anim;
    [SerializeField] private string _idleAnim,_jumpAnim, _runAnim, _attackAnim;

    public enum PlayerState
    {
        Idle, Running, Attack, Jump
    }

    public PlayerState currentState;

    private void Start()
    {
        currentState = PlayerState.Idle;
      

    }


    private Dictionary<string, KeyCode> keyMap = new Dictionary<string, KeyCode>()
        {
            { "Ww", KeyCode.W },
            { "Wa", KeyCode.A },
            { "Ws", KeyCode.S },
            { "Wd", KeyCode.D },
            { "Attack", KeyCode.Mouse0 },
            {"Jump", KeyCode.Space },
          
        };

    private void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                Idle();
                break;

            case PlayerState.Running:
                Run();
                break;

            case PlayerState.Attack:
                Attack();
                break;

            case PlayerState.Jump:
                Jump();
                break;

           
            default:
                break;
        }
    }

    public void Idle()
    {
        animator.Play(_idleAnim);
        GetKeepKey("Ww", PlayerState.Running);
        GetKeepKey("Wa", PlayerState.Running);
        GetKeepKey("Ws", PlayerState.Running);
        GetKeepKey("Wd", PlayerState.Running);

        GetKey("Attack", PlayerState.Attack);
        GetKey("Jump", PlayerState.Jump);

        playerHealth.canGetDamage = true;
    }
    public void Run()
    {
        playerHealth.canGetDamage = true;

        animator.Play(_runAnim);
        UpKey("Ww", PlayerState.Idle);
        UpKey("Wa", PlayerState.Idle);
        UpKey("Ws", PlayerState.Idle);
        UpKey("Wd", PlayerState.Idle);

        GetKey("Attack", PlayerState.Attack);
        GetKey("Jump", PlayerState.Jump);

    }
    public void Attack()
    {
        playerHealth.canGetDamage = false;

        animator.Play(_attackAnim);
        GetKey("Jump", PlayerState.Jump);
        StartCoroutine(WaitToState(PlayerState.Idle, attackTime));
    }
    public void Jump()
    {
        playerHealth.canGetDamage = false;

        animator.Play(_jumpAnim);
        StartCoroutine(WaitToState(PlayerState.Idle, jumpTime));
    }


    void GetKey(string key, PlayerState state)
    {
        if (keyMap.ContainsKey(key) && Input.GetKeyDown(keyMap[key]))
        {
            currentState = state;
        }
    }
    void GetKeepKey(string key, PlayerState state)
    {
        if (keyMap.ContainsKey(key) && Input.GetKey(keyMap[key]))
        {
            currentState = state;
        }
    }
    void UpKey(string key, PlayerState state)
    {
        if (keyMap.ContainsKey(key) && Input.GetKeyUp(keyMap[key]))
        {
            currentState = state;
        }
    }

    public IEnumerator WaitToState(PlayerState state, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        currentState = state;
        StopAllCoroutines();
    }
}
