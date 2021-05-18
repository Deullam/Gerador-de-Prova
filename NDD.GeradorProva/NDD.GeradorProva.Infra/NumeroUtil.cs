namespace NDD.GeradorProva.Infra.Uit
{
    public static class NumeroUtil
    {

        public static bool EhDouble(string value)
        {
            double n;
            return double.TryParse(value, out n);
        }

        public static bool EhLong(string value)
        {
            long n;
            return long.TryParse(value, out n);
        }

        public static bool EhInt(string value)
        {
            int n;
            return int.TryParse(value, out n);
        }

    }
}
