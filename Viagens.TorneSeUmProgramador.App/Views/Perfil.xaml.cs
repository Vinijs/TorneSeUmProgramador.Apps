namespace Viagens.TorneSeUmProgramador.App.Views;

public partial class Perfil : ContentPage
{
	public Perfil()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await TakePhoto();
    }

	public async Task TakePhoto()
	{
		if (MediaPicker.Default.IsCaptureSupported)
		{
			FileResult photo = await MediaPicker.Default.PickPhotoAsync();

			if (photo != null)
			{
				//save the file into local storage
				string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

				using Stream sourceStream = await photo.OpenReadAsync();
				using FileStream localFileStream = File.OpenWrite(localFilePath);

				await sourceStream.CopyToAsync(localFileStream);
			}
		}
	}
}