using UnityEngine;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName = "RPG Editor/New Weapon")]
    public class WeaponData : ItemData
    {
        [field: SerializeField]
        public int Damage { get; private set; } = 5;

        [field: SerializeField]
        public float AttackSpeed { get; private set; } = 1f;

        [field: SerializeField]
        public int Durability { get; private set; } = 100;

        [field: SerializeField]
        public float Range { get; private set; } = 1.5f;

        [field: SerializeField]
        public DamageType DamageType { get; private set; }
    }

    public enum DamageType
    {
        Physical,
        Fire,
        Cold,
        Lightning,
        Necrotic,
        Void,
        Psychic,
        True
    }
}
