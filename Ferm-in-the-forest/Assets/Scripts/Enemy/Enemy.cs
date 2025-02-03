using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private int MaxHealth = 100;
    [SerializeField] private int MoveSpeed = 10;

    private int _currentHealth;

    private Transform _target;
    private bool _isGround;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _currentHealth = MaxHealth;
        _agent.speed = MoveSpeed;
    }

    private void Update()
    {
        if (_isGround == false)
        {
            _moveTranslate();
        }
        else
        {
            if (CanReachPosition(_target.position))
                _moveNavMesh();
            else
                _moveTranslate();
        }
    }
    private bool CanReachPosition(Vector2 position)
    {
        NavMeshPath path = new NavMeshPath();
        _agent.CalculatePath(position, path);
        return path.status == NavMeshPathStatus.PathComplete;
    }
    private void _moveTranslate()
    {
        transform.LookAt(_target);
        transform.Translate(transform.forward * MoveSpeed * Time.deltaTime, Space.World);
    }
    private void _moveNavMesh()
    {
        _agent.SetDestination(_target.position);
    }

    public void Init(Transform target)
    {
        _target = target;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            _agent.enabled = true;
            _isGround = true;
        }
    }
}
