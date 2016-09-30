namespace IdiomaticCsApi.Domain.Battles.Comparing
{
    public interface IComparer<T>
    {
        int GetLowest(T valueA, T valueB);
        bool TryGetLowest(out T result, T valueA, T valueB);
    }
}
