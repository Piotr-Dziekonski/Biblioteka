<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="BazaUczniow.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 131px;
        }
        .style4
        {
            width: 130px;
        }
        .style6
        {
            width: 71px;
        }
        .auto-style2 {
            width: 214px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
    
        <asp:LinkButton ID="LinkButtonListaUczniow" runat="server" 
            onclick="LinkButtonListaUczniow_Click">Lista uczniów</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButtonUczenEdycja" runat="server" 
            onclick="LinkButtonUczen_Click">Edycja</asp:LinkButton>
    
    &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButtonWynikiWyszukiwania" runat="server" 
            Visible="False">Wyniki wyszukiwania</asp:LinkButton>
    
    </p>
    
    
        <asp:MultiView ID="MultiViewUczniowie" runat="server">
            <asp:View ID="ViewWynikiWyszukiwania" runat="server">
                <asp:GridView ID="GridViewWynikiWyszukiwania" runat="server" 
                    onload="GridViewUczniowie_Load" 
                    ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonDelete0" runat="server" 
                                    ImageUrl="~/delete24.png" onclick="ImageButtonDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonEdit" runat="server" 
                                    ImageUrl="~/leftRight.png" onclick="ImageButtonEdit_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <HeaderStyle BackColor="#3B894C" Font-Bold="True" ForeColor="#E7E7FF" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="ViewListaUczniow" runat="server">
            <p>
        <asp:GridView ID="GridViewUczniowie" runat="server" onload="GridViewUczniowie_Load" 
            onselectedindexchanged="GridViewUczniowie_Load" 
            ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:TemplateField Visible="False" ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonDelete" runat="server" 
                            ImageUrl="~/delete24.png" onclick="ImageButtonDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ImageUrl="~/leftRight.png" 
                            onclick="ImageButtonEdit_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#3B894C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </p>
    
    
        <asp:ImageButton ID="ImageButtonKlodka" runat="server" 
            ImageUrl="~/locked24.jpeg" onclick="ImageButtonKlodka_Click" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="odblokowane" 
            Visible="False" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:ValidationSummary ID="ValidationSummary5" runat="server" 
            CssClass="failureNotification" ValidationGroup="GrupaWalidacji" />
        <table>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="auto-style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                </td>
                <td class="style1" align="center" valign="middle">

                        <asp:Label ID="LabelWyszukaj" runat="server" Text="Wyszukaj" Visible="False"></asp:Label>

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelImie" runat="server" Text="Imię" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxImie" runat="server"  style="margin-left: 0px" 
                        ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    <asp:RadioButton ID="RadioButtonImie" runat="server" 
                        GroupName="GrupaRadioButton" Text="Imię" Visible="False" />
                </td>
                <td>
                    <asp:TextBox ID="TextBoxWyszukaj" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelNazwisko" runat="server" Text="Nazwisko" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxNazwisko" runat="server" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonNazwisko" runat="server" 
                        GroupName="GrupaRadioButton" Text="Nazwisko" Visible="False" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelKlasa" runat="server" Text="Klasa" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListKlasa" runat="server" ValidationGroup="GrupaWalidacji" Visible="False" Width="214px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonKlasa" runat="server" 
                        GroupName="GrupaRadioButton" Text="Klasa" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelTelefon" runat="server" Text="Telefon" Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxTelefon" runat="server" style="margin-left: 0px" ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonTelefon" runat="server" 
                        GroupName="GrupaRadioTelefon" Text="Telefon" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonDodaj" runat="server" OnClick="ButtonDodaj_Click" style="margin-left: 0px" Text="Dodaj" ValidationGroup="GrupaWalidacji" Visible="False" />
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="ButtonWyszukaj" runat="server" onclick="ButtonWyszukaj_Click" 
                        Text="Szukaj" Visible="False" Width="128px" />
                </td>
            </tr>
        </table>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBoxImie" Display="None" 
                ErrorMessage="Pole 'Imię' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TextBoxNazwisko" Display="None" 
                ErrorMessage="Pole 'Nazwisko' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="TextBoxTelefon" Display="None" 
                ErrorMessage="Pole 'Telefon' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
        </p>
    
                
            </asp:View>
            <asp:View ID="ViewImpreza" runat="server">
            <p>
                Edytujesz:
                <asp:Label ID="LabelEdytujesz" runat="server"></asp:Label>
            </p>
                <asp:ValidationSummary ID="ValidationSummary6" runat="server" CssClass="failureNotification" ValidationGroup="GrupaEdit" />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelImieEdit" runat="server" Text="Imię"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxImieEdit" runat="server" style="margin-left: 0px" ValidationGroup="GrupaEdit" Width="214px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelNazwiskoEdit" runat="server" Text="Nazwisko"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxNazwiskoEdit" runat="server" ValidationGroup="GrupaEdit" Width="216px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelKlasaEdit" runat="server" Text="Klasa"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListKlasaEdit" runat="server" ValidationGroup="GrupaEdit" Width="216px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelTelefonEdit" runat="server" Text="Telefon"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxTelefonEdit" runat="server" style="margin-left: 0px" ValidationGroup="GrupaEdit" Width="214px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonEdit" runat="server" onclick="ButtonEdit_Click" style="margin-left: 0px" Text="Zatwierdź" ValidationGroup="GrupaEdit" />
                        </td>
                    </tr>
                </table>
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxImie" Display="None" ErrorMessage="Pole 'Imię' nie może być puste" ValidationGroup="GrupaEdit"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxNazwisko" Display="None" ErrorMessage="Pole 'Nazwisko' nie może być puste" ValidationGroup="GrupaEdit"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxTelefon" Display="None" ErrorMessage="Pole 'Telefon' nie może być puste" ValidationGroup="GrupaEdit"></asp:RequiredFieldValidator>
                </p>


            </asp:View>
        </asp:MultiView>
    
    
    
</asp:Content>
