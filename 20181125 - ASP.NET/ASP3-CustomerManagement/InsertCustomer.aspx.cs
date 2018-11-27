using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertCustomer : System.Web.UI.Page
{
    private CustomerManagementEntities.Customer currentCustomer = null;

    /// <summary>
    /// Instantiates Customer object
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Instantiate Customer
        instantiateCustomerObject();
    }

    /// <summary>
    /// Instantiates and populates the Customer member object
    /// </summary>
    private void instantiateCustomerObject()
    {
        // First time loading page?
        if (!this.IsPostBack)
            // Instantiate new Customer object
            currentCustomer = new CustomerManagementEntities.Customer(
            null, CustomerFirstNameTextBox.Text, CustomerLastNameTextBox.Text,
            CustomerAddressTextBox.Text, CustomerZipCodeTextBox.Text,
            CustomerCityTextBox.Text, CustomerStateTextBox.Text,
            null, CustomerPhoneTextBox.Text, CustomerEmailAddressTextBox.Text,
            CustomerWebAddressTextBox.Text, -1, CustomerNewsSubscriberCheckBox.Checked,
            DateTime.Now, "", null, "");
    }

    /// <summary>
    /// Populates UI controls
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        // Populate the UI controls
        populateUI();
    }

    /// <summary>
    /// Populates the UI controls with the values in the
    /// current Customer object
    /// </summary>
    private void populateUI()
    {
        CustomerFirstNameTextBox.Text = currentCustomer.FirstName;
        CustomerLastNameTextBox.Text = currentCustomer.LastName;
        CustomerAddressTextBox.Text = currentCustomer.Address;
        CustomerZipCodeTextBox.Text = currentCustomer.ZipCode;
        CustomerCityTextBox.Text = currentCustomer.City;
        CustomerStateTextBox.Text = currentCustomer.State;
        if (currentCustomer.CountryID.HasValue)
            CustomerCountryDropDownList.SelectedValue =
            currentCustomer.CountryID.Value.ToString();
        else
            CustomerCountryDropDownList.SelectedIndex = -1;
        CustomerPhoneTextBox.Text = currentCustomer.Phone;
        CustomerEmailAddressTextBox.Text = currentCustomer.EmailAddress;
        CustomerWebAddressTextBox.Text = currentCustomer.WebAddress;
        CustomerCreditLimitTextBox.Text = currentCustomer.CreditLimit.ToString();
        CustomerNewsSubscriberCheckBox.Checked = currentCustomer.NewsSubscriber;
    }

    /// <summary>
    /// Destroys objects
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Unload(object sender, EventArgs e)
    {
        // Destroy Customer object
        currentCustomer = null;
    }

    /// <summary>
    /// Redirects to home page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerCancelButton_Click(object sender, EventArgs e)
    {
        // Redirect to home page
        Response.Redirect("~/Default.aspx");
    }

    /// <summary>
    /// Saves the current customer information and adds default values
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerInsertButton_Click(object sender, EventArgs e)
    {
        // Add the current user name
        currentCustomer.CreatedBy = Context.User.Identity.Name;
        // Add the user credit limit
        currentCustomer.CreditLimit = 50000;
    }
}