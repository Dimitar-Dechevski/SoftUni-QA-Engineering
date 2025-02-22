namespace TestApp;
public class PalindromeFinder
{
    public static string GetPalindromes(List<string>? words)
    {
        if (words == null || words.Count == 0)
        {
            return string.Empty;
        }

        string result = string.Empty;
        for (int i = 0; i < words.Count; i++)
        {
            string word = words[i].ToLower();
            bool isPalindrome = true;

            for (int j = 0; j < word.Length / 2; j++)
            {
                if (word[j] != word[word.Length - 1 - j])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                result += $"{words[i]} ";
            }
        }

        return result.Trim();
    }
}

