using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    static readonly int IsSprinting = Animator.StringToHash("isSprinting");
    static readonly int IsStarting = Animator.StringToHash("isStarting");
    private Animator animator;

    void Start()
    {
        // 자식 오브젝트에서 Animator 컴포넌트를 찾아서 할당
        animator = GetComponentInChildren<Animator>();
    }

    public void setStarting(bool isStarting)
    {
        animator.SetBool(IsStarting, isStarting);
    }

    public void SetMoving(float moveAmount)
    {
        animator.SetFloat("moveAmount", moveAmount, 0.2f, Time.deltaTime); 
    }
    
    public void SetSprinting(bool isSprinting)
    {
        animator.SetBool(IsSprinting, isSprinting);
    }
    
    public bool SprintStop()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("SprintStop") && stateInfo.normalizedTime < 1.0f;
    }
}