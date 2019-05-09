using Microsoft.Extensions.Configuration;
using Xunit;

namespace Blog.MVC.Test
{
    internal class FakeStartup
    {
        public IConfiguration Configuration { get; }
        public FakeStartup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<FakeStartup>();
            Configuration = builder.Build();
        }
    }

    public class ConfigurationTests
    {
        // Note: this test suite requires UserSecrets to be set up.
        //       Follow the 'Setting Up UserSecrets' instructions in Reblogged/README.md
        [Fact]
        public void InitFakeStartup_DefaultConstructorCall_ReturnsInstance()
        {
            var fakestartup = new FakeStartup();
            Assert.NotNull(fakestartup);
        }

        [Fact]
        public void UseConfig_ValidConfigKey_ReturnsExpectedConfigValue()
        {
            var fakestartup = new FakeStartup();
            var configuration = fakestartup.Configuration;
            var expected = "TestValue"; // a real config value in secrets.json
            var param_key = "TestKey"; // a real config key in secrets.json

            var actual = configuration[param_key];

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UseConfig_InvalidConfigKey_ReturnsNull()
        {
            var fakestartup = new FakeStartup();
            var configuration = fakestartup.Configuration;
            var param_key = "InvalidKeyNotInUserSecrets";

            var returned = configuration[param_key];

            Assert.Null(returned);
        }
    }
}
