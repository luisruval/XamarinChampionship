using Plugin.Media;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace Emotions
{
    public class ServiceImage
    {
        public static async Task<MediaFile> TakePicture(bool useCam = true)
        {
            await CrossMedia.Current.Initialize();

            if (useCam)
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    return null;
                }
            }

            var file = useCam
            ? await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Championship",
                Name = "Reto6_Test.jpg"
            })
            : await CrossMedia.Current.PickPhotoAsync();

            return file;
        }
    }
}
