namespace AlinSpace.Optional.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Optional<int> d = default;

            Assert.False(d.HasValue);
            Assert.Equal(0, d.GetValueOrDefault());
        }
    }
}