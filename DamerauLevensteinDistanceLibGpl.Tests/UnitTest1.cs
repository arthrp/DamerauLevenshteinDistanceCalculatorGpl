using DamerauLevensteinDistanceLibGpl;

namespace DamerauLevensteinDistanceLib.Tests;

public class Tests
{
    [Test]
    public void SubstitutionAndInsertion_Detected()
    {
        var distance = DamerauLevenshteinDistanceCalculator.Calculate("hello", "hallo!");
        Assert.That(distance, Is.EqualTo(2));
    }
}