namespace AspNetCoreServerSide.Helpers
{
    public static class SplitHelper
    {
        public static string Split(string value, char separator, int position)
        {
            return value.Split(separator)[position];
        }
    }
}
