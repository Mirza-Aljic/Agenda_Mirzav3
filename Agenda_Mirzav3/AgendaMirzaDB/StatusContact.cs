using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class StatusContact
{
    public int IdStatusContact { get; set; }

    public string Status { get; set; } = null!;

    public int ContactIdcontact { get; set; }

    public virtual Contact ContactIdcontactNavigation { get; set; } = null!;
}
