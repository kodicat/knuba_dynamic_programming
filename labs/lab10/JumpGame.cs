namespace labs.lab10;

public static class JumpGame
{
    public static bool CanJump(int[] nums)
    {
        var n = nums.Length;
        var canJump = new bool[n];
        canJump[0] = true;

        for (var i = 0; i < n; i++)
        {
            if (!canJump[i])
                continue;

            var maxJump = Math.Min(n - 1, i + nums[i]);
            for (var j = i + 1; j <= maxJump; j++)
            {
                canJump[j] = true;
            }
        }

        return canJump[n - 1];
    }
}