namespace System {

    public static class NullableExtensions {

        public static bool IsDefault<T>(this T? nullable)
            where T : struct {

            return !nullable.HasValue || nullable.Value.Equals(default(T));

        }
    }
}