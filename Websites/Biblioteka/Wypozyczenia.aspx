<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="Wypozyczenia.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style2 {
            width: 920px;
        }
    </style>
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <p>
        <asp:LinkButton ID="LinkButtonListaWypozyczen" runat="server" OnClick="LinkButtonListaWypozyczen_Click">Lista wypożyczeń</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButtonDodajWypozyczenia" runat="server" OnClick="LinkButtonDodajWypozyczenia_Click">Dodaj wypożyczenia</asp:LinkButton>
    </p>
        <asp:MultiView ID="MultiViewWypozyczenie" runat="server">
            <asp:View ID="ViewDodajWypozyczenie" runat="server">    

    <table>
    <tr>
    <td class="auto-style2">
    <asp:GridView ID="GridViewUczniowie" runat="server" 
        onload="GridViewUczniowie_Load" Width="187px" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkCtrl" runat="server" />
                </ItemTemplate>
                <ControlStyle Width="20px" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#3B894C" Font-Bold="True" ForeColor="#E7E7FF" Width="15px" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#594B9C" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#33276A" />
    </asp:GridView>
    </td>
        <td class="auto-style2">        
        <asp:GridView ID="GridViewKsiazka" runat="server" onload="GridViewKsiazka_Load" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkCtrl" runat="server" />
                    </ItemTemplate>
                    <ControlStyle Width="20px" />
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
    </td>
    </tr>
        <tr>
            <td class="auto-style2" align="left" valign="top">
                <asp:Button ID="ButtonDodaj" runat="server" Text="Dodaj" 
                    onclick="ButtonDodaj_Click" ValidationGroup="Walidacja" />
                
            </td>
            <td>
                <table><tr><td align="center" valign="top">
                    <asp:TextBox ID="TextBoxDataWypozyczenia" runat="server" Enabled="False" ValidationGroup="Walidacja"></asp:TextBox>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification" DisplayMode="List" Font-Size="X-Small" ValidationGroup="Walidacja" />
                    </td><td align="center" valign="top"><asp:Button ID="ButtonWprowadz" runat="server" onclick="ButtonWprowadz_Click" 
                        Text="&gt;&gt;" Visible="true" CausesValidation="False" /></td><td><asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar></td></tr></table>
            </td>
        </tr>
    </table>
                <p>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDataWypozyczenia" ErrorMessage="Wybierz datę wypożyczenia" ValidationGroup="Walidacja" Display="None"></asp:RequiredFieldValidator>
                </p>
            </asp:View>
            <asp:View ID="ViewListaWypozyczeń" runat="server">
                <p>
                    <asp:Label ID="LabelBrakWypozyczen" runat="server" Font-Size="X-Large" Text="Brak wypożyczeń!"></asp:Label>
                </p>
                <table>
                    <tr>
                        <td>
                <asp:GridView ID="GridViewWypożyczenie" runat="server" onload="GridViewWypożyczenie_Load" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbox" runat="server" />
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
                            </td>
                   </tr>
                    <tr>
                        <td>
                            

                                        <asp:Button ID="ButtonWykonaj" runat="server" Text="Usuń" onclick="ButtonWykonaj_Click" />
                                    
                            </td>
                        </tr>
                    </table>
                </asp:View>
        </asp:MultiView>


    
    
        
    
    

    
    
    
</asp:Content>
