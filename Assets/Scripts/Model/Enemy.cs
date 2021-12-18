using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]  private int _hp = 3;
    [SerializeField] private Rigidbody[] AllRigigbadys;
    private Collider _cllider;
    private Animator _animator;
    private int _damage = 1;

    private void Awake()
    {
        _cllider=GetComponent<Collider>();
        PlayerBase.countEnemy += 1;
        _animator = GetComponent<Animator>();
        for (int i = 0; i < AllRigigbadys.Length; i++)
        {
            AllRigigbadys[i].isKinematic = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage();
        }
    }
    private void Damage()
    {
        if (_hp==0)
        {
            PlayerBase.countEnemy -= 1;
            Ragdoll();
            _cllider.enabled = false;
        }
        else{_hp -= _damage;}
    }
    private void Ragdoll()
    {
        _animator.enabled = false;
        for (int i = 0; i < AllRigigbadys.Length; i++)
        {
            AllRigigbadys[i].isKinematic = false;
        }
    }
   
}
