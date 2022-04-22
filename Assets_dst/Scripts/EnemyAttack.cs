using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] private bool hasMelee;
    [SerializeField] private bool hasRanged;
    [SerializeField] private bool hasBumping;

    [Header("Bumping Config")]
    [SerializeField] private float BumpingDamageInterval;
    [SerializeField] private float BumpingCooldown;
    [SerializeField] private int BumpingDamage;

    [Header("Melee Config")]
    [SerializeField] private float MeleeCooldown;
    [SerializeField] private float MeleeRangeX;
    [SerializeField] private float MeleeRangeY;
    [SerializeField] private float MeleeRangeXOffset;
    [SerializeField] private float MeleeRangeYOffset;
    [SerializeField] private int MeleeDamage;

    [Header("Ranged Config")]
    [SerializeField] private bool RangedUpwards;
    [SerializeField] private float HeightRangeModifyer;
    [SerializeField] private float RangedCooldown;
    [SerializeField] private float RangedRangeX;
    [SerializeField] private float RangedRangeY;
    [SerializeField] private float ShootingIdleTime;
    [SerializeField] private GameObject RangedProjectile;

    private bool inCollision = false;
    private bool BumpingOnCooldown = false;
    private bool MeleeOnCooldown = false;
    private bool RangedOnCooldown = false;
    private EnemyMovement movement;

    // Start is called before the first frame update
    void Awake()
    {
        //ignore collison in enemy layer
        Physics2D.IgnoreLayerCollision(11, 11);
        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        if (this.GetComponent<EnemyMovement>().facingRight == true && MeleeRangeX < 0)
        {
            MeleeRangeX *= -1;
            RangedRangeX *= -1;
        }
        else if (this.GetComponent<EnemyMovement>().facingRight == false && MeleeRangeX > 0)
        {
            MeleeRangeX *= -1;
            RangedRangeX *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        if (hasMelee)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireCube(new Vector3(this.gameObject.transform.position.x + MeleeRangeX / 2 + MeleeRangeXOffset, this.gameObject.transform.position.y + MeleeRangeYOffset, 0), new Vector3(MeleeRangeX, MeleeRangeY, 0));
        }

        if (hasRanged)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(new Vector3(this.gameObject.transform.position.x + RangedRangeX / 2, this.gameObject.transform.position.y, 0), new Vector3(RangedRangeX, RangedRangeY, 0));
            if (RangedUpwards)
            {
                Gizmos.DrawWireCube(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Mathf.Abs(RangedRangeX / HeightRangeModifyer / 2), 0), new Vector3(RangedRangeY, Mathf.Abs(RangedRangeX / HeightRangeModifyer), 0));
            }
        }
    }

    private void FixedUpdate()
    {
        if (hasMelee)
        {
            MeleeAttack();
        }

        if (hasRanged)
        {
            RangedAttack();
        }

    }

    private void RangedAttack()
    {
        if (RangedOnCooldown == false)
        {
            Collider2D[] collidersSide = Physics2D.OverlapBoxAll(new Vector3(this.gameObject.transform.position.x + RangedRangeX / 2, this.gameObject.transform.position.y, 0), new Vector3(RangedRangeX, RangedRangeY, 0), 0);
            foreach (var item in collidersSide)
            {
                if (item.gameObject.tag == "Player")
                {
                    //start animator do execute attack animation and trigger damage after time
                    //item.gameObject.GetComponent<Health>().Damage(MeleeDamage);
                    Vector3 ArrowSpawn = new Vector3(this.transform.position.x + 0.3f * RangedRangeX / Mathf.Abs(RangedRangeX), this.transform.position.y, 0f);

                    float rot;
                    if (RangedRangeX < 0)
                    {
                        rot = 0;
                    }
                    else
                    {
                        rot = 180;
                    }

                    Instantiate(RangedProjectile, ArrowSpawn, Quaternion.Euler(new Vector3(0, 0, rot)));
                    StartCoroutine(ShootingIdle());
                    StartCoroutine(RangedCooldownRoutine());
                }
            }
            if (RangedUpwards)
            {
                Collider2D[] collidersUp = Physics2D.OverlapBoxAll(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + Mathf.Abs(RangedRangeX / HeightRangeModifyer / 2), 0), new Vector3(RangedRangeY, Mathf.Abs(RangedRangeX / HeightRangeModifyer), 0), 0);
                foreach (var item in collidersUp)
                {
                    if (item.gameObject.tag == "Player")
                    {
                        Vector3 ArrowSpawn = new Vector3(this.transform.position.x, this.transform.position.y + this.transform.localScale.y / 2 + 0.3f, 0f);

                        //arrow should delay spawn until player is really above him because accuraccy is low af but idc michi job
                        //this code will be rewriten by michi or toni on 20.2.2022
                        Instantiate(RangedProjectile, ArrowSpawn, Quaternion.Euler(new Vector3(0, 0, 90)));
                        StartCoroutine(ShootingIdle());
                        StartCoroutine(RangedCooldownRoutine());
                    }
                }
            }
        }
    }

    private IEnumerator RangedCooldownRoutine()
    {
        RangedOnCooldown = true;
        yield return new WaitForSeconds(RangedCooldown);
        RangedOnCooldown = false;

    }

    private IEnumerator ShootingIdle()
    {
        movement.inAttack = true;
        yield return new WaitForSeconds(ShootingIdleTime);
        movement.inAttack = false;

    }

    private void MeleeAttack()
    {
        if (MeleeOnCooldown == false)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector3(this.gameObject.transform.position.x + MeleeRangeX / 2 + MeleeRangeXOffset, this.gameObject.transform.position.y + MeleeRangeYOffset, 0), new Vector3(MeleeRangeX, MeleeRangeY, 0), 0);
            foreach (var item in colliders)
            {
                if (item.gameObject.tag == "Player")
                {
                    //start animator do execute attack animation and trigger damage after time
                    //item.gameObject.GetComponent<Health>().Damage(MeleeDamage);
                    StartCoroutine(DoDamageDelay());
                    StartCoroutine(MeleeCooldownRoutine());
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasBumping == true && BumpingOnCooldown == false)
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                inCollision = true;
                StartCoroutine(ContinousDamage(collision));
                StartCoroutine(BumpingCooldownRoutine());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        inCollision = false;
        StopCoroutine(ContinousDamage(collision));
    }

    private IEnumerator ContinousDamage(Collision2D collision)
    {
        while (inCollision)
        {
            collision.gameObject.GetComponent<Health>().Damage(BumpingDamage);
            yield return new WaitForSeconds(BumpingDamageInterval);
        }
    }

    private IEnumerator MeleeCooldownRoutine()
    {
        MeleeOnCooldown = true;
        yield return new WaitForSeconds(MeleeCooldown);
        MeleeOnCooldown = false;

    }

    private IEnumerator DoDamageDelay()
    {
        movement.inAttack = true;
        yield return new WaitForSeconds(1);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector3(this.gameObject.transform.position.x + MeleeRangeX / 2 + MeleeRangeXOffset, this.gameObject.transform.position.y + MeleeRangeYOffset, 0), new Vector3(MeleeRangeX, MeleeRangeY, 0), 0);
        foreach (var item in colliders)
        {
            if (item.gameObject.tag == "Player")
            {
                //start animator do execute attack animation and trigger damage after time
                item.gameObject.GetComponent<Health>().Damage(MeleeDamage);
                StartCoroutine(MeleeCooldownRoutine());
            }
        }
        movement.inAttack = false;
    }

    //could be removed if knockback on damage is added
    private IEnumerator BumpingCooldownRoutine()
    {
        BumpingOnCooldown = true;
        yield return new WaitForSeconds(BumpingCooldown);
        BumpingOnCooldown = false;
    }
}
