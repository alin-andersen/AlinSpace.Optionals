using System.Runtime.InteropServices;

namespace AlinSpace.Optionals
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
        /// Gets the flag indicating whether or not the optional has no value.
        /// </summary>
        public bool HasNoValue { get; set; }

        /// <summary>
        /// Gets the flag indicating whether or not the optional has some value.
        /// </summary>
        public bool HasValue
        {
            get => !HasNoValue;
            set => HasNoValue = !value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value
        {
            get => HasValue ? value : throw new OptionalHasNoValueException();
            set => this.Value = value;
        }

        private readonly T value;

        /// <summary>
        /// Get value or default.
        /// </summary>
        public T ValueOrDefault => HasValue ? value : default;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Optional()
        {
            HasNoValue = false;
            this.value = default;
        }

        private Optional(bool hasValue, T value = default)
        {
            HasNoValue = !hasValue;
            this.value = value;
        }

        /// <summary>
        /// Creates optional with some value.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>Optional with some value.</returns>
        public static Optional<T> Some(T value)
        {
            return new Optional<T>(true, value);
        }

        /// <summary>
        /// Creates optional with no value.
        /// </summary>
        /// <returns>Optional with no value.</returns>
        public static Optional<T> None()
        {
            return new Optional<T>(false);
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        public T GetValueOrDefault()
        {
            return HasNoValue ? default : Value;
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <param name="defaultValue">Default value.</param>
        public T GetValueOrDefault(T defaultValue)
        {
            return HasNoValue ? defaultValue : Value;
        }

        #region Equals

        public override bool Equals(object other)
        {
            if (!(other is Optional<T> otherOptional))
                return false;

            if (HasNoValue == otherOptional.HasNoValue)
                return false;

            // Call equals on the value.
            return value.Equals(otherOptional.Value);
        }

        public bool Equals(Optional<T> other)
        {
            if (HasValue != other.HasValue)
                return false;

            // If Value is default we can't call Equals method.
            if (EqualityComparer<T>.Default.Equals(Value, default))
            {
                return EqualityComparer<T>.Default.Equals(other.Value, default);
            }

            // Call equals on the value.
            return value.Equals(other.Value);
        }

        #endregion

        #region GetHashCode

        public override int GetHashCode()
        {
            return HashCode.Combine(HasNoValue, value);
        }

        #endregion

        #region Operators

        public static explicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }

        public static implicit operator Optional<T>(T value)
        {
            return new Optional<T>(true, value);
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
            return optional.HasNoValue;
        }

        public static bool operator ==(Optional<T> optional1, Optional<T> optional2)
        {
            if (optional1.HasNoValue != optional2.HasNoValue)
                return false;

            return EqualityComparer<T>.Default.Equals(optional1.Value, optional2.Value);
        }

        public static bool operator !=(Optional<T> optional1, Optional<T> optional2)
        {
            if (optional1.HasNoValue != optional2.HasNoValue)
                return false;

            return !EqualityComparer<T>.Default.Equals(optional1.Value, optional2.Value);
        }

        #endregion
    }
}