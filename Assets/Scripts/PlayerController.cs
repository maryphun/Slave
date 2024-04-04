using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Animator)), RequireComponent(typeof(Character))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isRunning = true;

    [HideInInspector] private Character characterScript;

    private void Start()
    {
        // reference
        characterScript = GetComponent<Character>();
        characterScript.Initialization();

        // reset
        Init();
    }

    private void Init()
    {
        isRunning = true; // running by default

        characterScript.PlayAnimation("PlayerIdle");
    }

    private void Update()
    {
        // input
        Vector3 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float magnitude = Mathf.Abs(moveInput.x);
        isRunning = !Input.GetKey(KeyCode.LeftShift);

        // move
        float moveSpeed = GlobalDefine.PlayerBaseMoveSpeed;
        if (!isRunning) moveSpeed *= 0.5f;

        if (magnitude > 0.1f) characterScript.MoveCharacter(moveInput.x, moveSpeed, true);

        // animation
        if (magnitude < 0.1f)
        {
            // idle
            characterScript.PlayAnimation("PlayerIdle");
        }
        else if (magnitude > 0.1f && isRunning)
        {
            // run
            characterScript.PlayAnimation("PlayerRun");
        }
        else if (magnitude > 0.1f && !isRunning)
        {
            // walk
            characterScript.PlayAnimation("PlayerWalk");
        }
    }
}
