using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform Target;
    [SerializeField] private Transform TopBase;
    [SerializeField] private Transform BulletInitPoint;

    [Header("Rotation")]
    [SerializeField] private float TopRotationSpeed = 100;

    [SerializeField] private float certainThreshold;
    private Quaternion targetRotation;


    [Header("Shoot")]

    [SerializeField] private int AttackDamage = 10;

    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private float Rate;
    [SerializeField] private float BulletForce = 10;
    [SerializeField] private float AttackRange = 10;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator AnimShoot;

    private float _currentTime;

    private void Update()
    {
        FoundClosestEnemies();

        if (Target != null)
        {
            RotateTop();
            checkedTarget();

            AnimShoot.SetBool("Attack", true);

            if (_currentTime > Rate)
            {
                if (CanShot())
                {
                    _currentTime = 0;

                    Shoot();
                }
            }
            else
            {
                _currentTime += Time.deltaTime;
            }
        }
        else
        {
            AnimShoot.SetBool("Attack", false);
        }
    }
    private void checkedTarget()
    {
        if (Vector3.Distance(transform.position, Target.position) > AttackRange)
            Target = null;
    }
    private void FoundClosestEnemies()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, AttackRange, layerMask);
        float dist = Mathf.Infinity;

        foreach (var enemies in targets)
        {
            Vector3 diff = enemies.transform.position - transform.position;
            float currdist = diff.sqrMagnitude;

            if (currdist < dist)
            {
                Target = enemies.transform;
                dist = currdist;
            }
        }
    }
    private void RotateTop()
    {
        var direction = Target.position -
        new Vector3(TopBase.position.x, TopBase.position.y + 0.3f, TopBase.position.z);

        targetRotation = Quaternion.LookRotation(direction);

        TopBase.rotation = Quaternion.RotateTowards(TopBase.rotation, targetRotation, TopRotationSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        var bullet = Instantiate(BulletPrefab, BulletInitPoint.position, TopBase.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(BulletInitPoint.forward * BulletForce, ForceMode.Impulse);
        bullet.GetComponent<Bullet>().Damage = AttackDamage;
    }
    private bool CanShot()
    {
        if (Quaternion.Angle(targetRotation, TopBase.rotation) <= certainThreshold)
            return true;
        else
            return false;
    }
}
