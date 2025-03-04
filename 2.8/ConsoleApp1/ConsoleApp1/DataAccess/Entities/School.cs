﻿namespace ConsoleApp1.DataAccess.Entities;

public class School
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int ZipCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int StudentCount { get; set; }
}
