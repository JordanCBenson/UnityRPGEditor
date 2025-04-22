using Sirenix.OdinInspector;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName = "RPG Editor/New Class")]
    public class ClassData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField, TextArea]
        public string Description { get; private set; }

        [field: SerializeField, PreviewField(Height = 100)] //sprite preview with editor height of 100px
        public Sprite Icon { get; private set; }


        [field: SerializeField]
        public SkillData[] Skills {get; private set; }
    }
}
