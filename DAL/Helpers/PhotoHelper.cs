using SixLabors.ImageSharp;

public class PhotoHelper
{
    // Convert image into binary format
    public static byte[] ConvertToDbImage(string imagePath)
    {
        FileInfo fileInfo = new(imagePath);
        long bytes = fileInfo.Length;
        // make OS give read permission for the image
        FileStream fileStream = new(imagePath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new(fileStream);
        byte[] convertedImage = binaryReader.ReadBytes((int)bytes);
        return convertedImage;
    }

    // Convert image from binary format into format that user can see
    public static Image ConvertFromDbImage(byte[] bytes)
    {
        // chunk of memory
        using (var ms = new MemoryStream(bytes))
        {
            var image = Image.Load(ms);
            return image;
        }
    }
}
