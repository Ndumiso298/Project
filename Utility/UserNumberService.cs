using System;
using System.Collections.Generic;

public class UserNumberService : IUserNumberService
{
    private static readonly Dictionary<string, int> _dailyCount = new();

    public string GenerateUserNumber(string role)
    {
        string today = DateTime.Now.ToString("yyyyMMdd");

        // Create a unique key per role per day (example: Employee_20251005)
        string key = $"{role}_{today}";

        if (_dailyCount.ContainsKey(key))
            _dailyCount[key]++;
        else
            _dailyCount[key] = 1;

        int count = _dailyCount[key];

        if (role == "Employee")
            return $"EMP-{today}-{count:000}";
        else if (role == "Customer")
            return $"CUS-{today}-{count:000}";
        else
            return $"USR-{today}-{count:000}";
    }
}
