using SelfieAWookie.Controllers;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            var controller = new SelfieController();

            var result = controller.GetSelfies();

            Assert.NotNull(result);
            Assert.True(result.GetEnumerator().MoveNext());
            
        }
        
    }
}