using System.Collections;
using System.Collections.Generic;


public class WarfareData 
{
    public float _attackSpeed;
    public float _attackDamage;
    public float _range;
    public bool _canAttackFlying;
    
    public WarfareData(float attackSpeed, float attackDamage, float range, bool canAttackFlying)
    {
        _attackSpeed = attackSpeed;
        _attackDamage = attackDamage;
        _range = range;
        _canAttackFlying = canAttackFlying;
    }
}
