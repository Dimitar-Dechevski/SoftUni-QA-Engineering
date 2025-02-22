using System.Collections.Generic;
using System.Linq;

namespace TestApp;

public class Messaging
{
    public static string GetMessage(List<int>? nums, string? s)
    {
        if (nums is null || s is null || nums.Count == 0 || s.Length == 0)
        {
            return string.Empty;
        }

        string result = string.Empty;
        foreach (int n in nums)
        {
            int sum = n.ToString().Sum(c => c - '0');
            if (sum >= s.Length)
            {
                sum %= s.Length;
            }

            result += s[sum];
            s = s.Remove(sum, 1);
        }

        return result;
    }
}
