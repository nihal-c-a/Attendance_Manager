using practice.Testing;
using Xunit;
namespace Practice.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            Calulator c1 = new Calulator();


            //act

            c1.Add(5, 6);

            //Assert
            Assert.Equal(11, c1.Add(5,6));

        }
    }
}