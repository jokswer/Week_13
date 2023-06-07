using UnityEngine;

namespace Effects
{
    public abstract class Effect : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public int Level;
        [TextArea(1, 3)] public string Description;
    }
}
