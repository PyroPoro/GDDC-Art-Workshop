using System;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator anim;
    public event Action EndDashEvent = delegate{};
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetIsMoving(bool isMoving){
        anim.SetBool("isMoving", isMoving);
    }

    public void SetIsVertical(bool isVertical){
        anim.SetBool("isVertical", isVertical);
    }

    public void TriggerDash(){
        anim.SetTrigger("dash");
    }

    public void StartDash(){
        anim.SetBool("isDashing", true);
    }

    public void EndDash(){
        anim.SetBool("isDashing", false);
        EndDashEvent();
    }
}
