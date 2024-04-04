using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer)), 
    RequireComponent(typeof(Animator)), 
    RequireComponent(typeof(Transform))]
public class Character : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private string characterName;

    [Header("Debug")]
    [SerializeField] private bool isInitialized = false;
    [SerializeField] private string currentAnimation;


    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] public bool isFaceLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        if (isInitialized) return;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        isFaceLeft = true;
        
        // done initialization
        isInitialized = true;
    }

    // Common Methods
    public void MoveCharacter(float direction, float speed, bool changeFacing = true)
    {
        transform.position = transform.position + new Vector3(direction * speed * Time.deltaTime, transform.position.y, transform.position.z);

        // change facing
        if (changeFacing)
        {
            isFaceLeft = direction <= 0.0f;
            spriteRenderer.flipX = !isFaceLeft;
        }
    }

    public void PlayAnimation(string animationName, bool resetIfSame = false)
    {
        if (!resetIfSame && currentAnimation == animationName) return;

        animator.Play(animationName);
        currentAnimation = animationName;
    }
}
