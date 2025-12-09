using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("03 Nov 2022", 30, 3.0));  // 3 miles
        activities.Add(new Cycling("03 Nov 2022", 30, 12.0)); // 12 mph
        activities.Add(new Swimming("03 Nov 2022", 30, 20));  // 20 laps

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
