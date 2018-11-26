<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertCustomer.aspx.cs" Inherits="InsertCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        </style>

</head>
<body class="template">
    <form id="form1" runat="server">
        <div class="customerTable">
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerFirstNameLabel" runat="server" Text="First Name:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerFirstNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerLastNameLabel" runat="server" Text="Last Name:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="30"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerAddressLabel" runat="server" Text="Address:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerAddressTextBox" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerZipCodeLabel" runat="server" Text="Zip Code:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerZipCodeTextBox" runat="server" MaxLength="10"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerCityLabel" runat="server" Text="City:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerCityTextBox" runat="server" MaxLength="30"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerStateLabel" runat="server" Text="State:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerStateTextBox" runat="server" MaxLength="30"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerCountryLabel" runat="server" Text="Country:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:DropDownList ID="CustomerCountryDropDownLis" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerPhoneLabel" runat="server" Text="Phone:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerPhoneTextBox" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerEmailAddressLabel" runat="server" Text="Email Address:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerEmailAddressTextBox" runat="server" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerWebAddressLabel" runat="server" Text="Web Address:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerWebAddressTextBox" runat="server" MaxLength="80"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerCreditLimitLabel" runat="server" Text="Credit Limit:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:TextBox ID="CustomerCreditLimitTextBox" runat="server" MaxLength="10"></asp:TextBox>
                </div>
            </div>
            <div class="customerTableRow">
                <div class="customerTableLeftCol">
                    <asp:Label ID="CustomerNewsSubscriberLabel" runat="server" Text="News Subscriber:"></asp:Label>
                </div>
                <div class="customerTableRightCol">
                    <asp:CheckBox ID="CustomerNewsSubscriberCheckBox" runat="server"></asp:CheckBox>
                </div>
            </div>
            <div class="customerTableFooter">
                <asp:Button ID="CustomerInsertButton" runat="server" Text="Insert" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="CustomerCancelButton" runat="server" Text="Cancel" />
            </div>
        </div>
    </form>
</body>
</html>
