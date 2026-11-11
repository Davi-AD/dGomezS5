using dGomezS5.Models;

namespace dGomezS5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = " ";
        App._personrepo.AddNewPerson(txtNombre.Text);
        lblMessage.Text = App._personrepo.Message;
        txtNombre.Text = "";
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = " ";
        List<Persona> people = App._personrepo.GetAllPerson();
        ListaPersonas.ItemsSource = people;
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        string id = await DisplayPromptAsync("Eliminar", "Ingrese el ID de la persona:");

        if (int.TryParse(id, out int idPersona))
        {
            App._personrepo.DeletePerson(idPersona);

            lblMessage.Text = App._personrepo.Message;

            ListaPersonas.ItemsSource = App._personrepo.GetAllPerson();
        }
        else
        {

            await DisplayAlert("Error", "Ingrese un ID válido", "OK");
        }
    }

    private async void btnEditar_Clicked(object sender, EventArgs e)
    {
        string id = await DisplayPromptAsync("Editar", "Ingrese el ID de la persona:");

        if (!int.TryParse(id, out int idPersona))
        {
            await DisplayAlertAsync("Error", "Ingrese un ID válido", "OK");
            return;
        }

        string nombre = await DisplayPromptAsync("Editar", "Ingrese el nuevo nombre:");

        if (nombre == null)
            return;

        App._personrepo.UpdatePerson(idPersona, nombre);

        lblMessage.Text = App._personrepo.Message;

        ListaPersonas.ItemsSource = App._personrepo.GetAllPerson();
    }
}