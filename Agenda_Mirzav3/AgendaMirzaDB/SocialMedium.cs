using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class SocialMedium
{
    public int IdSocialMedia { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual ICollection<SocialProfil> SocialProfils { get; set; } = new List<SocialProfil>();
}
