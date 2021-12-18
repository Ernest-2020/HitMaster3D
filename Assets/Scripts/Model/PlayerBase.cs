using UnityEngine;

public abstract class  PlayerBase : MonoBehaviour
{
    public static RaycastHit _hit;
    public static int countEnemy;
    public abstract void GoPoint();
    public abstract void Fire();
    public abstract void GoFinish();
}
