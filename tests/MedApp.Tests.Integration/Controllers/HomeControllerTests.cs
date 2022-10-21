using Microsoft.AspNetCore.Mvc.Controllers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedApp.Tests.Integration.Controllers
{
    public class HomeControllerTests : ControlerTests
    {


        [Fact]
        public async Task get_base_endpoint_should_return_200_ok_status_code_and_api_name()
        {
            var response = await Client.GetAsync("/");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.ShouldBe("MedApp API [test]");
        }
        public HomeControllerTests(OptionsProvider optionsProvider) : base(optionsProvider)
        {
        }
    }

}
