using System;
using System.Collections.Generic;
using System.Linq;
using Ink.Parsed;
using UnityEngine;

namespace DialogueSystem
{
    [Serializable]
    public class DialogueParser
    {
        [SerializeField] private List<Author> _authors;

        public DialogueLine ParseLine(string text, IEnumerable<string> tags)
        {
            var dialogueLine = new DialogueLine { Text = text };
            foreach (var tag in tags)
            {
                if (tag.Split(':').Length != 2)
                    throw new FormatException($"Wrong tag format for line: {text}, tag: {tag}");
                var tagName = tag.Split(':')[0].Trim();
                var tagValue = tag.Split(':')[1].Trim();
                switch (tagName)
                {
                    case "author":
                        dialogueLine.Author = _authors.Find(author => author.tag == tagValue);
                        break;
                    default:
                        Debug.LogWarning($"Cant parse tag: {tag}");
                        break;
                }
            }

            return dialogueLine;
        }
    }
}