using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator))]
public class Enemy : MonoBehaviour
{
    private Patrol _patrol;
    private EnemyMover _mover;

    private void Awake()
    {
        _patrol = GetComponent<Patrol>();
        _mover = GetComponent<EnemyMover>();
    }

    private void Start()
    {
        _mover.GoToPoints(_patrol.GivePoints());
    }
}
