namespace AlinSpace.Optionals.UnitTests
{
    public class Optional
    {
        #region Integer

        [Fact]
        public void Integer_Set_Value_And_Check_If_Value_Is_Set_1()
        {
            Optional<int> d = Optional<int>.Some(5);

            Assert.True(d.HasValue);
            Assert.Equal(5, d.Value);
            Assert.Equal(5, d.GetValueOrDefault());
        }

        [Fact]
        public void Integer_Set_Value_And_Check_If_Value_Is_Set_2()
        {
            Optional<int> d = 5;

            Assert.True(d.HasValue);
            Assert.Equal(5, d.Value);
            Assert.Equal(5, d.GetValueOrDefault());
        }

        [Fact]
        public void Integer_Set_No_Value_And_Check_If_No_Value_Is_Set_1()
        {
            Optional<int> optional = Optional<int>.None();

            Assert.False(optional.HasValue);

            Assert.Throws<OptionalHasNoValueException>(() =>
            {
                _ = optional.Value;
            });

            Assert.Equal(0, optional.GetValueOrDefault());
        }

        [Fact]
        public void Integer_Set_Default_And_Check_If_Default_Is_Set_1()
        {
            Optional<int> optional = Optional<int>.Some(default);

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(default, optional.GetValueOrDefault());
        }

        [Fact]
        public void Integer_Set_Default_And_Check_If_Default_Is_Set_2()
        {
            Optional<int> optional = default;

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(0, optional.GetValueOrDefault());
        }

        #region ==

        [Fact]
        public void Integer_Check_If_Equal_Works_1()
        {
            Optional<int> optional1 = default;
            Optional<int> optional2 = default;

            Assert.True(optional1 == optional2);
        }

        [Fact]
        public void Integer_Check_If_Equal_Works_2()
        {
            Optional<int> optional1 = 1;
            Optional<int> optional2 = 2;

            Assert.False(optional1 == optional2);
        }

        #endregion

        #region !=

        [Fact]
        public void Integer_Check_If_Not_Equal_Works_1()
        {
            Optional<int> optional1 = default;
            Optional<int> optional2 = default;

            Assert.False(optional1 != optional2);
        }

        [Fact]
        public void Integer_Check_If_Not_Equal_Works_2()
        {
            Optional<int> optional1 = 1;
            Optional<int> optional2 = 2;

            Assert.True(optional1 != optional2);
        }

        #endregion

        #region Equals

        [Fact]
        public void Integer_Check_If_Equals_Works_3()
        {
            Optional<int> optional1 = default;
            Optional<int> optional2 = default;

            Assert.True(optional1.Equals(optional2));
        }

        [Fact]
        public void Integer_Check_If_Equals_Works_4()
        {
            Optional<int> optional1 = 1;
            Optional<int> optional2 = 2;

            Assert.False(optional1.Equals(optional2));
        }

        #endregion

        #endregion

        #region String

        [Fact]
        public void String_Set_Value_And_Check_If_Value_Is_Set_1()
        {
            Optional<string> optional = Optional<string>.Some("");

            Assert.True(optional.HasValue);
            Assert.Equal("", optional.Value);
            Assert.Equal("", optional.GetValueOrDefault());
        }

        [Fact]
        public void String_Set_Value_And_Check_If_Value_Is_Set_2()
        {
            Optional<string> optional = "Test";

            Assert.True(optional.HasValue);
            Assert.Equal("Test", optional.Value);
            Assert.Equal("Test", optional.GetValueOrDefault());
        }

        [Fact]
        public void String_Set_No_Value_And_Check_If_No_Value_Is_Set_1()
        {
            Optional<string> optional = Optional<string>.None();

            Assert.False(optional.HasValue);

            Assert.Throws<OptionalHasNoValueException>(() =>
            {
                _ = optional.Value;
            });

            Assert.Equal(default, optional.GetValueOrDefault());
        }

        [Fact]
        public void String_Set_Default_And_Check_If_Default_Is_Set_1()
        {
            Optional<string> optional = Optional<string>.Some(default);

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(default, optional.GetValueOrDefault());
        }

        [Fact]
        public void String_Set_Default_And_Check_If_Default_Is_Set_2()
        {
            Optional<string> optional = default;

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(default, optional.GetValueOrDefault());
        }

        #region ==

