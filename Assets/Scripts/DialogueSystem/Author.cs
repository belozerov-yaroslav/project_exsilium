using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Author")]
    public class Author : ScriptableObject
    {
        public Color Color;
        public string authorName;
        public string tag;
        
    }
}