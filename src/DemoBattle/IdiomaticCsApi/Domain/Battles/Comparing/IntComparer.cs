namespace IdiomaticCsApi.Domain.Battles.Comparing
{
    public class IntComparer : IComparer<int>
    {
        public int GetLowest(int valueA, int valueB)
        {
            var compareResult = valueA.CompareTo(valueB);
            if (compareResult > 0)
            {
                return valueB;
            }

            return valueA;
        }

        public bool TryGetLowest(out int result, int valueA, int valueB)
        {
            var compareResult = valueA.CompareTo(valueB);
            if (compareResult > 0)
            {
                result = valueB;
                return true;
            }
            if (compareResult < 0)
            {
                result = valueA;
                return true;
            }
            result = -1;
            return false;
        }
    }
}