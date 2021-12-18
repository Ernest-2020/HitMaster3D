using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : PlayerBase
{
    [SerializeField] private List<Transform> PlayerPoints;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Bullet _weaponShot;
    [SerializeField] Camera _camera;
    private bool _goFiring = true;
    private NavMeshAgent _agentPlayer;
    private Animator _animator;
    private float _minDistanse = 0.4f;
    Ray ray;
    void Start()
    {
        _agentPlayer = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    public override void GoPoint()
    {
        if (Input.GetMouseButtonDown(0) && _goFiring)
        {
            _agentPlayer.destination = PlayerPoints[1].position;
            _animator.SetBool("Run", true);
        }
    }

    public override void Fire()
    {
        if (Vector3.Distance(transform.position, PlayerPoints[1].position) < _minDistanse)
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Aim", true);
            _goFiring = false;
            if (Input.GetMouseButtonDown(0))
            {
                ray = _camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out _hit);
                transform.LookAt(_hit.transform);
                _weapon.Fire();
            }
        }
    }

    public override void GoFinish()
    {
        if (countEnemy == 0)
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Aim", false);
            _agentPlayer.destination = PlayerPoints[2].position;
            if (Vector3.Distance(transform.position, PlayerPoints[2].position) < _minDistanse)
            {
                _animator.SetBool("Run", false);
                SceneManager.LoadScene(0);
            }
        }
    }
}
