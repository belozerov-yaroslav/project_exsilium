namespace DialogueSystem
{
    public class DialogueLine
    {
        public Author Author;
        public string Text;

        public override string ToString()
        {
            return Author != null ? $"{"".PadLeft(Author.authorName.Length * 2 + 2, ' ')} {Text}" : Text;
        }
    }
}