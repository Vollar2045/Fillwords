using Fillwords.Models;

public class HintService
{
    private const int MAX_HINTS_PER_LEVEL = 3;
    private readonly Dictionary<int, int> _hintsUsedByLevel;
    private readonly Dictionary<int, List<string>> _hintedWordsByLevel; // Слова которые уже подсказывали

    public HintService()
    {
        _hintsUsedByLevel = new Dictionary<int, int>();
        _hintedWordsByLevel = new Dictionary<int, List<string>>();
    }

    public bool CanUseHint(Level level)
    {
        if (level == null) return false;
        int hintsUsed = GetHintsUsed(level);
        return hintsUsed < MAX_HINTS_PER_LEVEL && GetHintableWords(level).Any();
    }

    public Word GetRandomUnfoundWord(Level level)
    {
        var hintableWords = GetHintableWords(level);
        if (!hintableWords.Any()) return null;

        var random = new Random();
        return hintableWords[random.Next(hintableWords.Count)];
    }

    private List<Word> GetHintableWords(Level level)
    {
        var remainingWords = level.GetRemainingWords();

        // Исключаем слова которые уже подсказывали
        if (_hintedWordsByLevel.ContainsKey(level.LevelNumber))
        {
            var alreadyHinted = _hintedWordsByLevel[level.LevelNumber];
            return remainingWords.Where(w => !alreadyHinted.Contains(w.Text)).ToList();
        }

        return remainingWords;
    }

    public void UseHint(Level level, Word word)
    {
        int hintsUsed = GetHintsUsed(level);
        _hintsUsedByLevel[level.LevelNumber] = hintsUsed + 1;

        // Запоминаем что это слово уже подсказывали
        if (!_hintedWordsByLevel.ContainsKey(level.LevelNumber))
        {
            _hintedWordsByLevel[level.LevelNumber] = new List<string>();
        }
        _hintedWordsByLevel[level.LevelNumber].Add(word.Text);
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
        if (level != null)
        {
            if (_hintsUsedByLevel.ContainsKey(level.LevelNumber))
            {
                _hintsUsedByLevel.Remove(level.LevelNumber);
            }
            if (_hintedWordsByLevel.ContainsKey(level.LevelNumber))
            {
                _hintedWordsByLevel.Remove(level.LevelNumber);
            }
        }
    }
}