        [Fact]
        public void String_Check_If_Equal_Works_1()
        {
            Optional<string> optional1 = default;
            Optional<string> optional2 = default;

            Assert.True(optional1 == optional2);
        }

        [Fact]
        public void String_Check_If_Equal_Works_2()
        {
            Optional<string> optional1 = "1";
            Optional<string> optional2 = "2";

            Assert.False(optional1 == optional2);
        }

        #endregion

        #region !=

        [Fact]
        public void String_Check_If_Not_Equal_Works_1()
        {
            Optional<string> optional1 = default;
            Optional<string> optional2 = default;

            Assert.False(optional1 != optional2);
        }

        [Fact]
        public void String_Check_If_Not_Equal_Works_2()
        {
            Optional<string> optional1 = "1";
            Optional<string> optional2 = "2";

            Assert.True(optional1 != optional2);
        }

        #endregion

        #region Equals

        [Fact]
        public void String_Check_If_Equals_Works_3()
        {
            Optional<string> optional1 = default;
            Optional<string> optional2 = default;

            Assert.True(optional1.Equals(optional2));
        }

        [Fact]
        public void String_Check_If_Equals_Works_4()
        {
            Optional<string> optional1 = "1";
            Optional<string> optional2 = "2";

            Assert.False(optional1.Equals(optional2));
        }

        #endregion

        #endregion

        #region object

        [Fact]
        public void Object_Set_Value_And_Check_If_Value_Is_Set_1()
        {
            var @object = new object();
            Optional<object> optional = Optional<object>.Some(@object);

            Assert.True(optional.HasValue);
            Assert.Equal(@object, optional.Value);
            Assert.Equal(@object, optional.GetValueOrDefault());
        }

        [Fact]
        public void Object_Set_Value_And_Check_If_Value_Is_Set_2()
        {
            var @object = new object();
            Optional<object> optional = @object;

            Assert.True(optional.HasValue);
            Assert.Equal(@object, optional.Value);
            Assert.Equal(@object, optional.GetValueOrDefault());
        }

        [Fact]
        public void Object_Set_No_Value_And_Check_If_No_Value_Is_Set_1()
        {
            Optional<object> optional = Optional<object>.None();

            Assert.False(optional.HasValue);

            Assert.Throws<OptionalHasNoValueException>(() =>
            {
                _ = optional.Value;
            });

            Assert.Equal(default, optional.GetValueOrDefault());
        }

        [Fact]
        public void Object_Set_Default_And_Check_If_Default_Is_Set_1()
        {
            Optional<object> optional = Optional<object>.Some(default);

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(default, optional.GetValueOrDefault());
        }

        [Fact]
        public void Object_Set_Default_And_Check_If_Default_Is_Set_2()
        {
            Optional<object> optional = default;

            Assert.True(optional.HasValue);
            Assert.Equal(default, optional.Value);
            Assert.Equal(default, optional.GetValueOrDefault());
        }

        #region ==

        [Fact]
        public void Object_Check_If_Equal_Works_1()
        {
            Optional<object> optional1 = default;
            Optional<object> optional2 = default;

            Assert.True(optional1 == optional2);
        }

        [Fact]
        public void Object_Check_If_Equal_Works_2()
        {
            Optional<object> optional1 = new object();
            Optional<object> optional2 = new object();

            Assert.False(optional1 == optional2);
        }

        #endregion

        #region !=

        [Fact]
        public void Object_Check_If_Not_Equal_Works_1()
        {
            Optional<object> optional1 = default;
            Optional<object> optional2 = default;

            Assert.False(optional1 != optional2);
        }

        [Fact]
        public void Object_Check_If_Not_Equal_Works_2()
        {
            Optional<object> optional1 = new object();
            Optional<object> optional2 = new object();

            Assert.True(optional1 != optional2);
        }

        #endregion

        #region Equals

        [Fact]
        public void Object_Check_If_Equals_Works_3()
        {
            Optional<object> optional1 = default;
            Optional<object> optional2 = default;

            Assert.True(optional1.Equals(optional2));
        }

        [Fact]
        public void Object_Check_If_Equals_Works_4()
        {
            Optional<object> optional1 = new object();
            Optional<object> optional2 = new object();

            Assert.False(optional1.Equals(optional2));
        }

        #endregion

        #endregion
    }
}