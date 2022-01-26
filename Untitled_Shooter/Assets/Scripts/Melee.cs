using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float timeBetweenMelee;
    public float startTimeBetweenMelee;

    public Transform meleePos;
    public float meleeRange;
    public LayerMask whatIsEnemy;
    //Referenced tutorial uses LayerMask to detect enemy in a set layer. Used in 2d side-to-side; might not be needed here.
    public int meleeDamage;

    void Update()
    {
        if(timeBetweenMelee <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(meleePos.position, meleeRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(meleeDamage);
                }
            }

            //you can attack
            timeBetweenMelee = startTimeBetweenMelee;
        }

        else
        {
            timeBetweenMelee -= Time.deltaTime;
        }

        
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(meleePos.position, meleeRange);
        //Gizmo not appearing, sad. Radius working though
    }
}
