using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] private int MoveSpeed = 10;

    private int _currentHealth;

    private Transform _target;
    public void Init(Transform target)
    {
        _target = target;
    }
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _currentHealth = MaxHealth;
        _agent.speed = MoveSpeed;
    }
    private void FixedUpdate()
    {
        if (CanReachPosition(_target.position))
            MoveNavMesh();
        else
            transform.position = Vector3.MoveTowards(transform.position, _target.position, MoveSpeed * Time.deltaTime);
    }
    private bool CanReachPosition(Vector3 position)
    {
        NavMeshPath path = new();
        _agent.CalculatePath(position, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }
    private void MoveNavMesh()
    {
        _agent.SetDestination(_target.position);
    }
    public void GetDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        Destroy(gameObject);
    }
}
