using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 100;

    private int _currentHealth;

    private Transform _target;

    private void Start()
    {
        _currentHealth = MaxHealth;
    }
    public void Init()
    {

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
