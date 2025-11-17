namespace Fillwords.Services
{
    public interface IProgressService
    {
        int GetCurrentLevel();
        void SaveCurrentLevel(int level);
        void ResetProgress();
        bool ProgressExists();
    }
}