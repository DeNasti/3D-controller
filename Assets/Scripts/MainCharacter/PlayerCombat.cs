using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Combat();
    }


    void Combat()
    {
        if (Input.GetButtonDown("Fire2"))       
        {
            animator.SetBool("Defend", true);
        }

        else if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("Defend", false);
        }

        else if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

    }


    //  [Obsolete()]
    void Combat_old()
    {

        if (Input.GetButtonDown("Fire2"))       //TO DO set defense state
            animator.SetBool("Defend", true);

        else if (Input.GetButtonUp("Fire2"))
            animator.SetBool("Defend", false);

        else if (Input.GetButtonDown("Fire1"))
        {  
            //trying to attack

                if (!IsPlayingAttackAnimation())
                {     
                    animator.SetTrigger("Attack");
                }
        }
    }

    bool IsPlayingAttackAnimation()
    {
        return (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"));
    }
}
