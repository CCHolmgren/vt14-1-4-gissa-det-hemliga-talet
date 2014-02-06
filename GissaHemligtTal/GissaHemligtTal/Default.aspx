<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaHemligtTal.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ol>
            <li>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </li>
            <li>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Skriv in något i fältet." EnableViewState="True" Visible="True" ControlToValidate="Guess" Display="None" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Skriv in ett värde mellan 1 och 100." Type="Integer" MaximumValue="100" MinimumValue="1" Display="None" ControlToValidate="Guess" ValidateRequestMode="Enabled"></asp:RangeValidator>
            </li>
            <li>
                <asp:Label Text="Ange ett tal mellan 1 och 100." runat="server" />
                <asp:TextBox runat="server" ID="Guess" CausesValidation="True"/>
                <asp:Button Text="Skicka gissning" runat="server" OnClick="Unnamed2_Click" ID="GuessButton" />
            </li>
            <li>
                <asp:Label Text="Number" runat="server" ID="Number" />
            </li>
            <li>
                <asp:Label Text="Resultat" runat="server" ID="Resultat"/>
            </li>
            <li>
                <asp:Button Text="Återställ" runat="server" ID="ResetButton" Visible="false" OnClick="ResetButton_Click"/>
            </li>
        </ol>
    </div>
    </form>
</body>
</html>
