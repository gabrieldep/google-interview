using System.Diagnostics.CodeAnalysis;

namespace FirstInterview;

public static class FriendsGroup
{
    public static int GoogleExample()
    {
        var arr = new int[5][];
        arr[0] = new int[] { 0, 1 };
        arr[1] = new int[] { 1, 2 };
        arr[2] = new int[] { 2, 0 };
        arr[3] = new int[] { 3, 4 };
        arr[4] = new int[] { 4, 5 };
        return GetFriendsGroup(arr);
    }

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    private static int GetFriendsGroup(int[][] arr)
    {
        var groups = new List<HashSet<int>>();

        for (var i = 1; i < arr.Length; i++)
        {
            var grupo1 = new HashSet<int>();
            var grupo2 = new HashSet<int>();

            foreach (var group in groups)
            {
                if (group.Contains(arr[i][0]))
                    grupo1 = group;
                else if (group.Contains(arr[i][1]))
                    grupo2 = group;
            }

            if (grupo1.Count != 0 && grupo2.Count == 0)
                grupo1.Add(arr[i][1]);
            else if (grupo1.Count == 0 && grupo2.Count != 0)
                grupo1.Add(arr[i][0]);
            else if (grupo1.Count != 0 && grupo2.Count != 0)
            {
                grupo1.UnionWith(grupo2);
                groups.Remove(grupo2);
            }
            else if (grupo1.Count == 0 && grupo2.Count == 0)
            {
                var hash = new HashSet<int>() { arr[i][0], arr[i][1] };
                groups.Add(hash);
            }
        }

        return groups.Count;
    }
}