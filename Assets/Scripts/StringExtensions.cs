public static class StringExtensions
{
    #region Static Functions
    public static string Remove(this string input, string removeString)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(removeString)) return input;
        int index = input.IndexOf(removeString);
        return index == -1 ? input : input.Remove(index, removeString.Length);
    }
    #endregion
}
