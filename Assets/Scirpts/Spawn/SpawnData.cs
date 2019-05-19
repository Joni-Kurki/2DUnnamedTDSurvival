using System.Collections;
using System.Collections.Generic;

public class SpawnData 
{

    public Enums.SpawnElement _element;
    public Enums.SpawnType _type;
    public Enums.RangeType _rangeType;

    public float _hp;
    public float _damage;
    public float _speed;
    public float _range;

    public SpawnData(Enums.SpawnElement element, Enums.SpawnType type, Enums.RangeType rangeType, float hp, float damage, float speed, float range)
    {
        _element = element;
        _type = type;
        _rangeType = rangeType;
        _hp = hp;
        _damage = damage;
        _speed = speed;
        _range = range;
    }

}
