using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Steps
{
    [Binding]
    public class CustomerSteps : AppTest
    {
        public CustomerSteps(AppFixture fixture) : base(fixture)
        {
        }

        [Given(@"I am on the Create Customer page")]
        public void GivenIAmOnTheCreateCustomerPage()
        {
            // TODO: VC: Setup tests in all methods below
        }

        [Given(@"I have inputted the first name '(.*)'")]
        public void GivenIHaveInputtedTheFirstName(string p0)
        {

        }

        [Given(@"I have inputted the last name '(.*)'")]
        public void GivenIHaveInputtedTheLastName(string p0)
        {

        }

        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string p0)
        {

        }

        [Then(@"I am on the Customer List page")]
        public void ThenIAmOnTheCustomerListPage()
        {

        }

        [Then(@"I can see the newly created customer")]
        public void ThenICanSeeTheNewlyCreatedCustomer()
        {

        }

        [Then(@"I can see it has the same details as the ones I had inputted")]
        public void ThenICanSeeItHasTheSameDetailsAsTheOnesIHadInputted()
        {

        }

    }
}
