namespace ConsoleApp1.Services.DTOs;

public class SchoolUpdateDto : SchoolBaseDto
{
    public Guid Id { get; set; }

    public int ZipCode { get; set; }
}
