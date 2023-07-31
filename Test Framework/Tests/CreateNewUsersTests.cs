using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using Test_Framework.Models;
using Test_Framework.Pages;

namespace Test_Framework.Tests
{
    internal class CreateNewUsersTests : BaseTest
    {
        private HomePage _homePage;
        CustomerModel _customerToAdd = new CustomerModel
        {
            FirstName = "CreateNewUser AQA",
            LastName = "Last AQA",
            PostCode = "123456",
        };
        private CustomerModel? _createdUser = default;
        [TearDown]
        protected override void TearDown()
        {
            if (_createdUser != default)
            {

                var deleteCustomer = new CustomersPage(driver)
                    .OpenPageURL();

                deleteCustomer
                    .DeleteUser(_customerToAdd.FirstName);
                _createdUser = default;
            }

            base.TearDown();
        }

        [Test]
        public void CreateNewCustomerWithAccount()
        {
            var createNewCustomer = new AddCustomersPage(driver)
                .OpenPageURL();

            createNewCustomer
                .AddCustomer(_customerToAdd).GetAccNumberPopUpWindow();

            _createdUser = _customerToAdd;

            var openAccount = new OpenAccPage(driver).OpenPageURL();
            openAccount.OpenAccount();

            openAccount
                .GetStartTextPopUpWindow()
                .Should()
                .BeEquivalentTo("Account created", "New user created");

        }
        [Test]
        public void CreateNewCustomerWithOutAccount()
        {
            CustomerModel customerToAddOld = new CustomerModel
            {
                FirstName = "CreateOldUser AQA",
                LastName = "Last AQA",
                PostCode = "123456",
            };
            var createNewCustomer = new AddCustomersPage(driver).OpenPageURL();

            createNewCustomer.AddCustomer(customerToAddOld);

            _createdUser = _customerToAdd;

            createNewCustomer
              .GetStartTextPopUpWindow()
               .Should()
               .BeEquivalentTo("Customer added ", "New user created");
        }

        [Test]
        public void SearchInCustomerField()
        {
            //Arrange
            var addCustomer = new AddCustomersPage(driver).OpenPageURL();
            addCustomer
                .AddCustomer(_customerToAdd)
                .GetStartTextPopUpWindow();

            _createdUser = _customerToAdd;

            var openAccount = new OpenAccPage(driver).OpenPageURL();
            var userid = openAccount.OpenAccount().GetAccNumberPopUpWindow();

            List<string> listSearchWord = new List<string>();

            listSearchWord.Add("CreateNewUser AQA");
            listSearchWord.Add("Last AQA");
            listSearchWord.Add("123456");
            listSearchWord.Add(userid);

            //Act
            var douWhithCustomer = new CustomersPage(driver).OpenPageURL();

            using (new AssertionScope())
            {
                for (int i = 0; i < 4; i++)
                {
                    var kek = douWhithCustomer.SetTextInFIeld(listSearchWord[i]).UserIsDisplayd(userid);
                    kek.Should().BeTrue($"{listSearchWord[i]} sholube be classno");
                }
            }
        }
        [Test]
        public void CheckDeleteButton()
        {
            var createNewCustomer = new AddCustomersPage(driver).OpenPageURL();
            createNewCustomer
                .AddCustomer(_customerToAdd)
                .GetStartTextPopUpWindow();
            _createdUser = _customerToAdd;

            var openAccount = new OpenAccPage(driver).OpenPageURL();
            var userToDeleteId = openAccount
                .OpenAccount()
                .GetAccNumberPopUpWindow();

            var customers = new CustomersPage(driver).OpenPageURL();
            customers.DeleteUser("CreateNewUser AQA");

            customers
                .UserIsNotDisplayd(userToDeleteId)
                .Should()
                .BeTrue("User is deleted");
            _createdUser = default;
        }
    }
}
