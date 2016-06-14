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
    
    List<Książka> _listaKsiążek = new List<Książka>();
    List<Książka> _wyszukane = new List<Książka>();
    List<Książka> _wybrane = new List<Książka>();

    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            WczytanieDropDownList();
            Wczytywacz();
            WczytanieDropDownListView();
            

        }

        MultiViewKsiazki.ActiveViewIndex = 1;
        LinkButtonKsiazkaEdycja.Enabled = true;
        LinkButtonListaKsiazek.Enabled = false;




    }
    private void WczytanieDropDownList()
    {
        WczytanieDropDownListKategoria();
        WczytanieDropDownListRokWydania();

    }
    private void WczytanieDropDownListView()
    {
        WczytanieDropDownListKategoriaView();
        WczytanieDropDownListRokWydaniaView();

    }

    private void WczytanieDropDownListRokWydania()
    {
        List<RokWydania> listaLatWydania = new List<RokWydania>();
        string kwerenda = "SELECT * FROM rokwydania ORDER BY rokwydania.RokWydania DESC";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            RokWydania rokWydania = new RokWydania();
            rokWydania.Rok = reader.GetString(1);
            rokWydania.IdRoku= Convert.ToInt32(reader.GetString(0));
            listaLatWydania.Add(rokWydania);
        }

        reader.Close();
        polaczenie.Close();


        DropDownListRokWydania.DataSource = null;
        DropDownListRokWydania.DataSource = listaLatWydania;
        DropDownListRokWydania.DataTextField = "Rok";
        DropDownListRokWydania.DataValueField = "IdRoku";
        DropDownListRokWydania.DataBind();
    }

    private void WczytanieDropDownListKategoria()
    {
        List<Kategoria> listaKategorii = new List<Kategoria>();
        string kwerenda = "SELECT * FROM kategoria ORDER BY kategoria.Kategoria ASC";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Kategoria kategoria = new Kategoria();
            kategoria.NazwaKategorii = reader.GetString(1);
            kategoria.IdKategorii = Convert.ToInt32(reader.GetString(0));
            listaKategorii.Add(kategoria);
        }

        reader.Close();
        polaczenie.Close();


        DropDownListKategoria.DataSource = null;
        DropDownListKategoria.DataSource = listaKategorii;
        DropDownListKategoria.DataTextField = "NazwaKategorii";
        DropDownListKategoria.DataValueField = "IdKategorii";
        DropDownListKategoria.DataBind();
    }


    private void WczytanieDropDownListRokWydaniaView()
    {
        List<RokWydania> listaLatWydania = new List<RokWydania>();
        string kwerenda = "SELECT * FROM rokwydania ORDER BY rokwydania.RokWydania DESC";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            RokWydania rokWydania = new RokWydania();
            rokWydania.Rok = reader.GetString(1);
            rokWydania.IdRoku = Convert.ToInt32(reader.GetString(0));
            listaLatWydania.Add(rokWydania);
        }

        reader.Close();
        polaczenie.Close();


        DropDownListRokWydaniaView.DataSource = null;
        DropDownListRokWydaniaView.DataSource = listaLatWydania;
        DropDownListRokWydaniaView.DataTextField = "Rok";
        DropDownListRokWydaniaView.DataValueField = "IdRoku";
        DropDownListRokWydaniaView.DataBind();
    }

    private void WczytanieDropDownListKategoriaView()
    {
        List<Kategoria> listaKategorii = new List<Kategoria>();
        string kwerenda3 = "SELECT * FROM kategoria ORDER BY kategoria.Kategoria ASC";
        string connection3 = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie3 = new MySqlConnection(connection3);
        MySqlCommand komenda3 = new MySqlCommand(kwerenda3, polaczenie3);
        polaczenie3.Open();
        MySqlDataReader reader3 = komenda3.ExecuteReader();

        while (reader3.Read())
        {
            Kategoria kategoria = new Kategoria();
            kategoria.NazwaKategorii = reader3.GetString(1);
            kategoria.IdKategorii = Convert.ToInt32(reader3.GetString(0));
            listaKategorii.Add(kategoria);
        }

        reader3.Close();
        polaczenie3.Close();


        DropDownListKategoriaView.DataSource = null;
        DropDownListKategoriaView.DataSource = listaKategorii;
        DropDownListKategoriaView.DataTextField = "NazwaKategorii";
        DropDownListKategoriaView.DataValueField = "IdKategorii";
        DropDownListKategoriaView.DataBind();
    }
    

    protected void GridViewImprezy_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridViewImprezy_Load(object sender, EventArgs e)
    {
        Wczytywacz();
    }

    private void Wczytywacz()
    {
        List<Książka> _listaKsiążek = new List<Książka>();
        string kwerenda =
            @"SELECT
            Idksiazki as 'Identyfikator',
            Tytul as 'Tytuł',
            Autor,
            Wydawnictwo,
            Rokwydania as 'Rok wydania',
            Miejsce_wydania as 'Miejsce wydania',
            kategoria.Kategoria as 'Kategoria',
            Ilosc as 'Ilość',
            Dostępnych
        FROM ((ksiazki INNER JOIN rokwydania ON ksiazki.Rok_wydania = rokwydania.IdRoku)
        INNER JOIN kategoria ON ksiazki.Kategoria = kategoria.IDkategorii);";
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Książka odczytane = new Książka();
            odczytane.Id = reader.GetInt32(0);
            odczytane.Tytuł = reader.GetString(1);
            odczytane.Autor = reader.GetString(2);
            odczytane.Wydawnictwo = reader.GetString(3);
            odczytane.RokWydania = reader.GetString(4);
            odczytane.MiejsceWydania = reader.GetString(5);
            odczytane.Kategoria = reader.GetString(6);
            odczytane.Ilosc = reader.GetInt16(7);
            odczytane.Dostepnych = reader.GetInt16(8);

            _listaKsiążek.Add(odczytane);
        }

        reader.Close();
        polaczenie.Close();


        GridViewKsiazki.DataSource = null;
        GridViewKsiazki.DataSource = _listaKsiążek;
        GridViewKsiazki.DataBind();

        foreach (GridViewRow row in GridViewKsiazki.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                Image img = (row.Cells[2].FindControl("ImageDost") as Image);
                if (Convert.ToInt16(row.Cells[11].Text) <= 0)
                {
                    img.ImageUrl = "~/circle-red.png";
                }
                else
                {
                    img.ImageUrl = "~/circle-green.png";
                }
            }
        }


    }
    protected void DropDownListImprezy_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ButtonDodaj_Click(object sender, EventArgs e)
    {
        List<Książka> _listaKsiążek = new List<Książka>();
        string kwerenda = string.Format(
            @"INSERT INTO `ksiazki`(`Tytul`, `Autor`, `Wydawnictwo`, `Rok_wydania`, `Miejsce_wydania`, `Kategoria`, `Ilosc`, `Dostepnych`) 
                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6}, {6})",
            TextBoxTytul.Text,
            TextBoxAutor.Text,
            TextBoxWydawnictwo.Text,
            DropDownListRokWydania.SelectedValue,
            TextBoxMiejsceWydania.Text,
            DropDownListKategoria.SelectedValue,
            TextBoxIlosc.Text);
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand cmd = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader dodaj = cmd.ExecuteReader();
        dodaj.Read();



        GridViewKsiazki.DataSource = null;
        dodaj.Close();
        polaczenie.Close();
        Wczytywacz();
        DropDownListRokWydania.Text = null;
        TextBoxTytul.Text = null;
        TextBoxWydawnictwo.Text = null;
        DropDownListKategoria.SelectedValue = null;
        TextBoxAutor.Text = null;
        TextBoxMiejsceWydania.Text = null;
        TextBoxIlosc.Text = null;
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    
 

    protected void  ImageButtonKlodka_Click(object sender, ImageClickEventArgs e)
    {
        if (HiddenField1.Value == "odblokowane")
        {
            ButtonDodaj.Visible = true;
            HiddenField1.Value = "zablokowane";
            TextBoxTytul.Visible = true;
            TextBoxAutor.Visible = true;
            TextBoxWydawnictwo.Visible = true;
            DropDownListKategoria.Visible = true;
            DropDownListRokWydania.Visible = true;
            TextBoxMiejsceWydania.Visible = true;
            LabelTytuł.Visible = true;
            LabelAutor.Visible = true;
            LabelMiejsceWydania.Visible = true;
            Kategoria.Visible = true;
            LabelRokWydania.Visible = true;
            LabelWydawnictwo.Visible = true;
            LabelWyszukaj.Visible = true;
            TextBoxWyszukaj.Visible = true;
            RadioButtonTytuł.Visible = true;
            RadioButtonAutor.Visible = true;
            RadioButtonWydawnictwo.Visible = true;
            RadioButtonMiejsceWydania.Visible = true;
            RadioButtonKategoria.Visible = true;
            RadioButtonRokWydania.Visible = true;
            ButtonWyszukaj.Visible = true;
            TextBoxIlosc.Visible = true;
            LabelIlosc.Visible = true;
            
            ImageButtonKlodka.ImageUrl = "~/unlocked24.jpeg";
            GridViewKsiazki.Columns[0].Visible = true;
            GridViewKsiazki.Columns[1].Visible = true;
        }
        else
        {
            ButtonDodaj.Visible = false;
            HiddenField1.Value = "odblokowane";
            TextBoxTytul.Visible = false;
            TextBoxAutor.Visible = false;
            TextBoxWydawnictwo.Visible = false;
            DropDownListKategoria.Visible = false;
            DropDownListRokWydania.Visible = false;
            TextBoxMiejsceWydania.Visible = false;
            LabelTytuł.Visible = false;
            LabelAutor.Visible = false;
            LabelMiejsceWydania.Visible = false;
            Kategoria.Visible = false;
            LabelRokWydania.Visible = false;
            LabelWydawnictwo.Visible = false;
            LabelWyszukaj.Visible = false;
            TextBoxIlosc.Visible = false;
            LabelIlosc.Visible = false;
            TextBoxWyszukaj.Visible = false;
            RadioButtonTytuł.Visible = false;
            RadioButtonAutor.Visible = false;
            RadioButtonWydawnictwo.Visible = false;
            RadioButtonMiejsceWydania.Visible = false;
            RadioButtonKategoria.Visible = false;
            RadioButtonRokWydania.Visible = false;
            ButtonWyszukaj.Visible = false;
            ImageButtonKlodka.ImageUrl = "~/locked24.jpeg";
            GridViewKsiazki.Columns[0].Visible = false;
            GridViewKsiazki.Columns[1].Visible = false;
        }
    }

    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        LinkButtonWynikiWyszukiwania.Visible = false;
        LinkButtonWynikiWyszukiwania.Enabled = false;
        ImageButton imageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imageButton.NamingContainer;
        string IdKsiazki = row.Cells[3].Text;

        string kwerenda = "DELETE FROM ksiazki WHERE IDksiazki=" +IdKsiazki;
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Książka odczytane = new Książka();
            odczytane.Id = reader.GetInt32(0);
            odczytane.Tytuł = reader.GetString(1);
            odczytane.Autor = reader.GetString(2);
            odczytane.Wydawnictwo = reader.GetString(3);
            odczytane.RokWydania = reader.GetString(4);
            odczytane.MiejsceWydania = reader.GetString(5);
            odczytane.Kategoria = reader.GetString(6);
            odczytane.Ilosc = reader.GetInt16(7);
            odczytane.Dostepnych = reader.GetInt16(8);

            _listaKsiążek.Remove(odczytane);
        }

        reader.Close();
        polaczenie.Close();



        GridViewKsiazki.DataSource = _listaKsiążek;
        GridViewKsiazki.DataBind();
        Wczytywacz();




    }

    protected void TextBoxDataImprezy_TextChanged(object sender, EventArgs e)
    {

    }
    
    protected void ImageButtonEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imageButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imageButton.NamingContainer;
        string IdKsiazki = row.Cells[3].Text;
        string nazwa = row.Cells[4].Text;
        HiddenField2.Value = IdKsiazki;

        

        LabelEdytujesz.Text = string.Format(@"[{0}] '{1}'",
            IdKsiazki,
            nazwa);
        LinkButtonKsiazkaEdycja.Enabled = false;
        LinkButtonListaKsiazek.Enabled = true;
        MultiViewKsiazki.ActiveViewIndex = 2;


        string kwerenda = 
            @"SELECT * FROM ksiazki WHERE IDksiazki = " + IdKsiazki;
        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";
        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            
            Liczbowe liczby = new Liczbowe();
            liczby.Kategoria = reader.GetInt32(6);
            liczby.RokWydania = reader.GetInt32(4);
            
                DropDownListRokWydaniaView.ClearSelection();
                DropDownListKategoriaView.ClearSelection();
                DropDownListRokWydaniaView.Items.FindByValue(Convert.ToString(liczby.RokWydania)).Selected = true;
                DropDownListKategoriaView.Items.FindByValue(Convert.ToString(liczby.Kategoria)).Selected = true;

        }

        
        reader.Close();
        polaczenie.Close();


        TextBoxMiejsceWydaniaView.Text = Server.HtmlDecode(row.Cells[8].Text);
        TextBoxWydawnictwoView.Text = Server.HtmlDecode(row.Cells[6].Text);
        TextBoxTytulView.Text = Server.HtmlDecode(row.Cells[4].Text);
        TextBoxAutorView.Text = Server.HtmlDecode(row.Cells[5].Text);

        

        LinkButtonWynikiWyszukiwania.Visible = false;
        LinkButtonWynikiWyszukiwania.Enabled = false;
        Wczytywacz();

    
     }
    protected void LinkButtonListaKsiazek_Click(object sender, EventArgs e)
    {
        LinkButtonKsiazkaEdycja.Enabled = true;
        LinkButtonListaKsiazek.Enabled = false;
        MultiViewKsiazki.ActiveViewIndex = 1;
        LinkButtonWynikiWyszukiwania.Visible = false;

    }
    protected void LinkButtonImpreza_Click(object sender, EventArgs e)
    {
        LinkButtonKsiazkaEdycja.Enabled = false;
        LinkButtonListaKsiazek.Enabled = true;
        MultiViewKsiazki.ActiveViewIndex = 2;
        LinkButtonWynikiWyszukiwania.Visible = false;

    }
    
    protected void ButtonEdit_Click(object sender, EventArgs e)
    {

        string AJDI = HiddenField2.Value;
        string kwerenda = string.Format(@"UPDATE ksiazki SET Tytul='{0}', Autor = '{1}', Wydawnictwo = '{2}', Rok_wydania = '{3}', Miejsce_wydania = '{4}', Kategoria = '{5}' WHERE IDksiazki = '{6}';",
            TextBoxTytulView.Text,
            TextBoxAutorView.Text,
            TextBoxWydawnictwoView.Text,
            DropDownListRokWydaniaView.SelectedValue,
            TextBoxMiejsceWydaniaView.Text,
            DropDownListKategoriaView.SelectedValue,
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

    protected void TextBoxWyszukaj_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ButtonWyszukaj_Click(object sender, EventArgs e)
    {
        if (RadioButtonTytuł.Checked)
        {
            int u = 1;
            Wyszukaj("DataImprezy",u);
        }
        else if (RadioButtonAutor.Checked)
        {
            int u = 2;
            Wyszukaj("Nauczyciel",u);
        }
        else if (RadioButtonWydawnictwo.Checked) 
        {
            int u = 3;
            Wyszukaj("Organizatorzy",u);
        }
        else if (RadioButtonMiejsceWydania.Checked)
        {
            int u = 4;
            Wyszukaj("RokSzkolny",u);
        }
        else if (RadioButtonKategoria.Checked)
        {
            int u = 5;
            Wyszukaj("TypImprezy",u);
        }
        else if (RadioButtonRokWydania.Checked)
        {
            int u = 6;
            Wyszukaj("Tytul",u);
        }
        else { }
    }

    private void Wyszukaj(string x, int u)
    {
        
        MultiViewKsiazki.ActiveViewIndex = 0;
        string kwerenda = string.Format(@"SELECT
            Idksiazki as 'Identyfikator',
            Tytul as 'Tytuł',
            Autor,
            Wydawnictwo,
            Rokwydania as 'Rok wydania',
            Miejsce_wydania as 'Miejsce wydania',
            kategoria.Kategoria as 'Kategoria'
        FROM ((ksiazki INNER JOIN rokwydania ON ksiazki.Rok_wydania = rokwydania.IdRoku)
        INNER JOIN kategoria ON ksiazki.Kategoria = kategoria.IDkategorii);"
        );

        string connection = "Server = 127.0.0.1; Port = 3306; Database = biblioteka; Uid = root;";

        MySqlConnection polaczenie = new MySqlConnection(connection);
        MySqlCommand komenda = new MySqlCommand(kwerenda, polaczenie);
        polaczenie.Open();
        MySqlDataReader reader = komenda.ExecuteReader();

        while (reader.Read())
        {
            Książka wyszukane = new Książka();
            wyszukane.Id = reader.GetInt32(0);
            wyszukane.Tytuł = reader.GetString(1);
            wyszukane.Autor = reader.GetString(2);
            wyszukane.Wydawnictwo = reader.GetString(3);
            wyszukane.RokWydania = reader.GetString(4);
            wyszukane.MiejsceWydania = reader.GetString(5);
            wyszukane.Kategoria = reader.GetString(6);

            _wyszukane.Add(wyszukane);
            if (u == 1)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.Tytuł == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 2)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.Autor == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 3)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.Wydawnictwo == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 4)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.RokWydania == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 5)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.Kategoria == TextBoxWyszukaj.Text; });
                if (q != null)
                {
                    _wybrane.Add(q);
                    _wyszukane.Remove(q);
                }
            }
            else if (u == 6)
            {
                Książka q = _wyszukane.Find(delegate(Książka p) { return p.MiejsceWydania == TextBoxWyszukaj.Text; });
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
        LinkButtonListaKsiazek.Enabled = true;
        LinkButtonKsiazkaEdycja.Enabled = true;
        _wybrane.Clear();

    }

 

}
