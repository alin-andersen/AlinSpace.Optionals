using System.Runtime.InteropServices;

namespace AlinSpace.Optional
{
    /// <summary>
    /// Represents the optional.
    /// </summary>
    /// <typeparam name="T">Type of the value.</typeparam>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Optional<T>
    {
        /// <summary>
        /// Gets the flag indicting whether or not the optional has a value.
        /// </summary>
        public bool HasValue { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value => HasValue ? value : throw new OperationCanceledException();
        private readonly T value;

        /// <summary>
        /// Get value or default.
        /// </summary>
        public T ValueOrDefault => HasValue ? value : default;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Optional(T value = default)
        {
            HasValue = !value.Equals(default);
            this.value = value;
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        public T GetValueOrDefault()
        {
            return Value ?? default;
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <param name="defaultValue">Default value.</param>
        public T GetValueOrDefault(T defaultValue)
        {
            return HasValue ? Value : defaultValue;
        }

        #region Operators

        public static explicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }

        public static explicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }

        public static implicit operator bool(Optional<T> optional)
        {
            return optional.HasValue;
        }

        public static bool operator true(Optional<T> optional)
        {
            return optional.HasValue;
        }

        public static bool operator false(Optional<T> optional)
        {
            return !optional.HasValue;
        }

        #endregion
    }

    ///// <summary>
    ///// Represents the optional.
    ///// </summary>
    ///// <typeparam name="T">Type of the value.</typeparam>
    //[Serializable]
    //[StructLayout(LayoutKind.Sequential)]
    //public struct Optional<T, TError>
    //{
    //    /// <summary>
    //    /// Gets the flag indicting whether or not the optional has a value.
    //    /// </summary>
    //    public bool HasValue { get; private set; }

    //    /// <summary>
    //    /// Gets the value.
    //    /// </summary>
    //    public T Value => HasValue ? _value : throw new OptionalHasNoValueException();
    //    private readonly T _value;

    //    /// <summary>
    //    /// Gets the error.
    //    /// </summary>
    //    public T Error { get; private set; }

    //    /// <summary>
    //    /// Constructor.
    //    /// </summary>
    //    public Optional(T value = default)
    //    {
    //        HasValue = true;
    //        _value = value;
    //    }

    //    public static Optional<T, TError> Error(TError error = default)
    //    {

    //    }

    //    /// <summary>
    //    /// Gets the value or default.
    //    /// </summary>
    //    public T GetValueOrDefault()
    //    {
    //        return Value ?? default;
    //    }

    //    /// <summary>
    //    /// Gets the value or default.
    //    /// </summary>
    //    /// <param name="defaultValue">Default value.</param>
    //    public T GetValueOrDefault(T defaultValue)
    //    {
    //        return HasValue ? Value : defaultValue;
    //    }

    //    #region Operators

    //    public static explicit operator T(Optional<T> optional)
    //    {
    //        return optional.Value;
    //    }

    //    public static explicit operator Optional<T>(T value)
    //    {
    //        return new Optional<T>(value);
    //    }

    //    public static implicit operator bool(Optional<T> optional)
    //    {
    //        return optional.HasValue;
    //    }

    //    public static bool operator true(Optional<T> optional)
    //    {
    //        return optional.HasValue;
    //    }

    //    public static bool operator false(Optional<T> optional)
    //    {
    //        return !optional.HasValue;
    //    }

    //    #endregion
    //}
}