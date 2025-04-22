using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName = "RPG Editor/New Skill")]
    public class SkillData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField, TextArea]
        public string Description { get; private set; }

        [field: SerializeField, PreviewField(Height = 100)] //sprite preview with editor height of 100px
        public Sprite Icon { get; private set; }

        [field: SerializeField]
        public float Cooldown { get; private set; } = 5f;

        [field: SerializeField]
        public int ManaCost { get; private set; } = 10;

        [field: SerializeField]
        public float CastDuration { get; private set; } = 1f;
    }
}
