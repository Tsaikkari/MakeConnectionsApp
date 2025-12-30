namespace Domain.Entities;

public class Photo
{
    public int Id { get; set; }
    public required byte[] Data { get; set; }
    public required string FileName { get; set; }

    public Member Member { get; set; } = null!;
    public string MemberId { get; set; } = null!;
}
