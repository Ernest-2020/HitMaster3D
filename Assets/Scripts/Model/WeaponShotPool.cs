using System.Collections.Generic;
using UnityEngine;

public class WeaponShotPool : MonoBehaviour
{
    [SerializeField] private Bullet _weaponShotPrefab;

    private Queue<Bullet> _weaponShots = new Queue<Bullet>();
    public static WeaponShotPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Bullet Get()
    {
        if (_weaponShots.Count==0)
        {
            AddShots(1);
        }
        return _weaponShots.Dequeue();
    }

    private void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet weaponShot = Instantiate(_weaponShotPrefab);
            weaponShot.gameObject.SetActive(false);
            _weaponShots.Enqueue(weaponShot);
        }
    }

    public void ReturnToPool(Bullet weaponShot)
    {
        weaponShot.gameObject.SetActive(false);
        _weaponShots.Enqueue(weaponShot);
    }
}
