using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;



public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            WczytanieGridViewUczniowie();
            WczytanieGridViewKsiazka();
            WczytanieGridViewWypożyczenie();
            MultiViewWypozyczenie.ActiveViewIndex = 1;
            LinkButtonListaWypozyczen.Enabled = false;
        }
        

        
    }

    protected void GridViewUczniowie_Load(object sender, EventArgs e)
    {

    }

    private void WczytanieGridViewUczniowie()
    {
        List<Uczniowie> _listaUczniowie = new List<Uczniowie>();
        string kwerenda =
            @"SELECT
            IDucznia as 'ID',
            Imie as 'Imię',
            Nazwisko,
            klasa.Klasa,
            Telefon
        FROM uczniowie
        INNER JOIN klasa ON uczniowie.Klasa = klasa.IDklasy;";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Uczniowie odczytane = new Uczniowie();
            odczytane.Id = reader.GetString(0);
            odczytane.Imie = reader.GetString(1);
            odczytane.Nazwisko = reader.GetString(2);
            odczytane.Klasa = reader.GetString(3);
            odczytane.Telefon = reader.GetString(4);

            _listaUczniowie.Add(odczytane);
        }
        reader.Close();
        polaczenie.Close();

        GridViewUczniowie.DataSource = null;
        GridViewUczniowie.DataSource = _listaUczniowie;
        GridViewUczniowie.DataBind();
    }
    protected void GridViewWypożyczenie_Load(object sender, EventArgs e)
    {
        
    }

    private void WczytanieGridViewWypożyczenie()
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Uczeń"), new DataColumn("Książka"), new DataColumn("Data Wypożyczenia") });

        string kwerenda2 = string.Format(
                                     @"SELECT `IDwypozyczenia` AS `ID`, CONCAT(Imie,' ',Nazwisko) AS `Uczeń`, `Tytul` AS `Książka`, `DataWypozyczenia` AS `Data wypożyczenia` FROM ((`wypozyczenia` INNER JOIN `uczniowie` ON wypozyczenia.Uczen = uczniowie.IDucznia)
        INNER JOIN ksiazki ON wypozyczenia.Ksiazka = ksiazki.IDksiazki);");
        string connection2 = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie2 = new MySqlConnection(connection2);
        MySqlCommand cmd2 = new MySqlCommand(kwerenda2, polaczenie2);
        polaczenie2.Open();
        MySqlDataReader zaladuj = cmd2.ExecuteReader();
        while (zaladuj.Read())
        {
            int IDwypozyczenia = zaladuj.GetInt32(0);
            string uczenBaza = zaladuj.GetString(1);
            string ksiazkaBaza = zaladuj.GetString(2);
            string wypozyczenieBaza = zaladuj.GetString(3);
            dt.Rows.Add(IDwypozyczenia, uczenBaza, ksiazkaBaza, wypozyczenieBaza);
        }
        zaladuj.Close();
        polaczenie2.Close();

        GridViewWypożyczenie.DataSource = null;
        GridViewWypożyczenie.DataSource = dt;
        GridViewWypożyczenie.DataBind();

        if(GridViewWypożyczenie.Rows.Count == 0)
        {
            
            ButtonWykonaj.Visible = false;
            LabelBrakWypozyczen.Visible = true;
        }
        else
        {
            ButtonWykonaj.Visible = true;
            LabelBrakWypozyczen.Visible = false;
        }
        
    }
    protected void GridViewKsiazka_Load(object sender, EventArgs e)
    {
  
    }

    private void WczytanieGridViewKsiazka()
    {
        List<ZamowionaKsiążka> _listaKsiazekDoZamowienia = new List<ZamowionaKsiążka>();
        string kwerenda =
            @"SELECT
            Idksiazki as 'Identyfikator',
            Tytul as 'Tytuł',
            Autor,
            Wydawnictwo,
            kategoria.Kategoria as 'Kategoria',
            Ilosc as 'Ilość',
            Dostepnych as 'Dostępnych'
        FROM ((ksiazki INNER JOIN rokwydania ON ksiazki.Rok_wydania = rokwydania.IdRoku)
        INNER JOIN kategoria ON ksiazki.Kategoria = kategoria.IDkategorii);";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            ZamowionaKsiążka odczytane = new ZamowionaKsiążka();
            odczytane.Id = reader.GetInt32(0);
            odczytane.Tytuł = reader.GetString(1);
            odczytane.Autor = reader.GetString(2);
            odczytane.Wydawnictwo = reader.GetString(3);
            odczytane.Kategoria = reader.GetString(4);
            odczytane.Ilosc = reader.GetInt16(5);
            odczytane.Dostepnych = reader.GetInt16(6);

            _listaKsiazekDoZamowienia.Add(odczytane);
        }

        reader.Close();
        polaczenie.Close();


        GridViewKsiazka.DataSource = null;
        GridViewKsiazka.DataSource = _listaKsiazekDoZamowienia;
        GridViewKsiazka.DataBind(); 
    }
    protected void ButtonDodaj_Click(object sender, EventArgs e)
    {
        bool czyWprowadzonoDane = false;
        DataTable dt = new DataTable();

        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("ID"), new DataColumn("Uczeń"), new DataColumn("Książka"), new DataColumn("Data Wypożyczenia") });
        int i = 0;
        
            foreach (GridViewRow row2 in GridViewUczniowie.Rows)
            {
                if (row2.RowType == DataControlRowType.DataRow)
                {

                    CheckBox chkRow = (row2.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        i++;
                    }
                }
            }
        
            foreach(GridViewRow roww in GridViewKsiazka.Rows)
            {
                if (roww.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (roww.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                                string ksiazka = roww.Cells[1].Text;
                                int odejmij = Convert.ToInt16(roww.Cells[7].Text) - i;
                                string kwerenda2 = string.Format(
                                     @"UPDATE `biblioteka`.`ksiazki` SET `Dostepnych` = '{1}' WHERE `ksiazki`.`IDksiazki` = {0};",
                                   ksiazka,
                                   odejmij);
                                string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
                                MySqlConnection polaczenie = new MySqlConnection(connection);
                                MySqlCommand cmd2 = new MySqlCommand(kwerenda2, polaczenie);
                                polaczenie.Open();
                                MySqlDataReader update = cmd2.ExecuteReader();
                                update.Read();
                                update.Close();
                                polaczenie.Close();
                    }
                }
            }

            foreach (GridViewRow row4 in GridViewUczniowie.Rows)
            {
                if (row4.RowType == DataControlRowType.DataRow)
                {

                    CheckBox chkRow = (row4.Cells[0].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        
                        string uczen = row4.Cells[1].Text;

                        foreach (GridViewRow row2 in GridViewKsiazka.Rows)
                        {
                            if (row2.RowType == DataControlRowType.DataRow)
                            {

                                CheckBox chkRow2 = (row2.Cells[0].FindControl("chkCtrl") as CheckBox);
                                if (chkRow2.Checked)
                                {

                                    czyWprowadzonoDane = true;
                                    string ksiazka = row2.Cells[1].Text;
                                    string data = TextBoxDataWypozyczenia.Text;
                                    string kwerenda = string.Format(
                                         @"INSERT INTO `wypozyczenia`(`Uczen`, `Ksiazka`, `DataWypozyczenia`) 
                                                    VALUES ('{0}','{1}','{2}')",
                                       uczen,
                                       ksiazka,
                                       data);

                                    string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
                                    MySqlConnection polaczenie = new MySqlConnection(connection);
                                    MySqlCommand cmd = new MySqlCommand(kwerenda, polaczenie);
                                    polaczenie.Open();
                                    MySqlDataReader dodaj = cmd.ExecuteReader();
                                    dodaj.Read();
                                    dodaj.Close();
                                    polaczenie.Close();





                                }

                            }

                        }


                    }

                }

            }
        foreach (GridViewRow row in GridViewUczniowie.Rows) 
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkCtrl") as CheckBox);
                if (chkRow.Checked)
                {
                    chkRow.Checked = false;
                }
            }
        }
        foreach (GridViewRow row2 in GridViewUczniowie.Rows) 
        {
             if (row2.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow2 = (row2.Cells[0].FindControl("chkCtrl") as CheckBox);
                if (chkRow2.Checked)
                {
                    chkRow2.Checked = false;
                }
             }
        }


        string kwerenda3 = string.Format(
                                     @"SELECT `IDwypozyczenia` AS `ID`, CONCAT(Imie,' ',Nazwisko) AS `Uczeń`, `Tytul` AS `Książka`, `DataWypozyczenia` AS `Data wypożyczenia` FROM ((`wypozyczenia` INNER JOIN `uczniowie` ON wypozyczenia.Uczen = uczniowie.IDucznia)
        INNER JOIN ksiazki ON wypozyczenia.Ksiazka = ksiazki.IDksiazki);");
        string connection2 = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie2 = new MySqlConnection(connection2);
        MySqlCommand cmd3 = new MySqlCommand(kwerenda3, polaczenie2);
        polaczenie2.Open();
        MySqlDataReader zaladuj = cmd3.ExecuteReader();
        while (zaladuj.Read())
        {
            int IDwypozyczenia = zaladuj.GetInt32(0);
            string uczenBaza = zaladuj.GetString(1);
            string ksiazkaBaza = zaladuj.GetString(2);
            string wypozyczenieBaza = zaladuj.GetString(3);
            dt.Rows.Add(IDwypozyczenia, uczenBaza, ksiazkaBaza, wypozyczenieBaza);
        }
        zaladuj.Close();
        polaczenie2.Close();

        GridViewWypożyczenie.DataSource = null;
        GridViewWypożyczenie.DataSource = dt;
        GridViewWypożyczenie.DataBind();

        if (GridViewWypożyczenie.Rows.Count == 0)
        {

            ButtonWykonaj.Visible = false;
            LabelBrakWypozyczen.Visible = true;
        }
        else
        {
            ButtonWykonaj.Visible = true;
            LabelBrakWypozyczen.Visible = false;
        }

        if (czyWprowadzonoDane)
        {
            Przerzuc();
        }
        WczytanieGridViewKsiazka();
        TextBoxDataWypozyczenia.Text = null;
    }
    protected void LinkButtonDodajWypozyczenia_Click(object sender, EventArgs e)
    {
        MultiViewWypozyczenie.ActiveViewIndex = 0;
        LinkButtonListaWypozyczen.Enabled = true;
        LinkButtonDodajWypozyczenia.Enabled = false;
        WczytanieGridViewKsiazka();
    }
    protected void LinkButtonListaWypozyczen_Click(object sender, EventArgs e)
    {
        Przerzuc();
    }

    private void Przerzuc()
    {
        MultiViewWypozyczenie.ActiveViewIndex = 1;
        LinkButtonListaWypozyczen.Enabled = false;
        LinkButtonDodajWypozyczenia.Enabled = true;
    }

    protected void ButtonWprowadz_Click(object sender, EventArgs e)
    {
        if (ButtonWprowadz.Text == ">>")
        {
            Calendar1.Visible = true;
            ButtonWprowadz.Text = "<<";
        }
        else if (ButtonWprowadz.Text == "<<")
        {
            Calendar1.Visible = false;
            ButtonWprowadz.Text = ">>";
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

        Calendar1.Visible = false;
        ButtonWprowadz.Text = ">>";
        TextBoxDataWypozyczenia.Text = Calendar1.SelectedDate.ToShortDateString();
    
    }
    protected void ButtonWykonaj_Click(object sender, EventArgs e)
    {


        foreach (GridViewRow row in GridViewWypożyczenie.Rows)
        {
            
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkBox") as CheckBox);
                if (chkRow.Checked)
                {
                    string ksiazka = row.Cells[3].Text;
                    string ID = row.Cells[1].Text;
                    string kwerenda = string.Format(
                         @"DELETE FROM `wypozyczenia` WHERE IDwypozyczenia = " + ID);
                    string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
                    MySqlConnection polaczenie = new MySqlConnection(connection);
                    MySqlCommand cmd = new MySqlCommand(kwerenda, polaczenie);
                    polaczenie.Open();
                    MySqlDataReader dodaj = cmd.ExecuteReader();
                    dodaj.Read();
                    dodaj.Close();
                    polaczenie.Close();

                    
                    

                    foreach (GridViewRow row2 in GridViewKsiazka.Rows)
                    {
                        
                        if (row2.RowType == DataControlRowType.DataRow)
                        {
                            if (row2.Cells[2].Text == ksiazka) 
                            {
                                int suma = Convert.ToInt16(row2.Cells[7].Text) + 1;
                                string kwerenda2 = string.Format(
                                 @"UPDATE `biblioteka`.`ksiazki` SET `Dostepnych` = '{1}' WHERE `ksiazki`.`Tytul` = '{0}';",
                                ksiazka,
                                suma);

                                MySqlCommand cmd2 = new MySqlCommand(kwerenda2, polaczenie);
                                polaczenie.Open();
                                MySqlDataReader update = cmd2.ExecuteReader();
                                update.Read();
                                update.Close();
                                polaczenie.Close();
                                WczytanieGridViewKsiazka();
                            }
                        }
                    }
                    chkRow.Checked = false;


                    


                }
            }
        }
        WczytanieGridViewWypożyczenie();
        WczytanieGridViewKsiazka();
    }
}
