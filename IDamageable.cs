using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T>
{
    void Damage(T Spell_Damage);
}

public interface IdamageableStatus<u, y>: IDamageable<float>
{
    void Status(u Status_Effect, y duration);
}
