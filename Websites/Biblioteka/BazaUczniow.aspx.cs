using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;



public partial class About : System.Web.UI.Page
{


    List<Uczniowie> _listaUczniow = new List<Uczniowie>();
    List<Uczniowie> _wyszukane = new List<Uczniowie>();
    List<Uczniowie> _wybrane = new List<Uczniowie>();




    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Wczytywacz();
            WczytanieDropDownListKlasa();
            WczytanieDropDownListKlasaEdit();
        }
        
        MultiViewUczniowie.ActiveViewIndex = 1;
        LinkButtonUczenEdycja.Enabled = true;
        LinkButtonListaUczniow.Enabled = false;
    }

    private void WczytanieDropDownListKlasa()
    {
        List<Klasa> listaKlas = new List<Klasa>();
        string kwerenda = "SELECT * FROM klasa ORDER BY `klasa`.`Klasa` ASC";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Klasa klasa = new Klasa();
            klasa.IdKlasy = reader.GetString(0);
            klasa.KlasaUcznia = reader.GetString(1);
            listaKlas.Add(klasa);
        }

        reader.Close();
        polaczenie.Close();


        DropDownListKlasa.DataSource = null;
        DropDownListKlasa.DataSource = listaKlas;
        DropDownListKlasa.DataTextField = "KlasaUcznia";
        DropDownListKlasa.DataValueField = "IDklasy";
        DropDownListKlasa.DataBind();

    }




    private void WczytanieDropDownListKlasaEdit()
    {
        List<Klasa> listaKlas = new List<Klasa>();
        string kwerenda = "SELECT * FROM klasa ORDER BY `klasa`.`Klasa` ASC";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Klasa klasa = new Klasa();
            klasa.KlasaUcznia = reader.GetString(1);
            klasa.IdKlasy = reader.GetString(0);
            listaKlas.Add(klasa);
        }

        reader.Close();
        polaczenie.Close();


        DropDownListKlasaEdit.DataSource = null;
        DropDownListKlasaEdit.DataSource = listaKlas;
        DropDownListKlasaEdit.DataTextField = "KlasaUcznia";
        DropDownListKlasaEdit.DataValueField = "IDklasy";
        DropDownListKlasaEdit.DataBind();
        
    }
    protected void GridViewUczniowie_Load(object sender, EventArgs e)
    {
        Wczytywacz();
    }

    private void Wczytywacz()
    {
        List<Uczniowie> _listaUczniow = new List<Uczniowie>();
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

            _listaUczniow.Add(odczytane);
        }

        reader.Close();
        polaczenie.Close();


        GridViewUczniowie.DataSource = null;
        GridViewUczniowie.DataSource = _listaUczniow;
        GridViewUczniowie.DataBind();
    }
    protected void ButtonDodaj_Click(object sender, EventArgs e)
    {
        string kwerenda = string.Format(
            @"INSERT INTO `uczniowie`(`Imie`, `Nazwisko`, `Klasa`, `Telefon`) 
                VALUES ('{0}','{1}','{2}','{3}')",
            Server.HtmlDecode(TextBoxImie.Text),
            Server.HtmlDecode(TextBoxNazwisko.Text),
            DropDownListKlasa.SelectedItem.Value,
            TextBoxTelefon.Text);
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand cmd = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader dodaj = cmd.ExecuteReader();
        dodaj.Read();



        GridViewUczniowie.DataSource = null;
        dodaj.Close();
        polaczenie.Close();
        Wczytywacz();
        TextBoxImie.Text = null;
        TextBoxNazwisko.Text = null;
        TextBoxTelefon.Text = null;
    }

    protected void ImageButtonKlodka_Click(object sender, ImageClickEventArgs e)
    {
        if (HiddenField1.Value == "odblokowane")
        {
            ButtonDodaj.Visible = true;
            HiddenField1.Value = "zablokowane";
            TextBoxImie.Visible = true;
            TextBoxNazwisko.Visible = true;
            TextBoxTelefon.Visible = true;
            DropDownListKlasa.Visible = true;
            LabelImie.Visible = true;
            LabelNazwisko.Visible = true;
            LabelTelefon.Visible = true;
            LabelKlasa.Visible = true;
            LabelWyszukaj.Visible = true;
            TextBoxWyszukaj.Visible = true;
            RadioButtonImie.Visible = true;
            RadioButtonNazwisko.Visible = true;
            RadioButtonKlasa.Visible = true;
            RadioButtonTelefon.Visible = true;
            ButtonWyszukaj.Visible = true;

            ImageButtonKlodka.ImageUrl = "~/unlocked24.jpeg";
            GridViewUczniowie.Columns[0].Visible = true;
            GridViewUczniowie.Columns[1].Visible = true;
        }
        else
        {
            ButtonDodaj.Visible = false;
            HiddenField1.Value = "odblokowane";
            TextBoxImie.Visible = false;
            TextBoxNazwisko.Visible = false;
            TextBoxTelefon.Visible = false;
            DropDownListKlasa.Visible = false;
            LabelImie.Visible = false;
            LabelNazwisko.Visible = false;
            LabelTelefon.Visible = false;
            LabelKlasa.Visible = false;
            LabelWyszukaj.Visible = false;
            TextBoxWyszukaj.Visible = false;
            RadioButtonImie.Visible = false;
            RadioButtonNazwisko.Visible = false;
            RadioButtonKlasa.Visible = false;
            RadioButtonTelefon.Visible = false;
            ButtonWyszukaj.Visible = false;

            ImageButtonKlodka.ImageUrl = "~/locked24.jpeg";
            GridViewUczniowie.Columns[0].Visible = false;
            GridViewUczniowie.Columns[1].Visible = false;
        }
    }

    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        LinkButtonWynikiWyszukiwania.Visible = false;
        LinkButtonWynikiWyszukiwania.Enabled = false;
        ImageButton imageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imageButton.NamingContainer;
        string Iducznia = row.Cells[2].Text;

        string kwerenda = "DELETE FROM uczniowie WHERE IDucznia=" + Iducznia;
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

            _listaUczniow.Add(odczytane);
        }

        reader.Close();
        polaczenie.Close();



        GridViewUczniowie.DataSource = _listaUczniow;
        GridViewUczniowie.DataBind();
        Wczytywacz();




    }


    protected void ImageButtonEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imageButton.NamingContainer;
        string Iducznia = Server.HtmlDecode(row.Cells[2].Text);
        string imie = Server.HtmlDecode(row.Cells[3].Text);
        string nazwisko = Server.HtmlDecode(row.Cells[4].Text);
        HiddenField2.Value = Iducznia;



        LabelEdytujesz.Text = string.Format(@"[{0}] {1} {2}",
            Iducznia,
            imie,
            nazwisko);
        LinkButtonUczenEdycja.Enabled = false;
        LinkButtonListaUczniow.Enabled = true;
        MultiViewUczniowie.ActiveViewIndex = 2;


        string kwerenda =
            @"SELECT * FROM uczniowie WHERE IDucznia = " + Iducznia;
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {

            Liczbowe idUcznia = new Liczbowe();
            idUcznia.Klasa = reader.GetString(3);

            DropDownListKlasaEdit.ClearSelection();
            DropDownListKlasaEdit.Items.FindByValue(Convert.ToString(idUcznia.Klasa)).Selected = true;

        }


        reader.Close();
        polaczenie.Close();


        TextBoxImieEdit.Text = Server.HtmlDecode(row.Cells[3].Text);
        TextBoxNazwiskoEdit.Text = Server.HtmlDecode(row.Cells[4].Text);
        TextBoxTelefonEdit.Text = Server.HtmlDecode(row.Cells[6].Text);


        LinkButtonWynikiWyszukiwania.Visible = false;
        LinkButtonWynikiWyszukiwania.Enabled = false;
        Wczytywacz();


    }
    protected void LinkButtonListaUczniow_Click(object sender, EventArgs e)
    {
        LinkButtonUczenEdycja.Enabled = true;
        LinkButtonListaUczniow.Enabled = false;
        MultiViewUczniowie.ActiveViewIndex = 1;
        LinkButtonWynikiWyszukiwania.Visible = false;

    }
    protected void LinkButtonUczen_Click(object sender, EventArgs e)
    {
        LinkButtonUczenEdycja.Enabled = false;
        LinkButtonListaUczniow.Enabled = true;
        MultiViewUczniowie.ActiveViewIndex = 2;
        LinkButtonWynikiWyszukiwania.Visible = false;

    }

    protected void ButtonEdit_Click(object sender, EventArgs e)
    {

        string AJDI = HiddenField2.Value;
        string kwerenda = string.Format(@"UPDATE uczniowie SET Imie='{0}', Nazwisko = '{1}', Klasa = '{2}', Telefon = '{3}' WHERE IDucznia = '{4}';",

            Server.HtmlDecode(TextBoxImieEdit.Text),
            Server.HtmlDecode(TextBoxNazwiskoEdit.Text),
            DropDownListKlasaEdit.SelectedValue,
            TextBoxTelefonEdit.Text,
            AJDI);

        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";

        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
        }
        reader.Close();
        Wczytywacz();
    }
    protected void ButtonWyszukaj_Click(object sender, EventArgs e)
    {
        if (RadioButtonImie.Checked)
        {
            int u = 1;
            Wyszukaj("Imie", u);
        }
        else if (RadioButtonNazwisko.Checked)
        {
            int u = 2;
            Wyszukaj("Nazwisko", u);
        }
        else if (RadioButtonKlasa.Checked)
        {
            int u = 3;
            Wyszukaj("Klasa", u);
        }
        else if (RadioButtonTelefon.Checked)
        {
            int u = 4;
            Wyszukaj("Telefon", u);
        }
        else { }
    }

    private void Wyszukaj(string x, int u)
    {

        MultiViewUczniowie.ActiveViewIndex = 0;
        string kwerenda = string.Format(@"SELECT
            IDucznia as 'ID',
            Imie as 'Imię',
            Nazwisko,
            klasa.Klasa,
            Telefon
        FROM uczniowie
        INNER JOIN klasa ON uczniowie.Klasa = klasa.IDklasy;"
        );

        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";

        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Uczniowie wyszukane = new Uczniowie();
            wyszukane.Id = reader.GetString(0);
            wyszukane.Imie = reader.GetString(1);
            wyszukane.Nazwisko = reader.GetString(2);
            wyszukane.Klasa = reader.GetString(3);
            wyszukane.Telefon = reader.GetString(4);

            _wyszukane.Add(wyszukane);
            if (u == 1)
            {
                Uczniowie q = _wyszukane.Find(delegate(Uczniowie p) { return p.Imie == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 2)
            {
                Uczniowie q = _wyszukane.Find(delegate(Uczniowie p) { return p.Nazwisko == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 3)
            {
                Uczniowie q = _wyszukane.Find(delegate(Uczniowie p) { return p.Klasa == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 4)
            {
                Uczniowie q = _wyszukane.Find(delegate(Uczniowie p) { return p.Telefon == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
        }

        reader.Close();
        polaczenie.Close();


        GridViewWynikiWyszukiwania.DataSource = null;
        GridViewWynikiWyszukiwania.DataSource = _wybrane;
        GridViewWynikiWyszukiwania.DataBind();
        LinkButtonWynikiWyszukiwania.Visible = true;
        LinkButtonWynikiWyszukiwania.Enabled = false;
        LinkButtonListaUczniow.Enabled = true;
        LinkButtonUczenEdycja.Enabled = true;
        _wybrane.Clear();
    }




}
