using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementEntities
{
    public class Customer
    {
        #region Class member fields
        private string customerFirstName = null;
        private string customerLastName = null;
        private string customerAddress = null;
        private string customerZipCode = null;
        private string customerCity = null;
        private string customerState = null;
        private Guid? customerCountryID = null;
        private string customerPhone = null;
        private string customerEmailAddress = null;
        private string customerWebAddress = null;
        private int customerCreditLimit = 0;
        private bool customerNewsSubscriber = false;
        private DateTime? customerCreatedDate = null;
        private string customerCreatedBy = null;
        private DateTime? customerModifiedDate = null;
        private string customerModifiedBy = null;
        #endregion

        #region Properties
        /// <summary>
        /// The unique customer ID
        /// </summary>
        public Guid? ID
        {
            get;
            set;
        }

        /// <summary>
        /// The customer first name
        /// </summary>
        public string FirstName
        {
            get
            {
                return this.customerFirstName;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerFirstName = "";
                else
                    // Only get the first 50 characters
                    if (value.Length > 50)
                    this.customerFirstName = value.Substring(0, 50);
                else
                    this.customerFirstName = value;
            }
        }

        /// <summary>
        /// The customer last name
        /// </summary>
        public string LastName
        {
            get
            {
                return this.customerLastName;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerLastName = "";
                else
                    // Only get the first 30 characters
                    if (value.Length > 30)
                    this.customerLastName = value.Substring(0, 30);
                else
                    this.customerLastName = value;
            }
        }

        /// <summary>
        /// The customer address, including street name, house number and floor
        /// </summary>
        public string Address
        {
            get
            {
                return this.customerAddress;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerAddress = "";
                else
                    // Only get the first 50 characters
                    if (value.Length > 50)
                    this.customerAddress = value.Substring(0, 50);
                else
                    this.customerAddress = value;
            }
        }

        /// <summary>
        /// The customer zip code or postal code
        /// </summary>
        public string ZipCode
        {
            get
            {
                return this.customerZipCode;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerZipCode = "";
                else
                    // Only get the first 10 characters
                    if (value.Length > 10)
                    this.customerZipCode = value.Substring(0, 10);
                else
                    this.customerZipCode = value;
            }
        }

        /// <summary>
        /// The name of the city in which the customer lives
        /// </summary>
        public string City
        {
            get
            {
                return this.customerCity;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerCity = "";
                else
                    // Only get the first 30 characters
                    if (value.Length > 30)
                    this.customerCity = value.Substring(0, 30);
                else
                    this.customerCity = value;
            }
        }

        /// <summary>
        /// The name of the state or region in which the customer lives
        /// </summary>
        public string State
        {
            get
            {
                return this.customerState;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerState = "";
                else
                    // Only get the first 30 characters
                    if (value.Length > 30)
                    this.customerState = value.Substring(0, 30);
                else
                    this.customerState = value;
            }
        }

        /// <summary>
        /// The ID of the country in which the customer lives
        /// </summary>
        public Guid? CountryID
        {
            get
            {
                return this.customerCountryID;
            }
            set
            {
                this.customerCountryID = value;
            }
        }

        /// <summary>
        /// The customer phone number
        /// </summary>
        public string Phone
        {
            get
            {
                return this.customerPhone;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerPhone = "";
                else
                    // Only get the first 30 characters
                    if (value.Length > 30)
                    this.customerPhone = value.Substring(0, 30);
                else
                    this.customerPhone = value;
            }
        }

        /// <summary>
        /// The customer e-mail address
        /// </summary>
        public string EmailAddress
        {
            get
            {
                return this.customerEmailAddress;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerEmailAddress = "";
                else
                    // Only get the first 50 characters
                    if (value.Length > 50)
                    this.customerEmailAddress = value.Substring(0, 50);
                else
                    this.customerEmailAddress = value;
            }
        }

        /// <summary>
        /// The customer Web address
        /// </summary>
        public string WebAddress
        {
            get
            {
                return this.customerWebAddress;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerWebAddress = "";
                else
                    // Only get the first 80 characters
                    if (value.Length > 80)
                    this.customerWebAddress = value.Substring(0, 80);
                else
                    this.customerWebAddress = value;
            }
        }

        /// <summary>
        /// The current credit limit of the customer
        /// </summary>
        public int CreditLimit
        {
            get
            {
                return this.customerCreditLimit;
            }
            set
            {
                // Negative value?
                if (value < 0)
                    this.customerCreditLimit = 0;
                else
                    this.customerCreditLimit = value;
            }
        }

        /// <summary>
        /// Does the customer subscriber to news?
        /// </summary>
        public bool NewsSubscriber
        {
            get
            {
                return this.customerNewsSubscriber;
            }
            set
            {
                this.customerNewsSubscriber = value;
            }
        }

        /// <summary>
        /// The date the customer was created in the system
        /// </summary>
        public DateTime? CreatedDate
        {
            get
            {
                return this.customerCreatedDate;
            }
            private set
            {
                // Date in the past?
                if (value < DateTime.Now)
                    this.customerCreatedDate = DateTime.Now;
                else
                    this.customerCreatedDate = value;
            }
        }

        /// <summary>
        /// The name of the user creating the customer
        /// </summary>
        public string CreatedBy
        {
            get
            {
                return this.customerCreatedBy;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerCreatedBy = "";
                else
                    // Only get the first 15 characters
                    if (value.Length > 15)
                    this.customerCreatedBy = value.Substring(0, 15);
                else
                    this.customerCreatedBy = value;
            }
        }

        /// <summary>
        /// The date the customer was last modified in the system
        /// </summary>
        public DateTime? ModifiedDate
        {
            get
            {
                return this.customerModifiedDate;
            }
            set
            {
                // Date in the past?
                if (value < DateTime.Now)
                    this.customerModifiedDate = DateTime.Now;
                else
                    this.customerModifiedDate = value;
            }
        }

        /// <summary>
        /// The name of the user who last modified the customer
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.customerModifiedBy;
            }
            set
            {
                // Null value?
                if (value == null)
                    this.customerModifiedBy = "";
                else
                    // Only get the first 15 characters
                    if (value.Length > 15)
                    this.customerModifiedBy = value.Substring(0, 15);
                else
                    this.customerModifiedBy = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default parameterless constructor
        /// </summary>
        public Customer()
        {
            // Initialize backing fields with default values
            this.ID = Guid.NewGuid();
            this.CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes backing fields with passed and default values
        /// </summary>
        /// <param name="id"></param>
        public Customer(Guid? id)
        {
            // Initialize backing fields with passed and default values
            this.ID = id;
            this.CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Initializes with a value for all backing fields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="zipCode"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="countryID"></param>
        /// <param name="phone"></param>
        /// <param name="emailAddress"></param>
        /// <param name="webAddress"></param>
        /// <param name="creditLimit"></param>
        /// <param name="newsSubscriber"></param>
        /// <param name="createdDate"></param>
        /// <param name="createdBy"></param>
        /// <param name="modifiedDate"></param>
        /// <param name="modifiedBy"></param>
        public Customer(Guid? id, string firstName, string lastName, string address,
            string zipCode, string city, string state, Guid? countryID, string phone,
            string emailAddress, string webAddress, int creditLimit, bool newsSubscriber,
            DateTime? createdDate, string createdBy, DateTime? modifiedDate, string modifiedBy)
        {
            // Initialize member backing fields with passed values
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.ZipCode = zipCode;
            this.City = city;
            this.State = state;
            this.CountryID = countryID;
            this.Phone = phone;
            this.EmailAddress = emailAddress;
            this.WebAddress = webAddress;
            this.CreditLimit = creditLimit;
            this.NewsSubscriber = newsSubscriber;

            if (createdDate != null)
                this.CreatedDate = createdDate;
            else
                this.CreatedDate = DateTime.Now;

            this.CreatedBy = createdBy;
            this.ModifiedDate = modifiedDate;
            this.ModifiedBy = modifiedBy;
        }
        #endregion
    }
}
