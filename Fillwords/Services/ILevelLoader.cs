using Fillwords.Models;
using System.Collections.Generic;

namespace Fillwords.Services
{
    public interface ILevelLoader
    {
        Level LoadLevel(int levelNumber);
        List<Level> LoadAllLevels();
        bool LevelExists(int levelNumber);
        int GetTotalLevelsCount();
    }
}