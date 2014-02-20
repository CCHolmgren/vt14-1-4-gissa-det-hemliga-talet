<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GissaHemligtTal.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa hemligt tal</title>
    <script src="Main.js"></script>
    <link href="Main.css" rel="stylesheet" />
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
    <div>
        <ol>
            <!--Validation-->
            <li>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Skriv in något i fältet." EnableViewState="True" Visible="True" ControlToValidate="Guess" Display="None" ValidateRequestMode="Enabled"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Skriv in ett värde mellan 1 och 100." Type="Integer" MaximumValue="100" MinimumValue="1" Display="None" ControlToValidate="Guess" ValidateRequestMode="Enabled"></asp:RangeValidator>
            </li>
            <!--Input and GuessButton-->
            <li>
                <asp:Label Text="Ange ett tal mellan 1 och 100." runat="server" />
                <asp:TextBox runat="server" ID="Guess" CausesValidation="True"/>
                <asp:Button Text="Skicka gissning" runat="server" OnClick="Unnamed2_Click" ID="GuessButton" />
            </li>
            <!--Result from each guess and each guessed number-->
            <li>
                <asp:Label Text="" runat="server" ID="Resultat"/>
            </li>
            <asp:PlaceHolder ID="PlaceHolder1" Visible="false" runat="server">
                <!--Number, the correct number when guessing has ended-->
                <li>
                    <asp:Label Text="Number" runat="server" ID="Number" />
                </li>
                <!--Resetbutton-->
                <li>
                    <asp:Button Text="Slumpa nytt hemligt tal" runat="server" ID="ResetButton" OnClick="ResetButton_Click"/>
                </li>
            </asp:PlaceHolder>
        </ol>
    </div>
    </form>
</body>
</html>
