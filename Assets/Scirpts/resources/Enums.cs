public class Enums 
{

    public enum MapChunkType
    {
        MonsterSpawner = 0,
        Initial = 1,
        Empty_Buildable = 2,
        Empty_NotBuildable = 3,
    }

    public enum MapTileState {
        Empty = 0,
        Struture = 1
    }

    public enum StructureType {
        Spawner = 0,
        Warfare = 1
    }

    public enum SpawnState
    {
        DoNothing = 0, 
        LookForTarget = 1,
        MoveToTarget = 2,
        DamageTarget = 3
    }

    public enum SpawnType
    {
        Normal = 0,
        Tank = 1,
        Runner = 2,
        Flyer = 3,
    }

    public enum RangeType
    {
        Melee = 0,
        Ranged = 1
    }

    public enum SpawnElement
    {
        NoElement = 0,
        Fire = 1,
        Water = 2,
        Air = 3,
        Earth = 4
    }

    public enum WarfareType
    {
        NormalTower = 0,
        QuickTower = 1,
        FatTower = 2
    }

    public enum WarfareState
    {
        Idle = 0,
        LookForTargetInRange = 1,
        Shoot = 2,
    }

}
