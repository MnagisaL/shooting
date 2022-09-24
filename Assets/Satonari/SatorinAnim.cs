using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SatorinAnim : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float JumpForce=200;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpAnimation();
    }
    private void jumpAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 force = new Vector2(0, JumpForce);  //y²•ûŒü‚Ì‚İ”’l‚ğ‰Á‚¦‚é
            rb.AddForce(force);  //ƒWƒƒƒ“ƒv
            animator.SetTrigger("Jump");

        }
    }

}
 