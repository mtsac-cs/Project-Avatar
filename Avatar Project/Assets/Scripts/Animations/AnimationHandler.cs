using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Passes data to the Animator to play animations bases on what is passed
/// add to player movement later
/// </summary>
public class AnimationHandler : MonoBehaviour
{
    Controls controls ;
    public Animator animator;
    // Start is called before the first frame update
    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();
    private void Awake() {
        controls= new Controls();
    }
    void Start()
    {
        if(animator == null){
            Debug.Log($"animator in {this.gameObject.name} is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocityX",controls.Player.Move.ReadValue<Vector2>().x);
        animator.SetFloat("velocityY",controls.Player.Move.ReadValue<Vector2>().y);
        Debug.Log(animator.GetFloat("velocityX"));
        Debug.Log(animator.GetFloat("velocityY"));
    }

    void PlayAnimation(string animationName){
        animator.Play(animationName);
    }
}
