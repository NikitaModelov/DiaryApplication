namespace DiaryApplication.Utills
{
    public enum LengthText
    {
        TypeLength = 20,
        TitleLength = 200,
        NameLength = 100,
        SubtitleLength = 150,
        DescriptionLength = 500,
    }

    public static class Validator
    {
        private const int TypeLength = 20;
        private const int TitleLength = 200;
        private const int NameLength = 100;
        private const int SubtitleLength = 150;
        private const int DescriptionLength = 500;

        public static bool ValidateTextField(string text, LengthText count)
        {
            text = text.Trim();
            switch (count)
            {
                case LengthText.DescriptionLength:
                    return text.Length <= DescriptionLength && text.Length > 0;
                case LengthText.NameLength:
                    return text.Length <= NameLength && text.Length > 0;
                case LengthText.SubtitleLength:
                    return text.Length <= SubtitleLength && text.Length > 0;
                case LengthText.TitleLength:
                    return text.Length <= TitleLength && text.Length > 0;
                case LengthText.TypeLength:
                    return text.Length <= TypeLength && text.Length > 0;
                default:
                    return text.Length > 0;
            }
            
        }
    }
}
