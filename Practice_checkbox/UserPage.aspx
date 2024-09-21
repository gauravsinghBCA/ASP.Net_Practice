<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Practice_checkbox.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Candidate Name:</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server" placeholder="enter your name"></asp:TextBox></td>
                </tr>

                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="3"></asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>

                <tr>
                    <td>Hobbies:</td>
                    <td>
                        <asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="6">
                            <asp:ListItem Text="cricket" Value="1"></asp:ListItem>
                            <asp:ListItem Text="music" Value="2"></asp:ListItem>
                            <asp:ListItem Text="cooking" Value="3"></asp:ListItem>
                            <asp:ListItem Text="swiming" Value="4"></asp:ListItem>
                            <asp:ListItem Text="reading" Value="5"></asp:ListItem>
                            <asp:ListItem Text="codding" Value="6"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" />
                    </td>

                </tr>

            </table>
            <asp:GridView ID="gridv" runat="server" OnRowCommand="gridv_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <%#Eval("id") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <%#Eval("gender").ToString() == "1" ? "male": Eval("gender").ToString() =="2" ? "female" :"others" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Hobbies">
                        <ItemTemplate>
                            <%#Eval("hobbies") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btndelete" runat="server" Text="delete" CommandName="delet_data" CommandArgument=' <%#Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" Text="edit" CommandName="edit_data" CommandArgument=' <%#Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
