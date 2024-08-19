using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Borrower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Borrower(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}