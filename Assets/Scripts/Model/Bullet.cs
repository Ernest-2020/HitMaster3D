using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _moveSpeed = 0.03f;
    private float _lifeTime;
    private float _maxLifeTime = 5f;
    

    private void OnEnable()
    {
        _lifeTime = 0;
    }

    void LateUpdate()
    {
        BulletMove();
        _lifeTime += Time.deltaTime;
        if (_lifeTime > _maxLifeTime)
        {
            WeaponShotPool.Instance.ReturnToPool(this);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            WeaponShotPool.Instance.ReturnToPool(this);
        }
    }
    public void BulletMove()
    {
        transform.position = Vector3.MoveTowards(transform.position,PlayerBase._hit.point, _moveSpeed);
    }
}
