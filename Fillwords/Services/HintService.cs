using Fillwords.Models;

public class HintService
{
    private const int MAX_HINTS_PER_LEVEL = 3;
    private readonly Dictionary<int, int> _hintsUsedByLevel;

    public HintService()
    {
        _hintsUsedByLevel = new Dictionary<int, int>();
    }

    public bool CanUseHint(Level level)
    {
        if (level == null) return false;
        int hintsUsed = GetHintsUsed(level);
        return hintsUsed < MAX_HINTS_PER_LEVEL && level.GetRemainingWords().Any();
    }

    public Word GetRandomUnfoundWord(Level level)
    {
        var remainingWords = level.GetRemainingWords();
        if (!remainingWords.Any()) return null;

        var random = new Random();
        return remainingWords[random.Next(remainingWords.Count)];
    }

    public void UseHint(Level level)
    {
        int hintsUsed = GetHintsUsed(level);
        _hintsUsedByLevel[level.LevelNumber] = hintsUsed + 1;
    }

    public int GetHintsUsed(Level level)
    {
        if (level == null) return 0;
        return _hintsUsedByLevel.ContainsKey(level.LevelNumber)
            ? _hintsUsedByLevel[level.LevelNumber]
            : 0;
    }

    public int GetHintsAvailable(Level level)
    {
        return MAX_HINTS_PER_LEVEL - GetHintsUsed(level);
    }

    public void ResetHintsForLevel(Level level)
    {
        if (level != null && _hintsUsedByLevel.ContainsKey(level.LevelNumber))
        {
            _hintsUsedByLevel.Remove(level.LevelNumber);
        }
    }
}