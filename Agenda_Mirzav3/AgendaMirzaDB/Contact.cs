using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class Contact
{
    public int Idcontact { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Sexe { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<SocialProfil> SocialProfils { get; set; } = new List<SocialProfil>();

    public virtual ICollection<ToDoList> ToDoLists { get; set; } = new List<ToDoList>();
}
