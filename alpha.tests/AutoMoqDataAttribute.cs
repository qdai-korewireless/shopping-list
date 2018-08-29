using AutoFixture.Xunit2;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace alpha.tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }


}
