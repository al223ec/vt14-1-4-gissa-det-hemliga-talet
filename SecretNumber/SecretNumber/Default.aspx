<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecretNumber.Default" ViewStateMode="Disabled" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/style.css" rel="stylesheet" />
    <title>Anton Ledström, 1-4 - Gissa det hemliga talet</title>
</head>
<body>
    <form id="form1" runat="server" defaultfocus="GuessTextBox">
        <asp:Panel ID="MainPanel" runat="server" DefaultButton="GuessButton">
            <p class="heading">1-4 Gissa det hemliga talet</p>
            <h1>Gissa det hemliga talet</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
            <%-- Gissning --%>
            <div>
                <p class="label">Gissa på ett tal mellan 1 och 100</p>
                <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox>
                <%--Validering--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Detta fällt måste vara ifyllt" ControlToValidate="GuessTextBox" Text="*"
                    CssClass="error" Display="Dynamic">
                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste var mellan 1-100" MaximumValue="100" MinimumValue="1" Type="Integer"
                    ControlToValidate="GuessTextBox" Display="Dynamic" Text="*" CssClass="error"></asp:RangeValidator>
            </div>
            <%--Output--%>
            <asp:Panel ID="OutputPanel" runat="server" Visible="false">
                <p>
                    <asp:Literal ID="OutputLiteral" runat="server"></asp:Literal>
                </p>
            </asp:Panel>
            <asp:Button ID="GuessButton" runat="server" Text="Gissa!" OnClick="GuessButton_Click" />
            <%-- Footer --%>
            <p class="footer">
                Anton Ledström
            </p>
        </asp:Panel>
    </form>
</body>
</html>
