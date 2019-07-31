using Optivem.Template.Web.UI.Client.Interface.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Steps
{
    [Binding]
    public class CustomerSteps : AppTest
    {
        private ICreateCustomerPage _createCustomerPage;

        public CustomerSteps(AppFixture fixture) : base(fixture)
        {
        }

        [Given(@"I am on the Create Customer page")]
        public void GivenIAmOnTheCreateCustomerPage()
        {
            // TODO: VC: Setup tests in all methods below
            _createCustomerPage = Fixture.App.NavigateToCreateCustomerPage();
        }

        [Given(@"I have inputted the first name '(.*)'")]
        public void GivenIHaveInputtedTheFirstName(string firstName)
        {
            _createCustomerPage.InputFirstName(firstName);
        }

        [Given(@"I have inputted the last name '(.*)'")]
        public void GivenIHaveInputtedTheLastName(string lastName)
        {
            _createCustomerPage.InputLastName(lastName);
        }

        [When(@"I click on the Create button")]
        public void WhenIClickOnTheCreateButton()
        {
            _createCustomerPage.ClickCreate();
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
