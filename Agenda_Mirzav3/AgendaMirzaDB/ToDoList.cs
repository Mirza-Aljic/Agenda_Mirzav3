using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class ToDoList
{
    public int IdToDoList { get; set; }

    public string Titre { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateOnly DateEnd { get; set; }

    public sbyte Mask { get; set; }

    public string Description { get; set; } = null!;

    public int ContactIdcontact { get; set; }

    public virtual Contact ContactIdcontactNavigation { get; set; } = null!;
}
