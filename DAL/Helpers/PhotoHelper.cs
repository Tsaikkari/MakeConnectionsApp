using SixLabors.ImageSharp;

public class PhotoHelper
{
    // Convert image into binary format
    public static byte[] ConvertToDbImage(string imagePath)
    {
        FileInfo fileInfo = new FileInfo(imagePath);
        long bytes = fileInfo.Length;
        FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        byte[] convertedImage = binaryReader.ReadBytes((int)bytes);
        return convertedImage;
    }

    // Convert image from binary format into format that user can see
    public static Image ConvertFromDbImage(byte[] bytes)
    {
        using (var ms = new MemoryStream(bytes))
        {
            var image = Image.Load(ms);
            return image;
        }
    }
}
