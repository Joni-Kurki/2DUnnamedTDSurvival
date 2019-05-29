/*-------------------------------------------------------------
 * Service which contains following data and can be called anywhere.
 * - SpawnData
 * - WarfareData
 * - StructureData
 */

using System.Collections;
using System.Collections.Generic;

public static class StoreService
{
    private static readonly List<StructureData> _structuresData = new List<StructureData>
    {
        //                TYPE                          HP
        new StructureData(Enums.StructureType.Spawner,  10000),
        new StructureData(Enums.StructureType.Warfare,  20)
    };

    private static readonly List<WarfareData> _warfareData = new List<WarfareData>
    {
        //              SPEED   DAMAGE  RANGE   CANATTACKFLYING
        new WarfareData(.8f,    3f,     1.5f,   false),
        new WarfareData(1f,     3f,     2f,     false),
    };

    private static readonly List<SpawnData> _spawnsData = new List<SpawnData>
    {
        //            ELEMENT                       TYPE                        RANGETYPE                   HP      DAMAGE  SPEED   RANGE
        new SpawnData(Enums.SpawnElement.NoElement, Enums.SpawnType.Normal,     Enums.RangeType.Melee,      20,     3,      1,      .25f),
        new SpawnData(Enums.SpawnElement.NoElement, Enums.SpawnType.Tank,       Enums.RangeType.Melee,      40,     1.5f,   .75f,   .25f),
        new SpawnData(Enums.SpawnElement.NoElement, Enums.SpawnType.Runner,     Enums.RangeType.Melee,      15,     5,      2,      .25f),
        new SpawnData(Enums.SpawnElement.NoElement, Enums.SpawnType.Flyer,      Enums.RangeType.Melee,      30,     3,      1.5f,   .25f),
        new SpawnData(Enums.SpawnElement.NoElement, Enums.SpawnType.Normal,     Enums.RangeType.Ranged,     15,     2.5f,   1,      .75f),
    };

    public static StructureData GetStructureData(Enums.StructureType type)
    {
        return _structuresData[(int)type];
    }

    public static WarfareData GetWarfareData(Enums.WarfareType type)
    {
        return _warfareData[(int)type];
    }

    public static SpawnData GetSpawnData(Enums.SpawnType type)
    {
        return _spawnsData[(int)type];
    }
}
