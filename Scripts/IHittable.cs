using UnityEngine;

public interface IHittable
{
    void GetHit(int damageValue, GameObject sender);
}