using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public void Fire()
    {
        var shot = WeaponShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
}
