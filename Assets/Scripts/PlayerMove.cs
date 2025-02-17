using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movespeed;
    [SerializeField] PlayerAnimController animController;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float dashCD;
    [SerializeField] float dashForce;
    Vector2 input;
    float dashTimer;
    bool isDashing;
    void Start()
    {
        animController.EndDashEvent += EndDash;
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animController.SetIsMoving(input.magnitude > 0);
        animController.SetIsVertical(input.x == 0 && Mathf.Abs(input.y) > 0);
        
        if(Mathf.Abs(input.x) > 0){
            sprite.transform.right = input.x > 0 ? Vector3.right : Vector3.left;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0){
            Dash();
            dashTimer = dashCD;
            isDashing = true;
        }

        dashTimer -= Time.deltaTime;
    }

    void FixedUpdate() 
    {
        if(!isDashing){
            rb.linearVelocity = input.normalized * movespeed;
        }
    }

    void Dash(){
        rb.AddForce(sprite.transform.right * dashForce, ForceMode2D.Impulse);
        animController.TriggerDash();
    }

    void EndDash(){
        isDashing = false;
    }
}
