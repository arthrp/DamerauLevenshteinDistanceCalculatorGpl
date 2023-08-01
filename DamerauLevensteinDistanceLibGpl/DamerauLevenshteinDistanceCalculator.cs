namespace DamerauLevensteinDistanceLibGpl;

public static class DamerauLevenshteinDistanceCalculator
{
    public static int Calculate(string source, string target)
    {
        var srcLen = source.Length;
        var trgLen = target.Length;
        var distanceMatrix = new int[srcLen + 1, trgLen + 1];

        for (var i = 0; i <= srcLen; i++)
            distanceMatrix[i, 0] = i;

        for (var j = 0; j <= trgLen; j++)
            distanceMatrix[0, j] = j;

        for (var i = 1; i <= srcLen; i++)
        {
            for (var j = 1; j <= trgLen; j++)
            {
                var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
                
                distanceMatrix[i, j] = Math.Min(
                    Math.Min(
                        distanceMatrix[i - 1, j] + 1,    // deletion
                        distanceMatrix[i, j - 1] + 1),   // insertion
                        distanceMatrix[i - 1, j - 1] + cost); // substitution

                if (i > 1 && j > 1 && source[i - 1] == target[j - 2] && source[i - 2] == target[j - 1])
                {
                    // transposition
                    distanceMatrix[i, j] = Math.Min(distanceMatrix[i, j], distanceMatrix[i - 2, j - 2] + cost);
                }
            }
        }

        return distanceMatrix[srcLen, trgLen];
    }
}