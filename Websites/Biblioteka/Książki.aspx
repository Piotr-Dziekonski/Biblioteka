<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="Książki.aspx.cs" Inherits="About" %>

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
    
        <asp:LinkButton ID="LinkButtonListaKsiazek" runat="server" 
            onclick="LinkButtonListaKsiazek_Click">Lista książek</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButtonKsiazkaEdycja" runat="server" 
            onclick="LinkButtonImpreza_Click">Edycja</asp:LinkButton>
    
    &nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButtonWynikiWyszukiwania" runat="server" 
            Visible="False">Wyniki wyszukiwania</asp:LinkButton>
    
    </p>
    
    
        <asp:MultiView ID="MultiViewKsiazki" runat="server">
            <asp:View ID="ViewWynikiWyszukiwania" runat="server">
                <asp:GridView ID="GridViewWynikiWyszukiwania" runat="server" 
                    onload="GridViewImprezy_Load" 
                    onselectedindexchanged="GridViewImprezy_SelectedIndexChanged" 
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
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="ImageDostWysz" runat="server" ImageUrl="~/circle-red.png" />
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
            <asp:View ID="ViewListaKsiazek" runat="server">
            <p>
        <asp:GridView ID="GridViewKsiazki" runat="server" onload="GridViewImprezy_Load" 
            onselectedindexchanged="GridViewImprezy_SelectedIndexChanged" 
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="ImageDost" runat="server" ImageUrl="~/circle-red.png" />
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
                    <asp:Label ID="LabelTytuł" runat="server" Text="Tytuł" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxTytul" runat="server" 
                        ontextchanged="TextBoxDataImprezy_TextChanged" style="margin-left: 0px" 
                        ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    <asp:RadioButton ID="RadioButtonTytuł" runat="server" 
                        GroupName="GrupaRadioButton" Text="Tytuł" Visible="False" />
                </td>
                <td>
                    <asp:TextBox ID="TextBoxWyszukaj" runat="server" 
                        ontextchanged="TextBoxWyszukaj_TextChanged" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelAutor" runat="server" Text="Autor" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxAutor" runat="server" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonAutor" runat="server" 
                        GroupName="GrupaRadioButton" Text="Autor" Visible="False" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelWydawnictwo" runat="server" Text="Wydawnictwo" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxWydawnictwo" runat="server" style="margin-left: 0px" 
                        ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonWydawnictwo" runat="server" 
                        GroupName="GrupaRadioButton" Text="Wydawnictwo" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelRokWydania" runat="server" Text="Rok wydania" Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListRokWydania" runat="server" ValidationGroup="GrupaWalidacji" Visible="False" Width="214px">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonRokWydania" runat="server" 
                        GroupName="GrupaRadioButton" Text="Rok wydania" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabelMiejsceWydania" runat="server" Text="Miejsce wydania" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxMiejsceWydania" runat="server" ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonMiejsceWydania" runat="server" 
                        GroupName="GrupaRadioButton" Text="Miejsce wydania" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Kategoria" runat="server" Text="Kategoria" 
                        Visible="False"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListKategoria" runat="server" 
                        ValidationGroup="GrupaWalidacji" Width="214px" Visible="False" 
                        >
                    </asp:DropDownList>
                </td>
                <td>
                </td>
                <td class="style6">
                </td>
                <td>
                    <asp:RadioButton ID="RadioButtonKategoria" runat="server" 
                        GroupName="GrupaRadioButton" Text="Kategoria" Visible="False" />
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="LabelIlosc" runat="server" Text="Ilość" Visible="False"></asp:Label>

                </td>
                <td>

                    <asp:TextBox ID="TextBoxIlosc" runat="server" ValidationGroup="GrupaWalidacji" Visible="False" Width="214px"></asp:TextBox>

                </td>
                <td>

                </td>
                <td>

                </td>
                <td>

                </td>
                <td>

                    <asp:Button ID="ButtonWyszukaj" runat="server" onclick="ButtonWyszukaj_Click" Text="Szukaj" Visible="False" Width="128px" />

                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonDodaj" runat="server" 
                        style="margin-left: 0px" Text="Dodaj" ValidationGroup="GrupaWalidacji" 
                        Visible="False" OnClick="ButtonDodaj_Click" />
                </td>
                <td class="auto-style2">
                </td>
                <td>
                    &nbsp;</td>
                    <td class="style6">
                </td>
                <td>
                </td>
                
            </tr>
        </table>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="TextBoxTytul" Display="None" 
                ErrorMessage="Pole 'Tytuł' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="TextBoxAutor" Display="None" 
                ErrorMessage="Pole 'Autor' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="TextBoxWydawnictwo" Display="None" 
                ErrorMessage="Pole 'Wydawnictwo' nie może być puste" ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="TextBoxMiejsceWydania" Display="None" 
                ErrorMessage="Pole 'Miejsce wydania' nie może być puste" 
                ValidationGroup="GrupaWalidacji"></asp:RequiredFieldValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Pole 'Ilość' nie może być puste" ControlToValidate="TextBoxIlosc" ValidationGroup="GrupaWalidacji" Display="None"></asp:RequiredFieldValidator>
        </p>
    
                
            </asp:View>
            <asp:View ID="ViewImpreza" runat="server">
            <p>
                Edytujesz:
                <asp:Label ID="LabelEdytujesz" runat="server"></asp:Label>
            </p>
                <asp:ValidationSummary ID="ValidationSummary6" runat="server" CssClass="failureNotification" ValidationGroup="GrupaWalidacjiEdit" />
            <table>
    <tr>
    <td>

        <asp:Label ID="Label1" runat="server" Text="Tytuł"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBoxTytulView" runat="server" 
            style="margin-left: 0px" 
            ontextchanged="TextBoxDataImprezy_TextChanged" Width="214px" ValidationGroup="GrupaWalidacjiEdit"></asp:TextBox>
   </td>

    </tr>
    <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="Autor"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBoxAutorView" runat="server" Width="216px" ValidationGroup="GrupaWalidacjiEdit"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="Wydawnictwo"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBoxWydawnictwoView" runat="server" 
            style="margin-left: 0px" Width="214px" ValidationGroup="GrupaWalidacjiEdit"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="Label4" runat="server" Text="Rok wydania"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DropDownListRokWydaniaView" runat="server" Width="214px">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label5" runat="server" Text="Miejsce wydania"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TextBoxMiejsceWydaniaView" runat="server" style="margin-left: 0px" Width="214px" ValidationGroup="GrupaWalidacjiEdit"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td>
        <asp:Label ID="Label6" runat="server" Text="Kategoria"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="DropDownListKategoriaView" runat="server" Width="214px">
        </asp:DropDownList>
    </td>
    </tr>
                <tr>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>

    <tr>
    <td>
        <asp:Button ID="ButtonEdit" runat="server" onclick="ButtonEdit_Click" 
            style="margin-left: 0px" Text="Zatwierdź" ValidationGroup="GrupaWalidacjiEdit" />
    </td>
    </tr>
    </table>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxTytulView" Display="None" ErrorMessage="Pole 'Tytuł' nie może być puste" ValidationGroup="GrupaWalidacjiEdit"></asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxAutorView" Display="None" ErrorMessage="Pole 'Autor' nie może być puste" ValidationGroup="GrupaWalidacjiEdit"></asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxWydawnictwoView" Display="None" ErrorMessage="Pole 'Wydawnictwo' nie może być puste" ValidationGroup="GrupaWalidacjiEdit"></asp:RequiredFieldValidator><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxMiejsceWydaniaView" Display="None" ErrorMessage="Pole 'Miejsce wydania' nie może być puste" ValidationGroup="GrupaWalidacjiEdit"></asp:RequiredFieldValidator><br />
                <br />
                <br />
                <br />

            </asp:View>
        </asp:MultiView>
    
    
    
</asp:Content>
