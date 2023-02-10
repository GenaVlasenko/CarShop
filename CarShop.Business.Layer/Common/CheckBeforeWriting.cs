namespace CarShop.Business.Layer.Common
{
    public static class CheckBeforeWriting
    {

        internal static bool HasInvalidCharacters(dynamic word)
        {
            string special_characters = @"~`!@#$%^&*/()_+Ё!\,<.>/?';][}{|=-";
            foreach (var item in word)
            {
                foreach (var chars in special_characters)
                {
                    if (item == chars)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
